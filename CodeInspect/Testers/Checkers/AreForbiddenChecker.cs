using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using CodeInspect.Enums;
using CodeInspect.Models;
using CodeInspect.Testers.Interfaces;

namespace CodeInspect.Testers.Checkers
{
    class AreForbiddenChecker : IChecker
    {
        public RuleType Rule => RuleType.AreForbidden;

        public InspectionItem Check(MemberInfo item, object paramValue)
        {
            var value = (bool) paramValue;
            if (value)
            {
                string message = item.DeclaringType != null ?
                    $"Forbidden item {item.Name} in class {item.DeclaringType}" :
                    $"Forbidden item {item.Name}";

                return InspectionItem.Create(false, message);
            }
            return InspectionItem.Ok;
        }
    }
}
