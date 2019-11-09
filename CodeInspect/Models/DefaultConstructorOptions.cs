using System;
using System.Collections.Generic;
using System.Text;

namespace CodeInspect.Models
{
    class DefaultConstructorOptions
    {
        public bool HasConstructor { get; }
        public bool IncluePrivate { get; }

        public DefaultConstructorOptions(bool hasConstructor, bool incluePrivate)
        {
            HasConstructor = hasConstructor;
            IncluePrivate = incluePrivate;
        }
    }
}
