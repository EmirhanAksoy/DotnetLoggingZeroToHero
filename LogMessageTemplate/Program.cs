using Microsoft.Extensions.Logging;

using ILoggerFactory loggerFactory = LoggerFactory.Create((builder) =>
{
    builder.AddConsole();
    builder.SetMinimumLevel(LogLevel.Information);
});

ILogger logger = loggerFactory.CreateLogger<Program>();

decimal totalCost = 56.8m;
DateTime now = DateTime.UtcNow;

logger.LogInformation("Total cost is {totalCost:000} | {date:HH:mm:ss}", totalCost, now);

// While logging we can use formatters to display messages properly
