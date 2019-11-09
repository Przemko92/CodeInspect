using System;
using System.Reflection;
using CodeInspect.InValidProject;
using CodeInspect.InValidProject.AnotherNamespace;
using Xunit;

namespace CodeInspect.Tests.ShouldFail
{
    public class MethodsTests
    {
        [Fact]
        public void CheckMethods_NamesAndArgs_InAssembly()
        {
            var inspectResult = Inspect
                .AllMethods
                .InAssemblies(typeof(StandardClass).Assembly)
                .AllMethods.NameIsNotShorterThan(2).NameIsNotLongerThan(30).HasLessArgsThan(6).ParamsNameStartsWithLowerCase().ParamsNameIsNotShorterThan(2).ParamsNameNotLongerThan(15)
                .And
                .PrivateMethods.HasReturnType()
                .Test();

            Assert.True(inspectResult.IsOk, inspectResult.GetErrorMessage());
        }

        [Fact]
        public void CheckMethods_NamesAndArgs_InNamespace()
        {
            var inspectResult = Inspect
                .AllMethods
                .InNamespaces(typeof(StandardClass).Namespace)
                .AllMethods.NameIsNotShorterThan(2).NameIsNotLongerThan(30).HasLessArgsThan(6).ParamsNameStartsWithLowerCase().ParamsNameIsNotShorterThan(2).ParamsNameNotLongerThan(15)
                .And
                .PrivateMethods.HasReturnType()
                .Test();

            Assert.True(inspectResult.IsOk, inspectResult.GetErrorMessage());
        }

        [Fact]
        public void CheckFields_Names_InType()
        {
            var inspectResult = Inspect
                .AllMethods
                .InTypes(typeof(StandardClass), typeof(AnotherNamespaceClass))
                .AllMethods.NameIsNotShorterThan(2).NameIsNotLongerThan(30).HasLessArgsThan(6).ParamsNameStartsWithLowerCase().ParamsNameIsNotShorterThan(2).ParamsNameNotLongerThan(15)
                .And
                .PrivateMethods.HasReturnType()
                .Test();

            Assert.True(inspectResult.IsOk, inspectResult.GetErrorMessage());
        }

        [Fact]
        public void CheckFields_Names_SpecifiedFields()
        {
            var inspectResult = Inspect
                .AllMethods
                .ThisItems(typeof(StandardClass).GetTypeInfo().DeclaredMethods)
                .AllMethods.NameIsNotShorterThan(2).NameIsNotLongerThan(30).HasLessArgsThan(6).ParamsNameStartsWithLowerCase().ParamsNameIsNotShorterThan(2).ParamsNameNotLongerThan(15)
                .And
                .PrivateMethods.HasReturnType()
                .Test();

            Assert.True(inspectResult.IsOk, inspectResult.GetErrorMessage());
        }
    }
}
