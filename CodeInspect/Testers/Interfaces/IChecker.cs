using System.Collections.Generic;
using System.Reflection;
using CodeInspect.Enums;
using CodeInspect.Models;

namespace CodeInspect.Testers.Interfaces
{
    interface IChecker
    {
        RuleType Rule { get; }
        InspectionItem Check(MemberInfo item, object paramValue);
    }
}