using System;
using System.Collections.Generic;
using System.Text;

namespace CodeInspect.Enums
{
    enum RuleType
    {
        ValidAttributes,
        InValidAttributes,
        NameNotLongerThan,
        NameNotShorterThan,
        NameStartsWith,
        NameStartsWithLowerCase,
        NameNotStartsWith,
        NameMatchRegex,
        AreVoid,
        HasMoreArgsThan,
        HasLessArgsThan,
        ParamNameNotLongerThan,
        ParamNameNotShorterThan,
        ParamNameStartsWith,
        ParamNameStartsWithLowerCase,
        ParamNameNotStartsWith,
        ParamNameMatchRegex,
        AreForbidden,
        Inherits,
        Implements,
        MaxMethods,
        MaxProperties,
        ParamNameEndsWith,
        ParamNameNotEndsWith,
        NameEndsWith,
        NameNotEndsWith
    }
}
