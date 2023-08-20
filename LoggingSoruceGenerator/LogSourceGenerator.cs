using Microsoft.Extensions.Logging;

namespace LoggingSoruceGenerator;

public static partial class LoggerExtensions
{
    [LoggerMessage(
        Level = LogLevel.Information,
        EventId = 5001,
        Message = "Payment with id:{paymentId} and amount:{amount} has been successfully completed"
        )]
    public static partial void LogPayment(this ILogger logger,string paymentId,decimal amount);
}
