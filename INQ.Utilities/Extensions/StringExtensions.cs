namespace INQ.Utilities.Extensions;

public static class StringExtensions
{
    public static bool IsDefault(string? value)
        => string.IsNullOrWhiteSpace(value)
           || value.Equals("string")
           || value.Equals("-");

    public static bool IsGuid(this string? value)
        => Guid.TryParse(value, out _);
}