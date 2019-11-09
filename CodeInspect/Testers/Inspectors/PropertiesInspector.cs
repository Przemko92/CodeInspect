using System;
using System.Collections.Generic;
using System.Reflection;
using CodeInspect.Builders.Interfaces;
using CodeInspect.Enums;
using CodeInspect.Helpers;
using CodeInspect.Models;
using CodeInspect.Testers.Interfaces;

namespace CodeInspect.Testers.Inspectors
{
    class PropertiesInspector : Inspector<IPropertyParam>, IPropertiesInspector
    {
        public PropertiesInspector(IDictionary<Modifier, IPropertyParam> paramsToCheck, IFinder<MemberInfo> itemsFinder) : base(paramsToCheck, itemsFinder)
        {
        }

        public override InspectionResult Run()
        {
            var result = new InspectionResult();

            foreach (PropertyInfo property in _itemsToInspect)
            {
                InspectionResult item = null;
                Modifier modifier = Modifier.NotSet;

                if (property.IsPrivate())
                {
                    modifier |= Modifier.Private;
                }
                else if (property.IsPrivate())
                {
                    modifier |= Modifier.Protected;
                }
                else if (property.IsInternal())
                {
                    modifier |= Modifier.Internal;
                }
                else if (property.IsPublic())
                {
                    modifier |= Modifier.Public;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Modifier");
                }

                if (property.IsStatic())
                {
                    modifier |= Modifier.Static;
                }

                item = InspectUsingParam(property, GetParams(modifier));
                result.Merge(item);

                item = InspectUsingParam(property, GetParams(Modifier.All));
                result.Merge(item);
            }

            return result;
        }
    }
}
