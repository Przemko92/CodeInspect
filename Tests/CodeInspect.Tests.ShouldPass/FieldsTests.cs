using System;
using System.Reflection;
using CodeInspect.ValidProject;
using CodeInspect.ValidProject.AnotherNamespace;
using Xunit;

namespace CodeInspect.Tests.ShouldPass
{
    public class FieldsTests
    {
        [Fact]
        public void CheckFields_Names_InAssembly()
        {
            var inspectResult = Inspect
                .AllFields
                .InAssemblies(typeof(StandardClass).Assembly)
                .AllFields.NameIsNotLongerThan(30).NameIsNotShorterThan(2)
                .And
                .AllNotSpecified.AreForbidden()
                .And
                .PrivateFields.NameStartsWith("_")
                .And
                .ProtectedFields.NameStartsWith("_")
                .And
                .StaticPrivateFields.NameStartsWithLowerCase()
                .Test();

            Assert.True(inspectResult.IsOk, inspectResult.GetErrorMessage());
        }

        [Fact]
        public void CheckFields_Names_InNamespace()
        {
            var inspectResult = Inspect
                .AllFields
                .InNamespaces(typeof(StandardClass).Namespace)
                .AllFields.NameIsNotLongerThan(30).NameIsNotShorterThan(2)
                .And
                .AllNotSpecified.AreForbidden()
                .And
                .PrivateFields.NameStartsWith("_")
                .And
                .ProtectedFields.NameStartsWith("_")
                .And
                .StaticPrivateFields.NameStartsWithLowerCase()
                .Test();

            Assert.True(inspectResult.IsOk, inspectResult.GetErrorMessage());
        }

        [Fact]
        public void CheckFields_Names_InType()
        {
            var inspectResult = Inspect
                .AllFields
                .InTypes(typeof(StandardClass), typeof(AnotherNamespaceClass))
                .AllFields.NameIsNotLongerThan(30).NameIsNotShorterThan(2)
                .And
                .AllNotSpecified.AreForbidden()
                .And
                .PrivateFields.NameStartsWith("_")
                .And
                .ProtectedFields.NameStartsWith("_")
                .And
                .StaticPrivateFields.NameStartsWithLowerCase()
                .Test();

            Assert.True(inspectResult.IsOk, inspectResult.GetErrorMessage());
        }

        [Fact]
        public void CheckFields_Names_SpecifiedFields()
        {
            var inspectResult = Inspect
                .AllFields
                .ThisItems(typeof(StandardClass).GetTypeInfo().DeclaredFields)
                .AllFields.NameIsNotLongerThan(30).NameIsNotShorterThan(2)
                .And
                .AllNotSpecified.AreForbidden()
                .And
                .PrivateFields.NameStartsWith("_")
                .And
                .ProtectedFields.NameStartsWith("_")
                .And
                .StaticPrivateFields.NameStartsWithLowerCase()
                .Test();

            Assert.True(inspectResult.IsOk, inspectResult.GetErrorMessage());
        }
    }
}
