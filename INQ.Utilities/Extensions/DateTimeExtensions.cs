using System;

namespace INQ.Utilities.Extensions;

public static class DateTimeExtensions
{
    public static bool IsDefault(DateTime? dateTime)
    {
        return !dateTime.HasValue
               || dateTime.Equals(DateTime.MinValue)
               || dateTime.Equals(DateTime.MaxValue);
    }

    public static bool IsEqual(this DateTime src, DateTime dst)
        => DateTime.Compare(src, dst) == 0;

    public static bool IsLaterThan(this DateTime? src, DateTime? dst)
    {
        if (src.HasValue == false || dst.HasValue == false) return false;

        return DateTime.Compare(src.Value, dst.Value) > 0;
    }
}