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
    class HasSetterChecker : IChecker
    {
        public RuleType Rule => RuleType.HasSetter;

        public InspectionItem Check(MemberInfo item, object paramValue)
        {
            var value = (PropertyOptions) paramValue;
            var property = (PropertyInfo) item;

            if (value.Value)
            {
                if (property.SetMethod != null)
                {
                    if (value.IncludePrivate)
                    {
                        return InspectionItem.Ok(property);
                    }
                    if ((property.SetMethod.IsPublic && property.IsPublic()) ||
                        (property.SetMethod.IsAssembly && property.IsInternal()) ||
                        (property.SetMethod.IsFamily && property.IsProtected()))
                    {
                        return InspectionItem.Ok(property);
                    }
                    return InspectionItem.Create(item, false, $"Property {property.Name} in {property.DeclaringType.Name} has has only private setter");
                }

                return InspectionItem.Create(item, false, $"Property {property.Name} in {property.DeclaringType.Name} has no setter");
            }
            else
            {
                if (property.SetMethod == null)
                {
                    return InspectionItem.Ok(property);
                }
                else if (property.SetMethod.IsPrivate)
                {
                    if (value.IncludePrivate)
                    {
                        return InspectionItem.Create(item, false, $"Property {property.Name} in {property.DeclaringType.Name} has private setter");
                    }
                    return InspectionItem.Ok(property);
                }
                else
                {
                    return InspectionItem.Create(item, false, $"Property {property.Name} in {property.DeclaringType.Name} has setter");
                }
            }
        }
    }
}
