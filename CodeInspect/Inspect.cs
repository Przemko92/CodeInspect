using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CodeInspect.Builders;
using CodeInspect.Builders.Interfaces;

namespace CodeInspect
{
    public static class Inspect
    {
        public static ITypeInspectBuilder AllTypes => new TypeInspectBuilder();
        public static IMethodsInspectBuilder AllMethods => new MethodInspectBuilder();
        public static IPropertiesInspectBuilder AllProperties => new PropertyInspectBuilder();
        public static IFieldsInspectBuilder AllFields => new FieldsInspectBuilder();
    }
}
