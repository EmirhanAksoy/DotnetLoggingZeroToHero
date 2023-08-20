using Microsoft.Extensions.Logging;

using ILoggerFactory loggerFactory = LoggerFactory.Create((builder) =>
{
    builder.AddConsole();  //  writes to console
    builder.AddEventLog(); //  writes to windows event
    builder.SetMinimumLevel(LogLevel.Information);
});

// Log provider is about how to store or display logs

// AddConsole method is used for set log providers as console

// We can have multiple log providers such as WindowsEvent,File,Azure App Insights

ILogger logger = loggerFactory.CreateLogger<Program>();

logger.LogInformation("This is an information log from console application | {date}",DateTime.Now);

// check windows event viewer to see the log
