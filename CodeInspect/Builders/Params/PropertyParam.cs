using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeInspect.Builders.Interfaces;
using CodeInspect.Enums;
using CodeInspect.Models;

namespace CodeInspect.Builders.Params
{
    class PropertyParam : BaseParam<IPropertyParam>, IPropertyParam, IBuildable
    {
        private PropertyOptions _hasSetter;
        private PropertyOptions _hasGetter;
        public IPropertiesInspectBuilder And { get; }

        public PropertyParam(IPropertiesInspectBuilder context) : base(context)
        {
            And = context;
        }

        
        public IPropertyParam HasSetter(bool value, bool includePrivate = true)
        {
            _hasSetter = new PropertyOptions(value, includePrivate);
            return this;
        }

        public IPropertyParam HasGetter(bool value, bool includePrivate = true)
        {
            _hasGetter = new PropertyOptions(value, includePrivate);
            return this;
        }


        public ParamRule Build()
        {
            var rule = new ParamRule();
            if (_areForbidden.HasValue) rule.AddItem(RuleType.AreForbidden, _areForbidden);
            if (_validAttributes.Any()) rule.AddItem(RuleType.ValidAttributes, _validAttributes);
            if (_forbiddenAttributes.Any()) rule.AddItem(RuleType.InValidAttributes, _forbiddenAttributes);
            if (_hasGetter != null) rule.AddItem(RuleType.HasGetter, _hasGetter);
            if (_hasSetter != null) rule.AddItem(RuleType.HasSetter, _hasSetter);
            rule.AddMany(((NameParam)_nameParam).Build());
            return rule;
        }
    }
}
