using System;
using System.Reflection;
using CodeInspect.InValidProject;
using CodeInspect.InValidProject.WcfContract;
using Xunit;

namespace CodeInspect.Tests.ShouldFail
{
    public class TypesTests
    {
        [Fact]
        public void CheckTypes_NamesAndArgs_InAssembly()
        {
            var inspectResult = Inspect
                .AllTypes
                .InAssemblies(typeof(StandardClass).Assembly)
                .AllTypes.NameIsNotShorterThan(2).NameIsNotLongerThan(30).NameStartsWithCapitalLetter()
                .And
                .NonPublicTypes.AreForbidden()
                .Test();

            Assert.True(inspectResult.IsOk, inspectResult.GetErrorMessage());
        }

        [Fact]
        public void CheckTypes_HasDefaultConstructors_InNamespace()
        {
            var inspectResult = Inspect
                .AllTypes
                .InNamespaces(typeof(TestContract).Namespace)
                .AllTypes.NameIsNotShorterThan(2).NameIsNotLongerThan(30).NameStartsWithCapitalLetter().HasDefaultConstructor().HasNotMoreMethodsThan(20).HasNotMorePropertiesThan(10).Inherits<ContractBase>()
                .Test();

            Assert.True(inspectResult.IsOk, inspectResult.GetErrorMessage());
        }
    }
}
