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
    class NameEndsWithChecker : IChecker
    {
        public RuleType Rule => RuleType.NameEndsWith;

        public InspectionItem Check(MemberInfo item, object paramValue)
        {
            var value = (string[])paramValue;

            if (!value.Any(x => item.Name.EndsWith(x)))
            {
                string message = item.DeclaringType != null ?
                    $"Wrong member name {item.Name} in class {item.DeclaringType}" :
                    $"Wrong member name {item.Name}";

                return InspectionItem.Create(false, message);
            }
            return InspectionItem.Ok;
        }
    }
}
