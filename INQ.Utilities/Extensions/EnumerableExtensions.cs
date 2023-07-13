namespace INQ.Utilities.Extensions;

public static class EnumerableExtensions
{
    public static bool IsDefault<TType>(this IEnumerable<TType>? collection)
        => collection == null
           || !collection.Any();

    public static bool ContainsNulls<TType>(this IEnumerable<TType?>? collection)
    {
        var itemList = collection?.ToList();
        if (itemList.IsDefault()) return true;

        return itemList?.Any(item => item == null) ?? true;
    }

    public static IEnumerable<TEntity> Page<TEntity>(
        this IEnumerable<TEntity> entitiesToPage,
        int pageNumber = 0,
        int pageSize = 20)
    {
        if (pageNumber < 0)
            throw new ArgumentException(nameof(pageNumber) + " < 0");

        if (pageSize < 0)
            throw new ArgumentException(nameof(pageSize) + " < 0");

        var items = entitiesToPage.ToList();
        var skipAmount = pageNumber * pageSize;
        var skippedItems = items.Skip(skipAmount);
        var takenItems = skippedItems.Take(pageSize);

        return takenItems;
    }
}

