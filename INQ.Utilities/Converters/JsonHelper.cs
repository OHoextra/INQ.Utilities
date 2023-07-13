using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace INQ.Utilities.Converters;

public class JsonHelper
{
    public string Serialize<TType>(TType instance, JsonSerializerOptions? options = null) where TType : new()
    {
        if (instance == null)
            throw new ArgumentNullException(nameof(instance));

        instance ??= new();
        options ??= new JsonSerializerOptions
        {
            WriteIndented = true
        };

        return JsonSerializer.Serialize(instance, options);
    }

    public StringContent SerializeToStringContent<TType>(TType instance, JsonSerializerOptions? options = null) where TType : new()
    {
        if (instance == null)
            throw new ArgumentNullException(nameof(instance));

        var contentString = Serialize(instance, options);

        return new StringContent(
            contentString,
            Encoding.UTF8,
            MediaTypeNames.Application.Json);
    }
}

