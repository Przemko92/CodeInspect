using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using CodeInspect.Builders.Interfaces;
using CodeInspect.Models;
using CodeInspect.Models.Exceptions;
using CodeInspect.Testers;
using CodeInspect.Testers.Interfaces;

namespace CodeInspect.Builders
{
    abstract class BaseInspectBuilder<T> : IInspectBuilder<T>
        where T : class
    {
        protected IInspector _inspector;
        protected Assembly[] _searchAssemblies;
        protected Type[] _searchTypes;
        protected string[] _searchNamespaces;
        protected bool _throwOnError;

        public BaseInspectBuilder()
        {
            _throwOnError = false;
        }

        public virtual T InAssemblies(params Assembly[] assemblies)
        {
            _searchAssemblies = assemblies;
            return this as T;
        }

        public virtual T InTypes(params Type[] types)
        {
            _searchTypes = types;
            return this as T;
        }

        public virtual T InNamespaces(params string[] namespaces)
        {
            _searchNamespaces = namespaces;
            return this as T;
        }

        public virtual T ThrowOnError()
        {
            _throwOnError = true;
            return this as T;
        }

        public InspectionResult Test()
        {
            PrepareTest();
            _inspector.Init();
            var result = _inspector.Run();
            if (!result.IsOk && _throwOnError)
            {
                throw new MethodsValidationException(result);
            }

            return result;
        }

        protected abstract void PrepareTest();
    }
}
