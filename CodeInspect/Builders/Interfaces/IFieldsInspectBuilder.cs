using System.Collections.Generic;
using System.Reflection;

namespace CodeInspect.Builders.Interfaces
{
    public interface IFieldsInspectBuilder : IInspectBuilder<IFieldsInspectBuilder>
    {
        IFieldParam AllFields { get; }
        IFieldParam AllNotSpecified { get; }

        IFieldParam PrivateFields { get; }
        IFieldParam ProtectedFields { get; }
        IFieldParam InternalFields { get; }
        IFieldParam PublicFields { get; }

        IFieldParam StaticPrivateFields { get; }
        IFieldParam StaticProtectedFields { get; }
        IFieldParam StaticInternalFields { get; }
        IFieldParam StaticPublicFields { get; }
        IFieldsInspectBuilder ThisItems(IEnumerable<FieldInfo> fields);
    }
}