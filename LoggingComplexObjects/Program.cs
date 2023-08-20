using Microsoft.Extensions.Logging;
using System.Text.Json;

using ILoggerFactory loggerFactory = LoggerFactory.Create((builder) =>
{
    builder.AddConsole();
    builder.SetMinimumLevel(LogLevel.Information);
});


ILogger logger = loggerFactory.CreateLogger<ILogger>();

// Records will automatically will be converted to json
// But classes we need to use  json serializers

Payment payment = new(45.6m);
User user = new(Guid.NewGuid().ToString(), "blackcat", "blackcat@xx.com");

logger.LogInformation("Payment data {paymentData}", payment);

//OUTPUT :  Payment data Payment (because of the toString method was not overwritten by default like record has)

logger.LogInformation("User data {userData}", user);

//OUTPUT : User data User { id = 4a3cce95-06e2-49ac-af44-a09c12af4a83, username = blackcat, email = blackcat@xx.com }

logger.LogInformation("Payment data {paymentData}", JsonSerializer.Serialize(payment));

//OUTPUT : Payment data {"Id":"f5f16395-3008-4518-a15d-41be216c8b14","Amount":45.6}
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

public record User(string id, string username, string email);
