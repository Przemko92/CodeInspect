namespace CodeInspect.Builders.Interfaces
{
    public interface IFieldsInspectBuilder : IInspectBuilder<IFieldsInspectBuilder>
    {
        IFieldParam AllNotSpecified { get; }

        IFieldParam PrivateFields { get; }
        IFieldParam ProtectedFields { get; }
        IFieldParam InternalFields { get; }
        IFieldParam PublicFields { get; }

        IFieldParam StaticPrivateFields { get; }
        IFieldParam StaticProtectedFields { get; }
        IFieldParam StaticInternalFields { get; }
        IFieldParam StaticPublicFields { get; }
    }
}