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
    class ParamsNameNotLongerChecker : IChecker
    {
        public RuleType Rule => RuleType.ParamNameNotLongerThan;

        public InspectionItem Check(MemberInfo item, object paramValue)
        {
            var value = (int)paramValue;
            var method = (MethodInfo)item;

            if (method.GetParameters().Any(x => x.Name.Length > value))
            {
                return InspectionItem.Create(item, false, $"Too long argument name in {item.Name} in class {item.DeclaringType}");
            }
            return InspectionItem.Ok(item);
        }
    }
}
