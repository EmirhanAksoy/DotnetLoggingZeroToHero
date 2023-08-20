using LoggingSoruceGenerator;
using Microsoft.Extensions.Logging;


using ILoggerFactory loggerFactory = LoggerFactory.Create((configure) =>
{
    configure.AddConsole();
});

ILogger logger = loggerFactory.CreateLogger<Program>();

// No need to write this actions all the time because source generators help us 

// Check LoggingSoruceGenerator.cs
//Action<Microsoft.Extensions.Logging.ILogger, string, decimal, Exception?> logPayment =
//    LoggerMessage.Define<string, decimal>(
//        LogLevel.Information,
//        new EventId(5502, nameof(Payment)),
//        "Payment with id:{paymentId} and amount:{amount} has been successfully completed");


logger.LogPayment(Guid.NewGuid().ToString(), 5541.65m);

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
