using System;
using System.Collections.Generic;
using System.Reflection;

namespace CodeInspect.Testers.Finders
{
    class TypesFinder : BaseFinder<TypeInfo>
    {
        public TypesFinder(Assembly[] assemblies, string[] namespaces, Type[] types, IEnumerable<TypeInfo> specifiedMembers) : base(assemblies, namespaces, types, specifiedMembers)
        {
        }

        protected override IEnumerable<TypeInfo> GetMembers(Type type)
        {
            yield return type.GetTypeInfo();
        }
    }
}
