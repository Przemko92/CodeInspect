using System;
using System.Collections.Generic;
using System.Reflection;

namespace CodeInspect.Testers.Finders
{
    class PropertiesFinder : BaseFinder<PropertyInfo>
    {
        public PropertiesFinder(Assembly[] assemblies, string[] namespaces, Type[] types, IEnumerable<PropertyInfo> specifiedMembers) : base(assemblies, namespaces, types, specifiedMembers)
        {
        }

        protected override IEnumerable<PropertyInfo> GetMembers(Type type)
        {
            return type.GetTypeInfo().DeclaredProperties;
        }
    }
}
