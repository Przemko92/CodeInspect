using System;
using CodeInspect.Builders;
using CodeInspect.Builders.Interfaces;

namespace CodeInspect
{
    public static class Inspect
    {
        public static ITypeInspectBuilder AllTypes()
        {
            return new TypeInspectBuilder();
        }

        public static IMethodsInspectBuilder AllMethods()
        {
            return new MethodInspectBuilder();
        }

        public static IPropertiesInspectBuilder AllProperties()
        {
            return new PropertyInspectBuilder();
        }

        public static IFieldsInspectBuilder AllFields()
        {
            return new FieldsInspectBuilder();
        }
    }
}
