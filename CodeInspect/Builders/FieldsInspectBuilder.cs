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

namespace CodeInspect.Builders
{
    class FieldsInspectBuilder : BaseInspectBuilder<IFieldsInspectBuilder>, IFieldsInspectBuilder
    {
        private IDictionary<Modifier, IFieldParam> _fieldsParams = new Dictionary<Modifier, IFieldParam>();

        public IFieldParam AllFields => GetFieldsParam(Modifier.All);
        public IFieldParam AllNotSpecified => GetFieldsParam(Modifier.NotSet);

        public IFieldParam PrivateFields => GetFieldsParam(Modifier.Private);
        public IFieldParam ProtectedFields => GetFieldsParam(Modifier.Protected);
        public IFieldParam InternalFields => GetFieldsParam(Modifier.Internal);
        public IFieldParam PublicFields => GetFieldsParam(Modifier.Public);

        public IFieldParam StaticPrivateFields => GetFieldsParam(Modifier.Private | Modifier.Static);
        public IFieldParam StaticProtectedFields => GetFieldsParam(Modifier.Protected | Modifier.Static);
        public IFieldParam StaticInternalFields => GetFieldsParam(Modifier.Internal | Modifier.Static);
        public IFieldParam StaticPublicFields => GetFieldsParam(Modifier.Public | Modifier.Static);

        private IFieldParam GetFieldsParam(Modifier modifier)
        {
            if (!_fieldsParams.ContainsKey(modifier))
            {
                _fieldsParams.Add(modifier, new FieldParam(this));
            }

            return _fieldsParams[modifier];
        }

        public IFieldsInspectBuilder ThisItems(IEnumerable<FieldInfo> fields)
        {
            _specifiedMembers = fields.ToArray();
            return this;
        }

        public FieldsInspectBuilder()
        {
            
        }

        protected override void PrepareTest()
        {
            _inspector = new FieldsInspector(_fieldsParams, new FieldsFinder(_searchAssemblies, _searchNamespaces, _searchTypes, _specifiedMembers.Cast<FieldInfo>()));
        }
    }
}
