using Microsoft.Extensions.Logging;

using ILoggerFactory loggerFactory = LoggerFactory.Create((builder) =>
{
    builder.AddJsonConsole();
    builder.SetMinimumLevel(LogLevel.Warning);
});

ILogger logger = loggerFactory.CreateLogger<Program>();

// Log methods accep exexption objects
string operationName = "Payment";

try
{
    throw new Exception("Something has failed");
}
catch (Exception exception)
{
    logger.LogTrace(exception, "Something has failed for {operation}", operationName);
    logger.LogDebug(exception, "Something has failed for {operation}", operationName);
    logger.LogInformation(exception, "Something has failed for {operation}", operationName);

    // All log methods has exception overload but Warning,Error and Critical are more proper log methods for exceptions
    logger.LogWarning(exception, "Something has failed for {operation}", operationName);
    logger.LogCritical(exception, "Something has failed for {operation}", operationName);
    logger.LogError(exception,"Something has failed for {operation}", operationName);
}

//OUTPUT

//{
//    "EventId": 0,
//	  "LogLevel": "Error",
//	  "Category": "Program",
//	  "Message": "Something has failed for Payment",
//	  "Exception": "System.Exception: Something has failed    at Program.<Main>$(String[] args) in C:\\Users\\EmirhanAKSOY\\source\\repos\\DotnetLoggingZeroToHero\\LogExceptions\\Program.cs:line 16",
//	  "State": {
//          "Message": "Something has failed for Payment",
//	  	"operation": "Payment",
//	  	"{OriginalFormat}": "Something has failed for {operation}"
      
//     }
//}
