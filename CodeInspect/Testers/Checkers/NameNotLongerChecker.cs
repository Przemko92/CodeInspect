using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using CodeInspect.Enums;
using CodeInspect.Models;
using CodeInspect.Testers.Interfaces;

namespace CodeInspect.Testers.Checkers
{
    class NameNotLongerChecker : IChecker
    {
        public RuleType Rule => RuleType.NameNotLongerThan;

        public InspectionItem Check(MemberInfo item, object paramValue)
        {
            var value = (int)paramValue;
            if (item.Name.Length > value)
            {
                return InspectionItem.Create(item, false, $"Too long member name {item.Name} in class {item.DeclaringType}");
            }
            return InspectionItem.Ok(item);
        }
    }
}
