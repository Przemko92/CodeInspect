namespace CodeInspect.Builders.Interfaces
{
    public interface ITypeInspectBuilder : IInspectBuilder<ITypeInspectBuilder>
    {
        ITypeParam AllNotSpecified { get; }
        ITypeParam EnumTypes { get; }
        ITypeParam InterfaceTypes { get; }
        ITypeParam AbstractTypes { get; }
        ITypeParam PublicTypes { get; }
        ITypeParam NonPublicTypes { get; }
        ITypeParam ClassTypes { get; }
    }
}