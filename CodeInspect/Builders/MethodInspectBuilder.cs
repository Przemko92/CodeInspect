using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CodeInspect.Builders.Interfaces;
using CodeInspect.Builders.Params;
using CodeInspect.Enums;
using CodeInspect.Models;
using CodeInspect.Models.Exceptions;
using CodeInspect.Testers;
using CodeInspect.Testers.Finders;
using CodeInspect.Testers.Inspectors;

namespace CodeInspect.Builders
{
    class MethodInspectBuilder : BaseInspectBuilder<IMethodsInspectBuilder>, IMethodsInspectBuilder
    {
        private IDictionary<Modifier, IMethodParam> _methodsParams = new Dictionary<Modifier, IMethodParam>();

        public IMethodParam AllMethods => GetMethodsParam(Modifier.All);
        public IMethodParam AllNotSpecified => GetMethodsParam(Modifier.NotSet);

        public IMethodParam PrivateMethods => GetMethodsParam(Modifier.Private);
        public IMethodParam ProtectedMethods => GetMethodsParam(Modifier.Protected);
        public IMethodParam InternalMethods => GetMethodsParam(Modifier.Internal);
        public IMethodParam PublicMethods => GetMethodsParam(Modifier.Public);

        public IMethodParam StaticPrivateMethods => GetMethodsParam(Modifier.Private | Modifier.Static);
        public IMethodParam StaticProtectedMethods => GetMethodsParam(Modifier.Protected | Modifier.Static);
        public IMethodParam StaticInternalMethods => GetMethodsParam(Modifier.Internal | Modifier.Static);
        public IMethodParam StaticPublicMethods => GetMethodsParam(Modifier.Public | Modifier.Static);

        private IMethodParam GetMethodsParam(Modifier modifier)
        {
            if (!_methodsParams.ContainsKey(modifier))
            {
                _methodsParams.Add(modifier, new MethodParam(this));
            }

            return _methodsParams[modifier];
        }

        public IMethodsInspectBuilder ThisItems(IEnumerable<MethodInfo> methods)
        {
            _specifiedMembers = methods.ToArray();
            return this;
        }

        public MethodInspectBuilder()
        {
            
        }

        protected override void PrepareTest()
        {
            _inspector = new MethodsInspector(_methodsParams, new MethodsFinder(_searchAssemblies, _searchNamespaces, _searchTypes, _specifiedMembers.Cast<MethodInfo>()));
        }
    }
}
