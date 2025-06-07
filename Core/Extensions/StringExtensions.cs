namespace Core.Extensions;

public static class StringExtensions
{
    public static bool IsNullOrWhiteSpace(this string input)
    {
        return string.IsNullOrWhiteSpace(input);
    }

    public static string CapitalizeFirstLetter(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        return char.ToUpper(input[0]) + input.Substring(1);
    }

    public static string Reverse(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        return new string(input.ToCharArray().Reverse().ToArray());
    }
}