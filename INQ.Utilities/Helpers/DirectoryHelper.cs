namespace INQ.Utilities.Helpers;

public static class DirectoryHelper
{
    public static string GetExistingPathForFile(string fileName, string basePath = "")
    {
        if (string.IsNullOrWhiteSpace(fileName))
            throw new ArgumentNullException(nameof(fileName));

        string fullFilePath;

        if (!string.IsNullOrWhiteSpace(basePath))
        {
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
            fullFilePath = Path.Combine(basePath, fileName);
        }
        else
        {
            fullFilePath = Path.GetFullPath(fileName);
        }

        return fullFilePath;
    }

    public static string CurrentDirectory()
        => Directory.GetCurrentDirectory();

    public static string AppDomainDirectory()
        => AppDomain.CurrentDomain.BaseDirectory;
}

