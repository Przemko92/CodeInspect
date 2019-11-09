namespace CodeInspect.Builders.Interfaces
{
    interface INameParam
    {
        INameParam IsNotLongerThan(int length);
        INameParam IsNotShorterThan(int length);
        INameParam StartsWith(params string[] allowedTexts);
        INameParam StartsWithCapitalLetter();
        INameParam NotStartsWith(params string[] notAllowedTexts);
        INameParam StartsWithLowerCase();
        INameParam MatchRegex(params string[] regex);
        INameParam EndsWith(string[] allowedTexts);
        INameParam NotEndsWith(string[] notAllowedTexts);
    }
}