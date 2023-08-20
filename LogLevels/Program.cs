
using Microsoft.Extensions.Logging;

// For ILogger abstraction > Microsoft.Extensions.Logging.Abstractions
// For LoggerFactory > Microsoft.Extensions.Logging
// For writing logs on Console (Console Provider) > Microsoft.Extensions.Logging.Console


using ILoggerFactory loggerFactory = LoggerFactory.Create((builder) =>
{
    builder.AddConsole();
    builder.SetMinimumLevel(LogLevel.Warning);
});

// Logger factory helps to produce intances of ILogger based on the providers with CreateLogger method

// Here is the severity levels 

// LogLevel.Trace          => 0
// LogLevel.Debug          => 1
// LogLevel.Information    => 2
// LogLevel.Warning        => 3
// LogLevel.Error          => 4

// Base on SetMinimumLevel configuration logs will be displayed on Console

// Trace is the minimum level so all logs except None will be displayed

// If minimum log level set as Warning then Warning,Error logs will be displayed only


ILogger logger = loggerFactory.CreateLogger<Program>();

logger.Log(LogLevel.Trace, "This is a Trace level log");
logger.Log(LogLevel.Debug, "This is a Debug level log");
logger.Log(LogLevel.Information, "This is an Information level log");
logger.Log(LogLevel.Warning, "This is a Warning level log");
logger.Log(LogLevel.Error, "This is an Error level log");
logger.Log(LogLevel.None, "This is a None level log");







