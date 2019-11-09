using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using CodeInspect.Enums;
using CodeInspect.Models;
using CodeInspect.Testers.Interfaces;

namespace CodeInspect.Testers.Checkers
{
    class InheritsChecker : IChecker
    {
        public RuleType Rule => RuleType.Inherits;

        public InspectionItem Check(MemberInfo item, object paramValue)
        {
            var value = (Type)paramValue;
            var type = (TypeInfo)item;

            if (!value.IsAssignableFrom(type))
            {
                return InspectionItem.Create(false, $"Type {item.Name} not inherits {value.Name}");
            }
            return InspectionItem.Ok;
        }
    }
}
