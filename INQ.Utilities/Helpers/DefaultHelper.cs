using INQ.Utilities.Extensions;

namespace INQ.Utilities.Helpers;

public static class DefaultChecker
{
    public static bool IsDefault(int? value)
    {
        if (value == null) return true;
        if (value == 0) return true;

        return false;
    }

    public static bool IsDefault(string? value)
    {
        return string.IsNullOrWhiteSpace(value)
               || value.Equals("string")
               || value.Equals("-");
    }

    public static bool IsDefault(IEnumerable<string>? strings)
    {
        return strings == null
               || !strings.Any();
    }

    public static bool IsDefault(DateTime? dateTime)
    {
        return !dateTime.HasValue
               || dateTime.IsEqual(DateTime.MinValue)
               || dateTime.IsEqual(DateTime.MaxValue);
    }

    public static bool IsNotDefault(int? value)
        => !IsDefault(value);

    public static bool IsNotDefault(string? value)
        => !IsDefault(value);

    public static bool IsNotDefault(IEnumerable<string>? value)
        => !IsDefault(value);

    public static bool IsNotDefault(DateTime? value)
        => !IsDefault(value);
}