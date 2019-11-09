using System;
using System.Reflection;
using CodeInspect.TestProject.Basic;
using Xunit;

namespace CodeInspect.TestProject.Tests
{
    public class Class1Test
    {
        [Fact]
        public void TestFields_InAssembly()
        {
            var inspectionResult = Inspect
                .AllFields()
                .InAssemblies(typeof(CodeInspect.TestProject.Basic.Class1).Assembly)
                .AllNotSpecified.AreForbidden()
                .And
                .PrivateFields.NameIsNotShorterThan(3).NameStartsWith("_")
                .And
                .StaticPrivateFields.NameIsNotShorterThan(3).NameStartsWithLowerCase().NameIsNotLongerThan(10)
                .And.Test();

            Assert.True(inspectionResult.IsOk, inspectionResult.GetErrorMessage());
        }

        [Fact]
        public void TestMethods_InNamespace()
        {
            var inspectionResult = Inspect
                .AllMethods()
                .InNamespaces(typeof(CodeInspect.TestProject.Basic.Class1).Namespace)
                .AllNotSpecified.ParamsNameStartsWithLowerCase().ParamsNameIsNotShorterThan(3).ParamsNameNotStartsWith("_").HasLessArgsThan(5).NameStartsWithCapitalLetter()
                .And
                .PrivateMethods.ParamsNameIsNotShorterThan(2).ParamsNameStartsWithLowerCase().HasReturnType().ForbiddenAttributes<FactAttribute>().HasReturnType().HasMoreArgsThan(0)
                .And
                .StaticPrivateMethods.NameStartsWith("fsafdasf").AreVoid().NameStartsWithCapitalLetter()
                .And.Test();

            Assert.True(inspectionResult.IsOk, inspectionResult.GetErrorMessage());
        }

        [Fact]
        public void TestProperties_InType()
        {
            var inspectionResult = Inspect
                .AllProperties()
                .InTypes(typeof(CodeInspect.TestProject.Basic.Class1), typeof(CodeInspect.TestProject.Basic.Class2))
                .AllNotSpecified.AreForbidden()
                .And
                .PublicProperties.HasSetter(false, false).NameStartsWithCapitalLetter()
                .And.Test();

            Assert.True(inspectionResult.IsOk, inspectionResult.GetErrorMessage());
        }

        [Fact]
        public void TestTypes_InNamespace()
        {
            var inspectionResult = Inspect
                .AllTypes()
                .InNamespaces(typeof(CodeInspect.TestProject.Basic.Class1).Namespace)
                .EnumTypes.AreForbidden()
                .And
                .InterfaceTypes.NameStartsWith("I")
                .And
                .AbstractTypes.NameEndsWith("Base")
                .And.Test();

            Assert.True(inspectionResult.IsOk, inspectionResult.GetErrorMessage());
        }

        [Fact]
        public void TestTypes_InNamespace_ImplementsInterfaceAndHasBaseType()
        {
            var inspectionResult = Inspect
                .AllTypes()
                .InNamespaces(typeof(CodeInspect.TestProject.Inherits.Class1).Namespace)
                .EnumTypes.AreForbidden()
                .And
                .ClassTypes.Inherits<CodeInspect.TestProject.Inherits.BaseClass>()
                .And
                .AbstractTypes.Implements(typeof(CodeInspect.TestProject.Inherits.Interface), typeof(CodeInspect.TestProject.Inherits.Interface2))
                .Test();

            Assert.True(inspectionResult.IsOk, inspectionResult.GetErrorMessage());
        }
    }
}
