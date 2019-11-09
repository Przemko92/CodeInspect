namespace CodeInspect.Builders.Interfaces
{
    public interface IMethodsInspectBuilder : IInspectBuilder<IMethodsInspectBuilder>
    {
        IMethodParam AllNotSpecified { get; }

        IMethodParam PrivateMethods { get; }
        IMethodParam ProtectedMethods { get; }
        IMethodParam InternalMethods { get; }
        IMethodParam PublicMethods { get; }

        IMethodParam StaticPrivateMethods { get; }
        IMethodParam StaticProtectedMethods { get; }
        IMethodParam StaticInternalMethods { get; }
        IMethodParam StaticPublicMethods { get; }
    }
}