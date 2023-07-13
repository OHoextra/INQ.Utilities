using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace INQ.Utilities.Configuration.Extensions;

public static class ConfigurationExtensions
{
    public static List<string> GetConfigurationFileNames(this IConfiguration configuration)
    {
        var fileNames = new List<string>();

        if (configuration is not IConfigurationRoot configurationRoot)
            return fileNames;

        foreach (var provider in configurationRoot.Providers)
        {
            if (provider is not FileConfigurationProvider fileProvider)
                continue;

            var fileName = fileProvider.Source.Path ?? string.Empty;
            if (string.IsNullOrWhiteSpace(fileName))
                throw new InvalidOperationException($"{nameof(fileName)} is null or empty.");

            fileNames.Add(fileName);
        }

        return fileNames;
    }

    public static string GetRequired(this IConfiguration configuration, string variableName, ILogger? logger = null)
    {
        var variableValue = configuration[variableName];
        if (string.IsNullOrWhiteSpace(variableValue))
            throw new InvalidOperationException($"'{variableName}' configuration value is null or whitespace, failed to load a valid value from the configuration.");

        logger?.LogInformation($"Configuration> {variableName} = '{variableValue}'");

        return variableValue;
    }
}
