namespace INQ.Utilities.Extensions;

public static class IntegerExtensions
{
    public static bool IsDefault(int? value) 
        => value is null
            or 0
            or int.MinValue
            or int.MaxValue;

    public static bool IsDefault(this int value)
        => value is 0
            or int.MinValue
            or int.MaxValue;
}

