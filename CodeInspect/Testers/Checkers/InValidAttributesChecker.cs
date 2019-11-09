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
    class InValidAttributesChecker : IChecker
    {
        public RuleType Rule => RuleType.InValidAttributes;

        public InspectionItem Check(MemberInfo item, object paramValue)
        {
            var attributes = (IEnumerable<Type>)paramValue;

            if (item.CustomAttributes.Any(x => attributes.Contains(x.AttributeType)))
            {
                return InspectionItem.Create(false, $"Member {item.Name} in class {item.DeclaringType} has all attributes {string.Join(", ", attributes.Select(x => x.Name))}");
            }

            return InspectionItem.Ok;
        }
    }
}
