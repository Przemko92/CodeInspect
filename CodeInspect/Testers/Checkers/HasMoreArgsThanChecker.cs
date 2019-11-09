using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using CodeInspect.Enums;
using CodeInspect.Models;
using CodeInspect.Testers.Interfaces;

namespace CodeInspect.Testers.Checkers
{
    class HasMoreArgsThanChecker : IChecker
    {
        public RuleType Rule => RuleType.HasMoreArgsThan;

        public InspectionItem Check(MemberInfo item, object paramValue)
        {
            var value = (int) paramValue;
            var method = (MethodInfo) item;
            if (method.GetParameters().Length <= value)
            {
                return InspectionItem.Create(false,
                    $"Too less args in method {method.Name} in class {item.DeclaringType}");
            }

            return InspectionItem.Ok;
        }
    }
}