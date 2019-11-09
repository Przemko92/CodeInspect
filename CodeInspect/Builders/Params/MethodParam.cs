using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeInspect.Builders.Interfaces;
using CodeInspect.Enums;
using CodeInspect.Models;

namespace CodeInspect.Builders.Params
{
    class MethodParam : BaseParam<IMethodParam>, IMethodParam, IBuildable
    {
        protected bool? _areVoid;
        protected int? _maxArgsCount;
        protected int? _minArgsCount;
        private INameParam _argsNameParam;
        public IMethodsInspectBuilder And { get; }

        public MethodParam(IMethodsInspectBuilder context) : base(context)
        {
            And = context;
            _argsNameParam = new ArgsNameParam();
        }

        public IMethodParam AreVoid()
        {
            _areVoid = true;
            return this;
        }

        public IMethodParam HasMoreArgsThan(int count)
        {
            _minArgsCount = count;
            return this;
        }

        public IMethodParam HasLessArgsThan(int count)
        {
            _maxArgsCount = count;
            return this;
        }

        public IMethodParam ParamsNameNotLongerThan(int length)
        {
            _argsNameParam.IsNotLongerThan(length);
            return this;
        }

        public IMethodParam ParamsNameIsNotShorterThan(int length)
        {
            _argsNameParam.IsNotShorterThan(length);
            return this;
        }

        public IMethodParam ParamsNameStartsWith(params string[] allowedTexts)
        {
            _argsNameParam.StartsWith(allowedTexts);
            return this;
        }

        public IMethodParam ParamsNameStartsWithCapitalLetter()
        {
            _argsNameParam.StartsWithCapitalLetter();
            return this;
        }

        public IMethodParam ParamsNameStartsWithLowerCase()
        {
            _argsNameParam.StartsWithLowerCase();
            return this;
        }

        public IMethodParam ParamsNameMatchRegex(params string[] regex)
        {
            _argsNameParam.MatchRegex();
            return this;
        }

        public IMethodParam ParamsNameNotStartsWith(params string[] notAllowedTexts)
        {
            _argsNameParam.NotStartsWith();
            return this;
        }


        public IMethodParam HasReturnType()
        {
            _areVoid = false;
            return this;
        }

        public ParamRule Build()
        {
            var rule = new ParamRule();
            if (_areForbidden.HasValue) rule.AddItem(RuleType.AreForbidden, _areForbidden);
            if (_validAttributes.Any()) rule.AddItem(RuleType.ValidAttributes, _validAttributes);
            if (_forbiddenAttributes.Any()) rule.AddItem(RuleType.InValidAttributes, _forbiddenAttributes);
            if (_areVoid.HasValue) rule.AddItem(RuleType.AreVoid, _areVoid);
            if (_minArgsCount.HasValue) rule.AddItem(RuleType.HasMoreArgsThan, _minArgsCount);
            if (_maxArgsCount.HasValue) rule.AddItem(RuleType.HasLessArgsThan, _maxArgsCount);
            rule.AddMany(((NameParam)_nameParam).Build());
            rule.AddMany(((ArgsNameParam)_argsNameParam).Build());
            return rule;
        }
    }
}
