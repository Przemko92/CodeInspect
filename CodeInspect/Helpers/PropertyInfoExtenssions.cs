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
            if (property.GetMethod == null)
            {
                return property.SetMethod.IsPrivate;
            }

            if (property.SetMethod == null)
            {
                return property.GetMethod.IsPrivate;
            }
            return property.GetMethod.IsPrivate && property.SetMethod.IsPrivate;
        }

        public static bool IsProtected(this PropertyInfo property)
        {
            if (property.GetMethod == null)
            {
                return property.SetMethod.IsFamily;
            }

            if (property.SetMethod == null)
            {
                return property.GetMethod.IsFamily;
            }

            if (property.GetMethod.IsPublic || property.SetMethod.IsPublic || property.GetMethod.IsAssembly || property.SetMethod.IsAssembly)
            {
                return false;
            }

            bool getMethodProtected = property.GetMethod.IsFamily;
            bool setMethodProtected = property.SetMethod.IsFamily;

            return getMethodProtected || setMethodProtected;
        }

        public static bool IsInternal(this PropertyInfo property)
        {
            if (property.GetMethod == null)
            {
                return property.SetMethod.IsAssembly;
            }

            if (property.SetMethod == null)
            {
                return property.GetMethod.IsAssembly;
            }

            if (property.GetMethod.IsPublic || property.SetMethod.IsPublic)
            {
                return false;
            }

            bool getMethodInternal = property.GetMethod.IsAssembly;
            bool setMethodInternal = property.SetMethod.IsAssembly;

            return getMethodInternal || setMethodInternal;
        }

        public static bool IsPublic(this PropertyInfo property)
        {
            if (property.GetMethod == null)
            {
                return property.SetMethod.IsPublic;
            }

            if (property.SetMethod == null)
            {
                return property.GetMethod.IsPublic;
            }

            return property.GetMethod.IsPublic || property.SetMethod.IsPublic;
        }

        public static bool IsStatic(this PropertyInfo property)
        {
            if (property.GetMethod == null)
            {
                return property.SetMethod.IsStatic;
            }

            if (property.SetMethod == null)
            {
                return property.GetMethod.IsStatic;
            }

            return property.GetMethod.IsStatic || property.SetMethod.IsStatic;
        }
    }
}
