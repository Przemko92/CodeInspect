using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using CodeInspect.Enums;
using CodeInspect.Models;
using CodeInspect.Testers.Interfaces;

namespace CodeInspect.Testers.Checkers
{
    class HasLessArgsThanChecker : IChecker
    {
        public RuleType Rule => RuleType.HasLessArgsThan;

        public InspectionItem Check(MemberInfo item, object paramValue)
        {
            var value = (int) paramValue;
            var method = (MethodInfo) item;
            if (method.GetParameters().Length > value)
            {
                return InspectionItem.Create(item, false,
                    $"Too much args in method {method.Name} in class {item.DeclaringType}");
            }

            return InspectionItem.Ok(item);
        }
    }
}