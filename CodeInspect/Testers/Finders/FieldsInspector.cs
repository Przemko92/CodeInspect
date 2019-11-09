using System;
using System.Collections.Generic;
using System.Reflection;
using CodeInspect.Builders.Interfaces;
using CodeInspect.Enums;
using CodeInspect.Models;
using CodeInspect.Testers.Inspectors;
using CodeInspect.Testers.Interfaces;

namespace CodeInspect.Testers.Finders
{
    class FieldsInspector : Inspector<IFieldParam>, IFieldsInspector
    {
        public FieldsInspector(IDictionary<Modifier, IFieldParam> paramsToCheck, IFinder<MemberInfo> itemsFinder) : base(paramsToCheck, itemsFinder)
        {
        }

        public override InspectionResult Run()
        {
            var result = new InspectionResult();

            foreach (FieldInfo field in _itemsToInspect)
            {
                InspectionResult item = null;
                Modifier modifier = Modifier.NotSet;

                if (field.IsPrivate)
                {
                    modifier |= Modifier.Private;
                }
                else if (field.IsFamily)
                {
                    modifier |= Modifier.Protected;
                }
                else if (field.IsAssembly)
                {
                    modifier |= Modifier.Internal;
                }
                else if (field.IsPublic)
                {
                    modifier |= Modifier.Public;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("FieldType");
                }

                if (field.IsStatic)
                {
                    modifier |= Modifier.Static;
                }

                item = InspectUsingParam(field, GetParams(modifier));
                result.Merge(item);
            }

            return result;
        }
    }
}
