using Microsoft.Extensions.Logging;


using ILoggerFactory loggerFactory = LoggerFactory.Create((configure) =>
{
    configure.AddConsole();
});

ILogger logger = loggerFactory.CreateLogger<Program>();


Action<Microsoft.Extensions.Logging.ILogger, string, decimal, Exception?> logPayment =
    LoggerMessage.Define<string, decimal>(
        LogLevel.Information,
        new EventId(5502, nameof(Payment)),
        "Payment with id:{paymentId} and amount:{amount} has been successfully completed");

// LoggerMessage.Define is a generic method and this preventing boxing operation

// Also LoggerMessage.Define method checking log levels is enabled or not before logging

// Because of this reasons its more performant for hot endpoins or methos we should use this approach


// More performent

logPayment(logger, Guid.NewGuid().ToString(), 5541.65m, null);

// Less performent because the params object args[] its required to use boxing

logger.LogInformation("Payment with id:{paymentId} and amount:{amount} has been successfully completed",
    Guid.NewGuid().ToString(), 5541.65m);

public class Payment
{
    public Payment(decimal amount)
    {
        this.Id = Guid.NewGuid().ToString();
        this.Amount = amount;
    }
    public string Id { get; set; }
    public decimal Amount { get; set; }
}
