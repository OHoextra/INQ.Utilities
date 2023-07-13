namespace INQ.Utilities.FileSystem;

public static class DirectoryHelper
{
    public static string CombineExistingOrThrow(string directory, string file)
    {
        if (string.IsNullOrWhiteSpace(directory))
            throw new ArgumentNullException(nameof(directory));

        if (string.IsNullOrWhiteSpace(file))
            throw new ArgumentNullException(nameof(file));

        if (!Directory.Exists(directory))
            throw new InvalidOperationException($"{nameof(directory)}: '{directory}' does not exist.");

        var filePath = Path.Combine(directory, file);

        if (!File.Exists(filePath))
            throw new InvalidOperationException($"{nameof(filePath)}: '{filePath}' does not exist.");

        return filePath;
    }
}