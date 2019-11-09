using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeInspect.Builders.Interfaces;
using CodeInspect.Enums;

namespace CodeInspect.Builders.Params
{
    class NameParam : INameParam
    {
        private int? _notLongerThan;
        private int? _notShorterThan;
        private string[] _startsWith = new string[0];
        private bool? _startWithLowerCase;
        private string[] _notStartsWith = new string[0];
        private string[] _matchRegex = new string[0];
        private string[] _endsWith = new string[0];
        private string[] _notEndsWith = new string[0];

        public INameParam IsNotLongerThan(int length)
        {
            _notLongerThan = length;
            return this;
        }

        public INameParam IsNotShorterThan(int length)
        {
            _notShorterThan = length;
            return this;
        }

        public INameParam StartsWith(params string[] allowedTexts)
        {
            _startsWith = allowedTexts;
            return this;
        }

        public INameParam StartsWithCapitalLetter()
        {
            _startWithLowerCase = false;
            return this;
        }

        public INameParam StartsWithLowerCase()
        {
            _startWithLowerCase = true;
            return this;
        }

        public INameParam EndsWith(string[] allowedTexts)
        {
            _endsWith = allowedTexts;
            return this;
        }

        public INameParam NotEndsWith(string[] notAllowedTexts)
        {
            _notEndsWith = notAllowedTexts;
            return this;
        }

        public INameParam MatchRegex(params string[] regex)
        {
            _matchRegex = regex;
            return this;
        }

        public INameParam NotStartsWith(params string[] notAllowedTexts)
        {
            _notStartsWith = notAllowedTexts;
            return this;
        }

        public IEnumerable<KeyValuePair<RuleType, object>> Build()
        {
            if (_notLongerThan.HasValue) yield return new KeyValuePair<RuleType, object>(RuleType.NameNotLongerThan, _notLongerThan);
            if (_notShorterThan.HasValue) yield return new KeyValuePair<RuleType, object>(RuleType.NameNotShorterThan, _notShorterThan);
            if (_startsWith.Any()) yield return new KeyValuePair<RuleType, object>(RuleType.NameStartsWith, _startsWith);
            if (_startWithLowerCase.HasValue) yield return new KeyValuePair<RuleType, object>(RuleType.NameStartsWithLowerCase, _startWithLowerCase);
            if (_notStartsWith.Any()) yield return new KeyValuePair<RuleType, object>(RuleType.NameNotStartsWith, _notStartsWith);
            if (_matchRegex.Any()) yield return new KeyValuePair<RuleType, object>(RuleType.NameMatchRegex, _matchRegex);
            if (_endsWith.Any()) yield return new KeyValuePair<RuleType, object>(RuleType.NameEndsWith, _matchRegex);
            if (_notEndsWith.Any()) yield return new KeyValuePair<RuleType, object>(RuleType.NameNotEndsWith, _matchRegex);
        }
    }
}
