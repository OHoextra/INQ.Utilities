using System;
using INQ.Utilities.Environments.Enums;

namespace INQ.Utilities.Environments;

public static class EnvironmentHelper
{
    public const string VariableName = "ASPNETCORE_ENVIRONMENT";
    private const string _DEVELOPMENT_NAME = nameof(Enums.Environments.Development);
    private const string _PRODUCTION_NAME = nameof(Enums.Environments.Production);
    private static readonly List<string> _KnownEnvironmentNames = typeof(Enums.Environments).GetEnumNames().ToList();

    public static readonly string CurrentEnvironment = GetEnvironmentNameOrThrow();

    public static bool IsDevelopment()
        => string.Equals(_DEVELOPMENT_NAME, CurrentEnvironment);

    public static bool IsProduction()
        => string.Equals(_PRODUCTION_NAME, CurrentEnvironment);

    public static IEnumerable<string> GetKnownEnvironments()
        => typeof(Enums.Environments).GetEnumNames();

    private static string GetEnvironmentNameOrThrow()
    {
        var envName = Environment.GetEnvironmentVariable(VariableName)?.Trim();

        if (string.IsNullOrWhiteSpace(envName))
            throw new InvalidOperationException($"'{nameof(envName)}' is null or whitespace.");

        if(!_KnownEnvironmentNames.Contains(envName))
            throw new InvalidOperationException($"'{nameof(_KnownEnvironmentNames)}' does not contain environment: '{envName}'");

        return envName;
    }

    public static string GetCurrentDirectory()
        => AppDomain.CurrentDomain.BaseDirectory; // TODO: test vs: System.Environment.SpecialFolder.ApplicationData
}

