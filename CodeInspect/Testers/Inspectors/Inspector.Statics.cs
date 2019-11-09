using System;
using System.Collections.Generic;
using System.Linq;
using CodeInspect.Enums;
using CodeInspect.Testers.Interfaces;

namespace CodeInspect.Testers.Inspectors
{
    abstract partial class Inspector<T>
    {
        protected static IDictionary<RuleType, IChecker> _checkers = new Dictionary<RuleType, IChecker>();
        static Inspector()
        {
            var checkers = typeof(Inspector<>).Assembly.GetTypes().Where(x => typeof(IChecker).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);
            foreach (var checker in checkers)
            {
                var checkerInstance = (IChecker)Activator.CreateInstance(checker);
                _checkers.Add(checkerInstance.Rule, checkerInstance);
            }
        }

        public static ICollection<IChecker> GetCheckers()
        {
            return _checkers.Values;
        }
    }
}
