using System;
using System.Collections.Generic;
using System.Reflection;
using CodeInspect.Builders.Interfaces;
using CodeInspect.Builders.Params;
using CodeInspect.Enums;
using CodeInspect.Models;
using CodeInspect.Testers.Interfaces;

namespace CodeInspect.Testers.Inspectors
{
    class TypesInspector : Inspector<ITypeParam>, ITypesInspector
    {
        public TypesInspector(IDictionary<Modifier, ITypeParam> paramsToCheck, IFinder<MemberInfo> itemsFinder) : base(paramsToCheck, itemsFinder)
        {
        }

        public override InspectionResult Run()
        {
            var result = new InspectionResult();

            foreach (TypeInfo type in _itemsToInspect)
            {
                bool foundRule = false; 
                InspectionResult item = null;

                if (type.IsEnum)
                {
                    foundRule = true;
                    item = InspectUsingParam(type, GetParams(Modifier.Enum));
                    result.Merge(item);
                }
                else if (type.IsInterface)
                {
                    foundRule = true;
                    item = InspectUsingParam(type, GetParams(Modifier.Interface));
                    result.Merge(item);
                }
                else if (type.IsClass)
                {
                    foundRule = true;
                    item = InspectUsingParam(type, GetParams(Modifier.Class));
                    result.Merge(item);
                }
                
                if (type.IsPublic)
                {
                    foundRule = true;
                    item = InspectUsingParam(type, GetParams(Modifier.Public));
                    result.Merge(item);
                }
                else 
                {
                    foundRule = true;
                    item = InspectUsingParam(type, GetParams(Modifier.Internal));
                    result.Merge(item);
                }

                if (type.IsAbstract && !type.IsInterface)
                {
                    foundRule = true;
                    item = InspectUsingParam(type, GetParams(Modifier.Abstract));
                    result.Merge(item);
                }

                if (!foundRule)
                {
                    item = InspectUsingParam(type, GetParams(Modifier.NotSet));
                    result.Merge(item);
                }

                item = InspectUsingParam(type, GetParams(Modifier.All));
                result.Merge(item);
            }

            return result;
        }
    }
}
