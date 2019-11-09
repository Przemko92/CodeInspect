using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using CodeInspect.Enums;
using CodeInspect.Models;
using CodeInspect.Testers.Interfaces;

namespace CodeInspect.Testers.Checkers
{
    class IsVoidChecker : IChecker
    {
        public RuleType Rule => RuleType.AreVoid;

        public InspectionItem Check(MemberInfo item, object paramValue)
        {
            var value = (bool)paramValue;
            var method = (MethodInfo) item;

            if (value && method.ReturnType.FullName != "System.Void")
            {
                return InspectionItem.Create(item, false, $"Member {item.Name} in class {item.DeclaringType} is not void");
            }
            else if (!value && method.ReturnType.FullName == "System.Void")
            {
                return InspectionItem.Create(item, false, $"Member {item.Name} in class {item.DeclaringType} is void");
            }

            return InspectionItem.Ok(item);
        }
    }
}
