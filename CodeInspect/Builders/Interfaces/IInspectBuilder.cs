using System;
using System.Reflection;
using CodeInspect.Models;

namespace CodeInspect.Builders.Interfaces
{
    public interface IInspectBuilder<T> : IInspectBuilder
    {
        T InAssemblies(params Assembly[] assemblies);
        T InTypes(params Type[] types);
        T InNamespaces(params string[] names);
        T ThrowOnError();
    }

    public interface IInspectBuilder
    {
        InspectionResult Test();
    }
}