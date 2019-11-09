using System;
using System.Collections.Generic;
using System.Reflection;

namespace CodeInspect.Testers.Finders
{
    class PropertiesFinder : BaseFinder<PropertyInfo>
    {
        public PropertiesFinder(Assembly[] assemblies, string[] namespaces, Type[] types) : base(assemblies, namespaces, types)
        {
        }

        protected override IEnumerable<PropertyInfo> GetMembers(Type type)
        {
            return type.GetTypeInfo().DeclaredProperties;
        }
    }
}
