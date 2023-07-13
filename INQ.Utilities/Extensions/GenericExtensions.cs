using System.Linq.Expressions;
using System.Reflection;
using System.Xml.Serialization;

namespace INQ.Utilities.Extensions;

public static class GenericExtensions
{
    public static void SetPropertyValue<TType, TPropertyType>(
        this TType instance,
        Expression<Func<TType, TPropertyType>> propertyExpression,
        TPropertyType newValue)
    {
        if (propertyExpression.Body is not MemberExpression memberExpression)
            throw new InvalidOperationException("propertyExpression.Body is not MemberExpression memberExpression");

        var property = memberExpression.Member as PropertyInfo;
        if (property == null)
            throw new InvalidOperationException("property = memberExpression.Member as PropertyInfo");

        property.SetValue(instance, newValue, null);
    }

    public static TType CreateDeepCopy<TType>(this TType instance)
    {
        using var memoryStream = new MemoryStream();
        var type = instance?.GetType();
        if (type == null)
            throw new InvalidOperationException($"'{nameof(type)}' == null, failed to get type for: '{nameof(instance)}' of derived type named: '{typeof(TType).Name}'.");

        var serializer = new XmlSerializer(type);
        serializer.Serialize(memoryStream, instance);
        memoryStream.Seek(0, SeekOrigin.Begin);
        var deepCopy = (TType?)serializer.Deserialize(memoryStream)
                       ?? throw new InvalidOperationException("Failed to deserialize into a deep-copy.");

        return deepCopy;
    }
}