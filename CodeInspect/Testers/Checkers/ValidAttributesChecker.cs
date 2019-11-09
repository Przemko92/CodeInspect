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
    class ValidAttributesChecker : IChecker
    {
        public RuleType Rule => RuleType.ValidAttributes;

        public InspectionItem Check(MemberInfo item, object paramValue)
        {
            var attributes = (IEnumerable<Type>) paramValue;

            if (!attributes.All(x => item.CustomAttributes.Select(y => y.AttributeType).Contains(x)))
            {
                return InspectionItem.Create(item, false, $"Member {item.Name} in class {item.DeclaringType} has not all attributes {string.Join(", ", attributes.Select(x => x.Name))}");
            }

            return InspectionItem.Ok(item);
        }
    }
}
