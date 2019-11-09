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
    class MaxPropertiesChecker : IChecker
    {
        public RuleType Rule => RuleType.MaxProperties;

        public InspectionItem Check(MemberInfo item, object paramValue)
        {
            var type = (TypeInfo) item;
            var value = (int) paramValue;

            if (type.DeclaredProperties.Count() > value)
            {
                return InspectionItem.Create(item, false, $"Type {item.Name} has too much properties");
            }
            return InspectionItem.Ok(item);
        }
    }
}
