# CodeInspect

This is free .NET Standard 2.0 library for Code style inspection. You can use this library with .NET Core >= 2.0 and .NET Framework >= 4.61

## Version

## Getting Started

These instructions will help you to attach this library to your project

### Installing

Instalation with Nuget
https://www.nuget.org/packages/CodeInspect

```
Install-Package CodeInspect

Optionally you can add package with attributes like [CodeInspectIgnore]
Install-Package CodeInspect.Attributes
```

## Usage

In Xunit project examples:

### Inspect all fields names in the assembly
Fields should have names longer than 2 chars and shorter than 30 chars

Every not specified fields (like public or internal fields) are forbidden in this scenario

Every private and protected fields name must starts with "_"

Every static fields name must start lower case
```
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
```
### Inspect all methods in the namespace 

Every method should have name not shorter than 2 chars, not longer than 30 chars, no more args than 6

Every parameter of method should have name starts with lowecase, param name not shorter than 2 chars, param name cannot be longer than 15 chars

Every private method must have return value
```
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
```
### Inspect all properties in the namespace

Every property name cannot be shorter than 2 chars, name must be shorter than 30 chars, each propertys name must starts capital letter

Every public property must have attribute DataMemberAttribute

Private properties AreForbidden
```
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
```
### Inspect all types in the namespace

Types names cannot be shorter than 2 chars and longer than 30 chars. Name must starts with capital letter

Every type must have default constructor, not more methods than 20, not more methods than 10 and inherits class ContractBase
```
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

```
## Authors

* **Przemysław Grzywa** - [Przemko92](https://github.com/Przemko92)

## License

This project is licensed under the Apache License 2.0 - see the [LICENSE](LICENSE) file for details
