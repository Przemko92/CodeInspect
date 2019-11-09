using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CodeInspect.Testers.Finders
{
    class MethodsFinder : BaseFinder<MethodInfo>
    {
        public MethodsFinder(Assembly[] assemblies, string[] namespaces, Type[] types) : base(assemblies, namespaces, types)
        {
        }

        protected override IEnumerable<MethodInfo> GetMembers(Type type)
        {
            return type.GetTypeInfo().DeclaredMethods.Where(x => !x.IsSpecialName);
        }
    }
}
