using System;
using System.Reflection;
using System.Runtime.Serialization;
using CodeInspect.ValidProject;
using CodeInspect.ValidProject.AnotherNamespace;
using CodeInspect.ValidProject.WcfContract;
using Xunit;

namespace CodeInspect.Tests.ShouldPass
{
    public class PropertiesTests
    {
        [Fact]
        public void CheckProperties_NamesAndArgs_InNamespace()
        {
            var inspectResult = Inspect
                .AllProperties
                .InNamespaces(typeof(StandardClass).Namespace)
                .AllProperties.NameIsNotShorterThan(2).NameIsNotLongerThan(30).NameStartsWithCapitalLetter()
                .And
                .PublicProperties.HasSetter(false, false).HasGetter(true, false)
                .And
                .PrivateProperties.AreForbidden()
                .Test();

            Assert.True(inspectResult.IsOk, inspectResult.GetErrorMessage());
        }

        [Fact]
        public void CheckProperties_Attributes_InContract()
        {
            var inspectResult = Inspect
                .AllProperties
                .InNamespaces(typeof(TestContract).Namespace)
                .AllProperties.NameIsNotShorterThan(2).NameIsNotLongerThan(30).NameStartsWithCapitalLetter()
                .And
                .PublicProperties.HasAttribute<DataMemberAttribute>()
                .And
                .PrivateProperties.AreForbidden()
                .Test();

            Assert.True(inspectResult.IsOk, inspectResult.GetErrorMessage());
        }

    }
}
