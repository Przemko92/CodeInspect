using System;
using System.Collections.Generic;
using System.Text;
using CodeInspect.Builders.Interfaces;
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
            throw new NotImplementedException();
        }
    }
}
