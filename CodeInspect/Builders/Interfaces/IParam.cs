using System;
using CodeInspect.Models;

namespace CodeInspect.Builders.Interfaces
{
    public interface IFieldParam : IParam<IFieldParam>
    {
        IFieldsInspectBuilder And { get; }
    }

    public interface IPropertyParam : IParam<IPropertyParam>
    {
        IPropertiesInspectBuilder And { get; }
        IPropertyParam HasSetter(bool value, bool includePrivate = true);
        IPropertyParam HasGetter(bool value, bool includePrivate = true);
    }

    public interface IMethodParam : IParam<IMethodParam>
    {
        IMethodsInspectBuilder And { get; }
        IMethodParam HasReturnType();
        IMethodParam AreVoid();
        IMethodParam HasMoreArgsThan(int count);
        IMethodParam HasLessArgsThan(int count);
        IMethodParam ParamsNameNotLongerThan(int length);
        IMethodParam ParamsNameIsNotShorterThan(int length);
        IMethodParam ParamsNameStartsWith(params string[] allowedTexts);
        IMethodParam ParamsNameStartsWithCapitalLetter();
        IMethodParam ParamsNameStartsWithLowerCase();
        IMethodParam ParamsNameMatchRegex(params string[] regex);
        IMethodParam ParamsNameNotStartsWith(params string[] notAllowedTexts);
    }

    public interface ITypeParam : IParam<ITypeParam>
    {
        ITypeInspectBuilder And { get; }
        ITypeParam Implements<T>();
        ITypeParam Implements(params Type[] types);
        ITypeParam Inherits<T>();
        ITypeParam Inherits(Type type);
        ITypeParam HasNotMoreMethodsThan(int count);
        ITypeParam HasNotMorePropertiesThan(int count);
        ITypeParam HasDefaultConstructor(bool incluePrivate = false);
        ITypeParam HasPublicConstructor(bool value = true);
    }

    public interface IParam<T> : IParam
    {
        T AreForbidden();
        T NameIsNotLongerThan(int length);
        T NameIsNotShorterThan(int length);
        T NameNotStartsWith(params string[] notAllowedTexts);
        T NameNotEndsWith(params string[] notAllowedTexts);
        T NameEndsWith(params string[] notAllowedTexts);
        T NameStartsWith(params string[] allowedTexts);
        T NameStartsWithCapitalLetter();
        T NameStartsWithLowerCase();
        T HasAttribute<T1>() where T1 : Attribute;
        T HasAttributes(params Type[] attributes);
        T ForbiddenAttributes<T1>() where T1 : Attribute;
        T ForbiddenAttributes(params Type[] attributes);
    }

    public interface IParam
    {
        InspectionResult Test();
    }
}