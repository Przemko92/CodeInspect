﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CodeInspect.Enums;
using CodeInspect.Models;
using CodeInspect.Testers.Interfaces;

namespace CodeInspect.Testers.Checkers
{
    class ParamsNameIsNotShorterChecker : IChecker
    {
        public RuleType Rule => RuleType.ParamNameNotShorterThan;

        public InspectionItem Check(MemberInfo item, object paramValue)
        {
            var value = (int)paramValue;
            var method = (MethodInfo) item;

            if (method.GetParameters().Any(x => x.Name.Length < value))
            {
                return InspectionItem.Create(false, $"Too short argument name in {item.Name} in class {item.DeclaringType}");
            }
            return InspectionItem.Ok;
        }
    }
}
