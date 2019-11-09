namespace CodeInspect.Builders.Interfaces
{
    public interface IPropertiesInspectBuilder : IInspectBuilder<IPropertiesInspectBuilder>
    {
        IPropertyParam AllNotSpecified { get; }

        IPropertyParam PrivateProperties { get; }
        IPropertyParam ProtectedProperties { get; }
        IPropertyParam InternalProperties { get; }
        IPropertyParam PublicProperties { get; }

        IPropertyParam StaticPrivateProperties { get; }
        IPropertyParam StaticProtectedProperties { get; }
        IPropertyParam StaticInternalProperties { get; }
        IPropertyParam StaticPublicProperties { get; }
    }
}