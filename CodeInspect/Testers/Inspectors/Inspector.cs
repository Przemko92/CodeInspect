using System;
using System.Collections.Generic;
using System.Reflection;
using CodeInspect.Builders.Interfaces;
using CodeInspect.Enums;
using CodeInspect.Models;
using CodeInspect.Testers.Interfaces;

namespace CodeInspect.Testers.Inspectors
{
    abstract partial class Inspector<T> : IInspector
        where T : class, IParam
    {
        protected readonly IDictionary<Modifier, T> _paramsToCheck;
        protected readonly IFinder<MemberInfo> _itemsFinder;
        protected IEnumerable<MemberInfo> _itemsToInspect;

        public Inspector(IDictionary<Modifier, T> paramsToCheck, IFinder<MemberInfo> itemsFinder)
        {
            _itemsFinder = itemsFinder;
            _paramsToCheck = new Dictionary<Modifier, T>(paramsToCheck);
        }

        public void Init()
        {
            _itemsToInspect = _itemsFinder.GetItems();
        }

        public abstract InspectionResult Run();

        protected virtual T GetParams(Modifier modifier)
        {
            if (modifier == Modifier.All)
            {
                return _paramsToCheck.ContainsKey(Modifier.All) ? _paramsToCheck[Modifier.All] : null;
            }
            else if (_paramsToCheck.ContainsKey(modifier))
            {
                return _paramsToCheck[modifier];
            }
            else
            {
                return _paramsToCheck.ContainsKey(Modifier.NotSet) ? _paramsToCheck[Modifier.NotSet] : null;
            }
        }

        protected InspectionResult InspectUsingParam(MemberInfo member, IParam param)
        {
            var inspectionResult = new InspectionResult();
            if (param == null)
            {
                inspectionResult.AddResult(InspectionItem.Ok(member, "NotSetParam"));
                return inspectionResult;
            }

            foreach (var item in ((IBuildable)param).Build())
            {
                if (_checkers.ContainsKey(item.Key))
                {
                    var result = _checkers[item.Key].Check(member, item.Value);
                    inspectionResult.AddResult(result);
                }
                else
                {
                    throw new InvalidOperationException("Cannot find checker for type " + item.Key);
                }
            }

            return inspectionResult;
        }
    }
}
