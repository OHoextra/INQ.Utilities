using Microsoft.Extensions.Configuration;

namespace INQ.Utilities;

public static class ConfigurationHelper
{
    private const string JSON_SETTINGS_FILE_NAME = "appsettings";
    private const string JSON_SETTINGS_FILE_EXTENSION = ".json";

    public static IConfiguration BuildConfiguration(IConfigurationBuilder builder)
    {
        // TODO: test this
        var sources = builder.Sources;
        if (sources.Any())
        {
            throw new InvalidOperationException("Damn son, were you considering nullifying a working source of configuration?");
            builder.Sources.Clear();
        }

        builder.AddEnvironmentVariables();

        var basePath = DirectoryHelper.AppDomainDirectory();
        builder.SetBasePath(basePath);

        bool configFileExists = false;

        var settingsFileName = $"{JSON_SETTINGS_FILE_NAME}{JSON_SETTINGS_FILE_EXTENSION}";
        var fileName2 = $"{JSON_SETTINGS_FILE_NAME}.{EnvironmentHelper.GetEnvironment()}{JSON_SETTINGS_FILE_EXTENSION}";

        var file1Path = Path.Combine(basePath, settingsFileName);
        var file2Path = Path.Combine(basePath, fileName2);

        if (File.Exists(file1Path))
        {
            builder.AddJsonFile(settingsFileName);
            configFileExists = true;
        }
        if (File.Exists(file2Path))
        {
            builder.AddJsonFile(fileName2);
            configFileExists = true;
        }

        if (!configFileExists)
            throw new InvalidOperationException($"No appsettings.json found in base path: '{basePath}'");


        return builder.Build();
    }

    public static IConfiguration GetConfiguration()
        => BuildConfiguration(new ConfigurationBuilder());
}