using System;
using System.Collections.Generic;
using System.Reflection;
using CodeInspect.Builders.Interfaces;
using CodeInspect.Enums;
using CodeInspect.Models;
using CodeInspect.Testers.Interfaces;

namespace CodeInspect.Testers.Inspectors
{
    class MethodsInspector : Inspector<IMethodParam>, IMethodsInspector
    {
        public MethodsInspector(IDictionary<Modifier, IMethodParam> paramsToCheck, IFinder<MemberInfo> itemsFinder) : base(paramsToCheck, itemsFinder)
        {
        }

        public override InspectionResult Run()
        {
            var result = new InspectionResult();

            foreach (MethodInfo method in _itemsToInspect)
            {
                InspectionResult item = null;
                Modifier modifier = Modifier.NotSet;

                if (method.IsPrivate)
                {
                    modifier |= Modifier.Private;
                }
                else if (method.IsFamily)
                {
                    modifier |= Modifier.Protected;
                }
                else if (method.IsAssembly)
                {
                    modifier |= Modifier.Internal;
                }
                else if (method.IsPublic)
                {
                    modifier |= Modifier.Public;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("FieldType");
                }

                if (method.IsStatic)
                {
                    modifier |= Modifier.Static;
                }

                item = InspectUsingParam(method, GetParams(modifier));
                result.Merge(item);
            }

            return result;
        }
    }

}
