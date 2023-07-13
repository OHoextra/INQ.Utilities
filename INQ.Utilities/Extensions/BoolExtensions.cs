namespace INQ.Utilities.Extensions;

public static class BoolExtensions
{
    /// <summary>
    /// Verifies that 1 mandatory and 2 optional boolean instances have the same value.
    /// </summary>
    public static bool Equals(this bool instance1, bool? instance2, bool? instance3)
        => instance1 == instance2 && instance2 == instance3;

    /// <summary>
    /// Verifies that 3 optional boolean instances have the same value.
    /// </summary>
    public static bool Equals(this bool? instance1, bool? instance2, bool? instance3)
        => instance1 == instance2 && instance2 == instance3;

    public static bool IsDefault(this bool? boolean)
        => boolean is null;

    public static bool IsNotDefault(this bool? boolean)
        => !boolean.IsDefault();
}
