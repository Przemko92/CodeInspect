using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CodeInspect.Helpers
{
    static class PropertyInfoExtenssions
    {
        public static bool IsPrivate(this PropertyInfo property)
        {
            return property.GetMethod.IsPrivate && property.SetMethod.IsPrivate;
        }

        public static bool IsProtected(this PropertyInfo property)
        {
            bool getMethodProtected = property.GetMethod.IsFamily;
            bool setMethodProtected = property.SetMethod.IsFamily;

            if (property.GetMethod.IsPublic || property.SetMethod.IsPublic || property.GetMethod.IsAssembly || property.SetMethod.IsAssembly)
            {
                return false;
            }

            return getMethodProtected || setMethodProtected;
        }

        public static bool IsInternal(this PropertyInfo property)
        {
            bool getMethodInternal = property.GetMethod.IsAssembly;
            bool setMethodInternal = property.SetMethod.IsAssembly;

            if (property.GetMethod.IsPublic || property.SetMethod.IsPublic)
            {
                return false;
            }

            return getMethodInternal || setMethodInternal;
        }

        public static bool IsPublic(this PropertyInfo property)
        {
            return property.GetMethod.IsPublic || property.SetMethod.IsPublic;
        }

        public static bool IsStatic(this PropertyInfo property)
        {
            return property.GetMethod.IsStatic || property.SetMethod.IsStatic;
        }
    }
}
