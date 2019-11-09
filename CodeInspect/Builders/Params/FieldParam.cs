using System.Linq;
using CodeInspect.Builders.Interfaces;
using CodeInspect.Enums;
using CodeInspect.Models;

namespace CodeInspect.Builders.Params
{
    class FieldParam : BaseParam<IFieldParam>, IFieldParam, IBuildable
    {
        public IFieldsInspectBuilder And { get; }

        public FieldParam(IFieldsInspectBuilder context)
            : base (context)
        {
            And = context;
        }

        public ParamRule Build()
        {
            var rule = new ParamRule();
            if (_areForbidden.HasValue) rule.AddItem(RuleType.AreForbidden, _areForbidden);
            if (_validAttributes.Any()) rule.AddItem(RuleType.ValidAttributes, _validAttributes);
            if (_forbiddenAttributes.Any()) rule.AddItem(RuleType.InValidAttributes, _forbiddenAttributes);
            rule.AddMany(((NameParam)_nameParam).Build());
            return rule;
        }
    }
}
