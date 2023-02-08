using System.Text.Json;

namespace INQ.Utilities.Helpers
{
    public static class JsonSerializer
    {
        public static string Serialize<TType>(TType instance, JsonSerializerOptions? options = null)
        {
            options ??= new JsonSerializerOptions();
            options.WriteIndented = true;

            return System.Text.Json.JsonSerializer.Serialize(
                instance,
                options);
        }
    }
}
