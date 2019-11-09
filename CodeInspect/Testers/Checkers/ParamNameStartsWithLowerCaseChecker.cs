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
    class ParamNameStartsWithLowerCaseChecker : IChecker
    {
        public RuleType Rule => RuleType.ParamNameStartsWithLowerCase;

        public InspectionItem Check(MemberInfo item, object paramValue)
        {
            var value = (bool)paramValue;
            var method = (MethodInfo)item;

            if (value && method.GetParameters().Any(x => !char.IsLower(x.Name[0])))
            {
                return InspectionItem.Create(item, false, $"Wrong argument name in {item.Name} in class {item.DeclaringType}");
            }
            else if (!value && method.GetParameters().Any(x => char.IsLower(x.Name[0])))
            {
                return InspectionItem.Create(item, false, $"Wrong argument name in {item.Name} in class {item.DeclaringType}");
            }
            return InspectionItem.Ok(item);
        }
    }
}
