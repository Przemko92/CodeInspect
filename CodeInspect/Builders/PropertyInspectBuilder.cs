using System;
using System.Collections.Generic;
using System.Text;
using CodeInspect.Builders.Interfaces;
using CodeInspect.Builders.Params;
using CodeInspect.Enums;
using CodeInspect.Testers;
using CodeInspect.Testers.Finders;
using CodeInspect.Testers.Inspectors;

namespace CodeInspect.Builders
{
    class PropertyInspectBuilder : BaseInspectBuilder<IPropertiesInspectBuilder>, IPropertiesInspectBuilder
    {
        private IDictionary<Modifier, IPropertyParam> _propertiesParams = new Dictionary<Modifier, IPropertyParam>();

        public IPropertyParam AllNotSpecified => GetPropertiesParam(Modifier.NotSet);

        public IPropertyParam PrivateProperties => GetPropertiesParam(Modifier.Private);
        public IPropertyParam ProtectedProperties => GetPropertiesParam(Modifier.Protected);
        public IPropertyParam InternalProperties => GetPropertiesParam(Modifier.Internal);
        public IPropertyParam PublicProperties => GetPropertiesParam(Modifier.Public);

        public IPropertyParam StaticPrivateProperties => GetPropertiesParam(Modifier.Private | Modifier.Static);
        public IPropertyParam StaticProtectedProperties => GetPropertiesParam(Modifier.Protected | Modifier.Static);
        public IPropertyParam StaticInternalProperties => GetPropertiesParam(Modifier.Internal | Modifier.Static);
        public IPropertyParam StaticPublicProperties => GetPropertiesParam(Modifier.Public | Modifier.Static);

        private IPropertyParam GetPropertiesParam(Modifier modifier)
        {
            if (!_propertiesParams.ContainsKey(modifier))
            {
                _propertiesParams.Add(modifier, new PropertyParam(this));
            }

            return _propertiesParams[modifier];
        }

        protected override void PrepareTest()
        {
            _inspector = new PropertiesInspector(_propertiesParams, new PropertiesFinder(_searchAssemblies, _searchNamespaces, _searchTypes));
        }
    }
}
