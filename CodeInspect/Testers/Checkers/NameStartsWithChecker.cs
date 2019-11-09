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
    class NameStartsWithChecker : IChecker
    {
        public RuleType Rule => RuleType.NameStartsWith;

        public InspectionItem Check(MemberInfo item, object paramValue)
        {
            var value = (string[])paramValue;

            if (!value.Any(x => item.Name.StartsWith(x)))
            {
                return InspectionItem.Create(false, $"Wrong member name {item.Name} in class {item.DeclaringType}");
            }
            return InspectionItem.Ok;
        }
    }
}
