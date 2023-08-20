using CustomLogProvider;
using Microsoft.Extensions.Logging;

using ILoggerFactory loggerFactory = LoggerFactory.Create((builder) =>
{
    builder.AddConsole();
    builder.AddCustomFileLog("Log.txt");
    builder.SetMinimumLevel(LogLevel.Information);
});


ILogger logger = loggerFactory.CreateLogger<Program>();

logger.LogInformation("Hello world !");

// Check the log file > \CustomLogProvider\bin\Debug\net7.0>Log.txt

