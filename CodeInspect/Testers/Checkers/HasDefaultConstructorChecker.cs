using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CodeInspect.Enums;
using CodeInspect.Models;
using CodeInspect.Testers.Interfaces;

namespace CodeInspect.Testers.Checkers
{
    class HasDefaultConstructorChecker : IChecker
    {
        public RuleType Rule => RuleType.DefaultConstructor;

        public InspectionItem Check(MemberInfo item, object paramValue)
        {
            var type = (TypeInfo) item;
            var value = (DefaultConstructorOptions) paramValue;

            if (!type.DeclaredConstructors.Any())
            {
                return InspectionItem.Create(item, true, "This item has no constructors. Skipped");
            }

            foreach (var constructor in type.DeclaredConstructors)
            {
                if (constructor.GetParameters().Length == 0)
                {
                    if (value.IncluePrivate || type.IsAbstract)
                    {
                        return InspectionItem.Ok(item);
                    }

                    if (constructor.IsPublic)
                    {
                        return InspectionItem.Ok(item);
                    }
                }
            }
            return InspectionItem.Create(item, false, $"No default constructor found in type {type.Name}");
        }
    }
}
