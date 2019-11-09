using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using CodeInspect.Enums;
using CodeInspect.Helpers;
using CodeInspect.Models;
using CodeInspect.Testers.Interfaces;

namespace CodeInspect.Testers.Checkers
{
    class HasGetterChecker : IChecker
    {
        public RuleType Rule => RuleType.HasGetter;

        public InspectionItem Check(MemberInfo item, object paramValue)
        {
            var value = (PropertyOptions)paramValue;
            var property = (PropertyInfo)item;

            if (value.Value)
            {
                if (property.GetMethod != null)
                {
                    if (value.IncludePrivate)
                    {
                        return InspectionItem.Ok(property);
                    }

                    if ((property.GetMethod.IsPublic && property.IsPublic()) ||
                        (property.GetMethod.IsAssembly && property.IsInternal()) ||
                        (property.GetMethod.IsFamily && property.IsProtected()))
                    {
                        return InspectionItem.Ok(property);
                    }
                    return InspectionItem.Create(item, false, $"Property {property.Name} in {property.DeclaringType.Name} has has only private getter");
                }

                return InspectionItem.Create(item, false, $"Property {property.Name} in {property.DeclaringType.Name} has no getter");
            }
            else
            {
                if (property.GetMethod == null)
                {
                    return InspectionItem.Ok(property);
                }
                else if (property.GetMethod.IsPrivate)
                {
                    if (value.IncludePrivate)
                    {
                        return InspectionItem.Create(item, false, $"Property {property.Name} in {property.DeclaringType.Name} has private getter");
                    }
                    return InspectionItem.Ok(property);
                }
                else
                {
                    return InspectionItem.Create(item, false, $"Property {property.Name} in {property.DeclaringType.Name} has getter");
                }
            }
        }
    }
}
