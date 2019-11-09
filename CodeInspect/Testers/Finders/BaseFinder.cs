using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using CodeInspect.Attributes;
using CodeInspect.Testers.Interfaces;

namespace CodeInspect.Testers.Finders
{
    abstract class BaseFinder<T> : IFinder<T>
        where T : MemberInfo
    {
        private readonly Assembly[] _assemblies;
        private readonly string[] _namespaces;
        private readonly Type[] _types;
        private readonly IEnumerable<T> _specifiedMembers;

        public BaseFinder(Assembly[] assemblies, string[] namespaces, Type[] types, IEnumerable<T> specifiedMembers)
        {
            _assemblies = assemblies;
            _namespaces = namespaces;
            _types = types;
            _specifiedMembers = specifiedMembers;
        }

        public IEnumerable<T> GetItems()
        {
            IEnumerable<T> items = Enumerable.Empty<T>();

            if (_assemblies != null)
            {
                items = items.Concat(GetFromAssemblies());
            }

            if (_namespaces != null)
            {
                items = items.Concat(GetFromNamespaces());
            }

            if (_types != null)
            {
                items = items.Concat(GetFromTypes());
            }

            if (_specifiedMembers != null)
            {
                items = items.Concat(_specifiedMembers);
            }

            return items.Where(x => !x.CustomAttributes.Any(a => a.AttributeType.Equals(typeof(CodeInspectIgnoreAttribute)) || a.AttributeType.Equals(typeof(CompilerGeneratedAttribute))));
        }

        private IEnumerable<T> GetFromTypes()
        {
            return _types.SelectMany(x => GetMembers(x));
        }

        private IEnumerable<T> GetFromNamespaces()
        {
            IEnumerable<T> items = Enumerable.Empty<T>();

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var @namespace in _namespaces)
                {
                    try
                    {
                        items = items.Concat(assembly.GetTypes().Where(x => x.Namespace.Equals(@namespace)).SelectMany(x => GetMembers(x)).ToList());
                    }
                    catch (Exception) { } //Some system assemblies cannot be used this way
                }
            }

            return items;
        }

        private IEnumerable<T> GetFromAssemblies()
        {
            IEnumerable<T> items = Enumerable.Empty<T>();

            foreach (var assembly in _assemblies)
            {
                items = items.Concat(assembly.GetTypes().SelectMany(x => GetMembers(x))).ToList();
            }

            return items;
        }

        protected abstract IEnumerable<T> GetMembers(Type type);
    }
}
