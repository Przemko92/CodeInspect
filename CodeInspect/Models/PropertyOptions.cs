using System;
using System.Collections.Generic;
using System.Text;

namespace CodeInspect.Models
{
    class PropertyOptions
    {
        public bool Value { get; }
        public bool IncludePrivate { get; }

        public PropertyOptions(bool value, bool includePrivate)
        {
            Value = value;
            IncludePrivate = includePrivate;
        }
    }
}
