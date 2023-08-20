
using Microsoft.Extensions.Logging;

using ILoggerFactory loggerFactory = LoggerFactory.Create((builder) =>
{
    builder.AddConsole();
    builder.SetMinimumLevel(LogLevel.Information);

    // This has the same functionality with SetMinimumLevel(LogLevel.Information)
    builder.AddFilter(x => x >= LogLevel.Information);

    // Filter for category
    builder.AddFilter(nameof(User), LogLevel.Warning);
});

ILogger logger = loggerFactory.CreateLogger<Program>();
ILogger userLogger = loggerFactory.CreateLogger<User>();

logger.LogInformation("This is an information log");
// Information log for user will not be displated because of the log filter
userLogger.LogInformation("This is an information log for user");
userLogger.LogWarning("This is an warning log for user");

public record User(string fullname,string email);