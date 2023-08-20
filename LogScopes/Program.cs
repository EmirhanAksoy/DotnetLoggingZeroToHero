using Microsoft.Extensions.Logging;

using ILoggerFactory loggerFactory = LoggerFactory.Create((builder) =>
{
    builder.AddJsonConsole((configure) =>
    {
        // Enable scope feature
        configure.IncludeScopes = true;
        configure.JsonWriterOptions = new()
        {
            Indented = true,
        };
    });
    builder.SetMinimumLevel(LogLevel.Information);
});

// Log scopes is using to store metadata for each logs between scope boundaries

// Providers should support scope usage


ILogger logger = loggerFactory.CreateLogger<Program>();

Payment payment = new(859.54m);

logger.LogInformation("Payment requested {date:HH:mm:ss}", DateTime.UtcNow);

//inside here scope property will be provided for all logs
using (logger.BeginScope(payment))
{
    logger.LogInformation("Payment started");

    //OUTPUT

    // {
    //  "EventId": 0,
    //  "LogLevel": "Information",
    //  "Category": "Program",
    //  "Message": "Payment finished",
    //  "State": {
    //            "Message": "Payment finished",
    //    "{OriginalFormat}": "Payment finished"
    //  },
    //  "Scopes": [
    //    "Payment { Id = 1dd7af54-6d73-4223-b903-63b8c63ed3f0, Amount = 859.54 }" >> SCOPE INFO PROVIDED
    //  ]
    //}


    logger.LogInformation("Payment finished");
}

logger.LogInformation("Payment has completed {date:HH:mm:ss}", DateTime.UtcNow);

//OUT OF THE SCOPE

//{
//   "EventId": 0,
//  "LogLevel": "Information",
//  "Category": "Program",
//  "Message": "Payment has completed 15:22:29",
//  "State": {
//        "Message": "Payment has completed 15:22:29",
//    "date": "08/20/2023 15:22:29",
//    "{OriginalFormat}": "Payment has completed {date:HH:mm:ss}"
//  },
//  "Scopes": [] >> NO SCOPE INFO PROVIDED
//}


public record Payment
{
    public Payment(decimal amount)
    {
        this.Id = Guid.NewGuid().ToString();
        this.Amount = amount;
    }
    public string Id { get; set; }
    public decimal Amount { get; set; }
}