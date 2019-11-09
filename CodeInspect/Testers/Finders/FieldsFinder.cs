using System;
using System.Collections.Generic;
using System.Reflection;

namespace CodeInspect.Testers.Finders
{
    internal class FieldsFinder : BaseFinder<FieldInfo>
    {
        public FieldsFinder(Assembly[] assemblies, string[] namespaces, Type[] types, IEnumerable<FieldInfo> specifiedMembers) : base(assemblies, namespaces, types, specifiedMembers)
        {
        }


        protected override IEnumerable<FieldInfo> GetMembers(Type type)
        {
            return type.GetTypeInfo().DeclaredFields;
        }
    }
}