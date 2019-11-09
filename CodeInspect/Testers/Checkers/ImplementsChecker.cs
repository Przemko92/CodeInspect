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
    class ImplementsChecker : IChecker
    {
        public RuleType Rule => RuleType.Implements;

        public InspectionItem Check(MemberInfo item, object paramValue)
        {
            var value = (IEnumerable<Type>)paramValue;
            var type = (TypeInfo)item;

            if (!value.Any(x => x.IsAssignableFrom(type)))
            {
                return InspectionItem.Create(false, $"Type {item.Name} is not implements all interfaces: {string.Join(", ", value.Select(x => x.Name))}");
            }
            return InspectionItem.Ok;
        }
    }
}
