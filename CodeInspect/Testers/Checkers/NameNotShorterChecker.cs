using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using CodeInspect.Enums;
using CodeInspect.Models;
using CodeInspect.Testers.Interfaces;

namespace CodeInspect.Testers.Checkers
{
    class NameNotShorterChecker : IChecker
    {
        public RuleType Rule => RuleType.NameNotShorterThan;

        public InspectionItem Check(MemberInfo item, object paramValue)
        {
            var value = (int)paramValue;
            if (item.Name.Length < value)
            {
                return InspectionItem.Create(item, false, $"Too short member name {item.Name} in class {item.DeclaringType}");
            }
            return InspectionItem.Ok(item);
        }
    }
}
