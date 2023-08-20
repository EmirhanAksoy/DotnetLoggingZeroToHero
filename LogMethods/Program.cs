using Microsoft.Extensions.Logging;

using ILoggerFactory loggerFactory = LoggerFactory.Create((builder) =>
{
    builder.AddConsole();
    builder.SetMinimumLevel(LogLevel.Information);
});


ILogger logger = loggerFactory.CreateLogger<Program>();

// Main method of logger is Log
logger.Log(LogLevel.Information, "Information log | {date}", DateTime.Now);
logger.Log(LogLevel.Information, new EventId(100), "Information log | {date}", DateTime.Now);
logger.Log(LogLevel.Warning, new Exception("Something has failed"), "Information log | {date}", DateTime.Now);

// Other log methods are using Log 
logger.LogInformation("Information log | {date}", DateTime.Now);
logger.LogInformation(new EventId(100), "Information log | {date}", DateTime.Now);
logger.LogWarning(new Exception("Something has failed"), "Information log | {date}", DateTime.Now);

// IsEnable method helps to identify log leves are enabled or not


bool isInformationLogLevelEnabled = logger.IsEnabled(LogLevel.Information);
bool isWarningLogLevelEnabled = logger.IsEnabled(LogLevel.Warning);
bool isTraceLogLevelEnabled = logger.IsEnabled(LogLevel.Trace);

Console.WriteLine("-----------------------------------------");
Console.WriteLine($"Trace log level enabled : {isTraceLogLevelEnabled}");
Console.WriteLine($"Information log level enabled : {isInformationLogLevelEnabled}");
Console.WriteLine($"Warning log level enabled : {isWarningLogLevelEnabled}");
Console.WriteLine("-----------------------------------------");