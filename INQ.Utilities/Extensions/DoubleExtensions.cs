using System.Globalization;

namespace INQ.Utilities.Extensions
{
    public static class DoubleExtensions
    {
        public static bool IsDefault(this double? value)
            => value is null
                or double.MinValue
                or double.MaxValue;

        public static bool IsNotDefault(this double? value)
            => !value.IsDefault();

        public static string ToStringWithoutCommas(this double value)
            => value.ToString(CultureInfo.InvariantCulture);
    }
}
