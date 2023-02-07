namespace INQ.Utilities.Extensions;

public static class EnumerableExtensions
{
    public static IEnumerable<TType> Page<TType>(
        this IEnumerable<TType> entitiesToPage, 
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

