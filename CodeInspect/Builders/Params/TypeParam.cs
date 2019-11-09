using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeInspect.Builders.Interfaces;
using CodeInspect.Enums;
using CodeInspect.Models;

namespace CodeInspect.Builders.Params
{
    class TypeParam : BaseParam<ITypeParam>, ITypeParam, IBuildable
    {
        protected ICollection<Type> _implementTypes;
        protected Type _inherits;
        protected int? _maxAllowedMethods;
        protected int? _maxAllowedProperties;
        public ITypeInspectBuilder And { get; }

        public TypeParam(ITypeInspectBuilder context) : base(context)
        {
            And = context;
            _implementTypes = new List<Type>();
        }

        public ITypeParam Implements<T>()
        {
            return Implements(typeof(T));
        }

        public ITypeParam Implements(params Type[] types)
        {
            foreach (var type in types)
            {
                if (!type.IsInterface)
                {
                    throw new ArgumentException(nameof(type));
                }
                _implementTypes.Add(type);
            }

            return this;
        }

        public ITypeParam Inherits<T>()
        {
            return Inherits(typeof(T));
        }

        public ITypeParam Inherits(Type type)
        {
            if (!type.IsClass)
            {
                throw new ArgumentException(nameof(type));
            }
            _inherits = type;
            return this;
        }

        public ITypeParam HasNotMoreMethodsThan(int count)
        {
            _maxAllowedMethods = count;
            return this;
        }

        public ITypeParam HasNotMorePropertiesThan(int count)
        {
            _maxAllowedProperties = count;
            return this;
        }

        public ParamRule Build()
        {
            var rule = new ParamRule();
            if (_areForbidden.HasValue) rule.AddItem(RuleType.AreForbidden, _areForbidden);
            if (_validAttributes.Any()) rule.AddItem(RuleType.ValidAttributes, _validAttributes);
            if (_forbiddenAttributes.Any()) rule.AddItem(RuleType.InValidAttributes, _forbiddenAttributes);
            if (_inherits != null) rule.AddItem(RuleType.Inherits, _inherits);
            if (_implementTypes.Any()) rule.AddItem(RuleType.Implements, _implementTypes);
            if (_maxAllowedMethods.HasValue) rule.AddItem(RuleType.MaxMethods, _maxAllowedMethods);
            if (_maxAllowedProperties.HasValue) rule.AddItem(RuleType.MaxProperties, _maxAllowedProperties);
            rule.AddMany(((NameParam)_nameParam).Build());
            return rule;
        }
    }
}
