using System;
using System.Collections.Generic;
using System.Reflection;

namespace CodeInspect.Testers.Finders
{
    class TypesFinder : BaseFinder<TypeInfo>
    {
        public TypesFinder(Assembly[] assemblies, string[] namespaces, Type[] types) : base(assemblies, namespaces, types)
        {
        }

        protected override IEnumerable<TypeInfo> GetMembers(Type type)
        {
            yield return type.GetTypeInfo();
        }
    }
}
