using System;

namespace CodeInspect.Enums
{
    [Flags]
    public enum Modifier
    {
        NotSet = 0,
        Private = 1 << 0,
        Protected = 1 << 1,
        Internal = 1 << 2,
        Public = 1 << 3,
        Static = 1 << 4,
        Abstract = 1 << 5,
        Interface = 1 << 6,
        Enum = 1 << 7,
        Class = 1 << 8,
        All = 1 << 15
    }
}
