using Microsoft.Extensions.Logging;

using ILoggerFactory loggerFactory = LoggerFactory.Create((builder) =>
{
    builder.AddConsole();
    builder.SetMinimumLevel(LogLevel.Information);
});


// Event Id helps to label log entries, with event id and log categores we can filter our logs

ILogger logger = loggerFactory.CreateLogger<Program>();

logger.LogInformation(new EventId(LogEvents.PaymentSucess), "Payment successfully completed | {date}", DateTime.Now);

logger.LogError(new EventId(LogEvents.PaymentFailed), "Payment failed | {date}", DateTime.MinValue);


//OUTPUT

//info: Program[5001] > 5001 success event id
//      Payment successfully completed | 01/01/0001 00:00:00
//fail: Program[5002] > 5002 failure event id
//      Payment failed | 01/01/0001 00:00:00

/// <summary>
/// Log events
/// </summary>
public struct LogEvents
{
    public const int PaymentSucess = 5001;
    public const int PaymentFailed = 5002;
}