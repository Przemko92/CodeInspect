using System;
using System.Collections.Generic;
using System.Reflection;

namespace CodeInspect.Builders.Interfaces
{
    public interface ITypeInspectBuilder : IInspectBuilder<ITypeInspectBuilder>
    {
        ITypeParam AllTypes { get; }
        ITypeParam AllNotSpecified { get; }
        ITypeParam EnumTypes { get; }
        ITypeParam InterfaceTypes { get; }
        ITypeParam AbstractTypes { get; }
        ITypeParam PublicTypes { get; }
        ITypeParam NonPublicTypes { get; }
        ITypeParam ClassTypes { get; }
        ITypeInspectBuilder ThisItems(IEnumerable<Type> types);
    }
}