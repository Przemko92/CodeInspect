using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CodeInspect.Enums;

namespace CodeInspect.Models
{
    class ParamRule : IReadOnlyCollection<KeyValuePair<RuleType, object>>
    {
        private IDictionary<RuleType, object> _rulesDictionary;

        public ParamRule()
        {
            _rulesDictionary = new Dictionary<RuleType, object>();
        }

        public IEnumerator<KeyValuePair<RuleType, object>> GetEnumerator()
        {
            return _rulesDictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count => _rulesDictionary.Count;

        public void AddItem(RuleType ruleType, object arg)
        {
            _rulesDictionary.Add(ruleType, arg);
        }

        public void AddMany(IEnumerable<KeyValuePair<RuleType, object>> items)
        {
            foreach (var item in items)
            {
                AddItem(item.Key, item.Value);
            }
        }
    }
}
