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
    class HasPublicConstructorChecker : IChecker
    {
        public RuleType Rule => RuleType.HasPublicConstructor;

        public InspectionItem Check(MemberInfo item, object paramValue)
        {
            var type = (TypeInfo) item;
            var value = (bool) paramValue;

            if (!type.DeclaredConstructors.Any())
            {
                return InspectionItem.Create(item, true, "This item has no constructors. Skipped");
            }

            foreach (var constructor in type.DeclaredConstructors)
            {
                if (value && constructor.IsPublic)
                {
                    return InspectionItem.Ok(item);
                }
                else if (!value && constructor.IsPublic)
                {
                    return InspectionItem.Create(item, false, $"Type {item.Name} has public constructor");
                }
            }

            if (!value && type.DeclaredConstructors.All(x => !x.IsPublic))
            {
                return InspectionItem.Ok(item);
            }

            return InspectionItem.Create(item, false, $"Type {item.Name} has not valid constructor");
        }
    }
}
