using Microsoft.Extensions.Logging;

using ILoggerFactory loggerFactory = LoggerFactory.Create((builder) =>
{
    builder.AddConsole();
    builder.SetMinimumLevel(LogLevel.Information); 
});

// Log Category is logical way to group different log entires


// No category provided
ILogger loggerWithoutCategory = loggerFactory.CreateLogger<Program>();
loggerWithoutCategory.LogInformation("Logger without category");

//OUTPUT :
//info: Program[0]
//      Logger without category

ILogger userLogCategory = loggerFactory.CreateLogger<UserLogCategory>();
userLogCategory.LogInformation("User log category");

//OUTPUT :
//info: UserLogCategory[0]
//      User log category

ILogger paymentLogCategory = loggerFactory.CreateLogger<PaymentLogCategory>();
paymentLogCategory.LogInformation("Payment log category");

//OUTPUT :
//info: PaymentLogCategory[0]
//      Payment log category


// On controller levels ILogger can be injected as ILogger<ControllerClassName> to use log categories

public class UserLogCategory { }

public class PaymentLogCategory { }
