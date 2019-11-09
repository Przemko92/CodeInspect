using System;
using System.Collections.Generic;
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
using CodeInspect.Testers.Interfaces;

namespace CodeInspect.Builders
{
    class TypeInspectBuilder : BaseInspectBuilder<ITypeInspectBuilder>, ITypeInspectBuilder
    {
        private IDictionary<Modifier, ITypeParam> _typesParams = new Dictionary<Modifier, ITypeParam>();
        
        public ITypeParam AllNotSpecified => GetTypeParam(Modifier.NotSet);

        public ITypeParam EnumTypes => GetTypeParam(Modifier.Enum);
        public ITypeParam InterfaceTypes => GetTypeParam(Modifier.Interface);
        public ITypeParam AbstractTypes => GetTypeParam(Modifier.Abstract);
        public ITypeParam PublicTypes => GetTypeParam(Modifier.Public);
        public ITypeParam NonPublicTypes => GetTypeParam(Modifier.Internal);
        public ITypeParam ClassTypes => GetTypeParam(Modifier.Class);


        private ITypeParam GetTypeParam(Modifier modifier)
        {
            if (!_typesParams.ContainsKey(modifier))
            {
                _typesParams.Add(modifier, new TypeParam(this));
            }

            return _typesParams[modifier];
        }

        protected override void PrepareTest()
        {
            _inspector = new TypesInspector(_typesParams, new TypesFinder(_searchAssemblies, _searchNamespaces, _searchTypes));
        }
    }
}
