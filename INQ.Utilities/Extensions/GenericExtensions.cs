using System.Xml.Serialization;

namespace INQ.Utilities.Extensions;

public static class GenericExtensions
{
    public static TType? CreateDeepCopy<TType>(this TType entity)
    {
        using var memoryStream = new MemoryStream();
        var type = entity?.GetType();
        if (type == null)
            throw new InvalidOperationException("type == null");

        var serializer = new XmlSerializer(type);
        serializer.Serialize(memoryStream, entity);
        memoryStream.Seek(0, SeekOrigin.Begin);
        var deepCopy = (TType?)serializer.Deserialize(memoryStream) ?? default;

        return deepCopy;
    }
}