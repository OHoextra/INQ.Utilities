using INQ.Utilities.Environments;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace INQ.Utilities.Configuration;

public class ConfigurationHelper
{
    private const string _LOG_PREFIX = "Configuration>";
    private const string _FILE_NAME = "appsettings";
    private const string _FILE_EXTENSION = ".json";
    private const string _BASE_CONFIG_FILE = $"{_FILE_NAME}.{_FILE_NAME}{_FILE_EXTENSION}";

    private readonly ILogger _logger;

    public ConfigurationHelper(ILogger logger)
    {
        _logger = logger;
    }

    // TODO: test that it reloads changes during runtime effectively
    public IConfiguration GetConfiguration(string environment)
    {
        var configDirectory = EnvironmentHelper.GetCurrentDirectory();

        _logger.LogInformation(($"{_LOG_PREFIX} {nameof(configDirectory)} = '{configDirectory}'"));

        if (!Directory.Exists(configDirectory))
            throw new InvalidOperationException($"{nameof(configDirectory)}: '{configDirectory}' does not exist but is required.");

        var builder = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .SetBasePath(configDirectory);

        var baseConfigFilePath = Path.Combine(configDirectory, _BASE_CONFIG_FILE);

        if (File.Exists(baseConfigFilePath))
        {
            builder.AddJsonFile(baseConfigFilePath);
            _logger.LogInformation($"{_LOG_PREFIX} added config: '{baseConfigFilePath}'.");
        }
        else
        {
            _logger.LogInformation($"{_LOG_PREFIX} could not find config: '{baseConfigFilePath}', skipped.");
        }

        _logger.LogInformation($"{_LOG_PREFIX} {nameof(environment)} = '{environment}'");

        var environmentConfigFile = $"{_FILE_NAME}.{environment}{_FILE_EXTENSION}";
        var environmentConfigFilePath = Path.Combine(configDirectory, environmentConfigFile);

        if (File.Exists(environmentConfigFilePath))
        {
            builder.AddJsonFile(environmentConfigFilePath, optional: true);
            _logger.LogInformation($"{_LOG_PREFIX} added config: '{environmentConfigFilePath}'.");
        }
        else
        {
            _logger.LogInformation($"{_LOG_PREFIX} could not find config: '{environmentConfigFilePath}', skipped.");
        }

        var config = builder.Build();

        return config;
    }
}