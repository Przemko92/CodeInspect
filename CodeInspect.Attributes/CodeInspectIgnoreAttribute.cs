using System;
using System.Collections.Generic;
using System.Text;

namespace CodeInspect.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Constructor | AttributeTargets.Method)]
    public class CodeInspectIgnoreAttribute : Attribute
    {
    }
}
