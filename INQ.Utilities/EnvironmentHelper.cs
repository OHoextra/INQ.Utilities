namespace INQ.Utilities;

public static class EnvironmentHelper
{
    private const string DEFAULT_ENVIRONMENT = "Production";
    private const string DEVELOPMENT_ENVIRONMENT = "Development";

    public static bool IsDevelopment()
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        if (string.IsNullOrWhiteSpace(environmentName)) 
            environmentName = DEFAULT_ENVIRONMENT;

        return environmentName == DEVELOPMENT_ENVIRONMENT;
    }

    public static string GetEnvironment() 
        => Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? DEFAULT_ENVIRONMENT;
}

