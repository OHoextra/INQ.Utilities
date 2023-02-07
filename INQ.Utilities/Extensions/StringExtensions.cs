namespace INQ.Utilities.Extensions;

public static class StringExtensions
{
    public static bool IsGuid(this string? value) 
        => Guid.TryParse(value, out _);

    public static bool IsDescriptionNumber(this string? value) 
        => value._IsGradingNumber(",");

    public static bool IsGradeNumber(this string? value)
        => value._IsGradingNumber(".");

    internal static bool _IsGradingNumber(this string? value, string separator)
    {
        if (string.IsNullOrWhiteSpace(separator))
            throw new ArgumentNullException(nameof(separator));

        if (string.IsNullOrWhiteSpace(value)
            || !value.Contains(separator)
            || !value.EndsWith("0"))
            return false;

        var numericParts = value.Split(separator);
        if (numericParts.Length != 2)
            return false;

        var isNumeric = int.TryParse(
            numericParts[0],
            out var number);

        var endsWithZero = numericParts[1] == "0";

        return number is >= 0 and <= 10
               && isNumeric
               && endsWithZero;
    }
}