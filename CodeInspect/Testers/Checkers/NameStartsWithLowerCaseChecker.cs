using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using CodeInspect.Enums;
using CodeInspect.Models;
using CodeInspect.Testers.Interfaces;

namespace CodeInspect.Testers.Checkers
{
    class NameStartsWithLowerCaseChecker : IChecker
    {
        public RuleType Rule => RuleType.NameStartsWithLowerCase;

        public InspectionItem Check(MemberInfo item, object paramValue)
        {
            var value = (bool)paramValue;

            if (value && !char.IsLower(item.Name[0]))
            {
                return InspectionItem.Create(false, $"Wrong member name {item.Name} in class {item.DeclaringType}");
            }

            return InspectionItem.Ok;
        }
    }
}
