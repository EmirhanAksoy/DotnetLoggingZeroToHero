using Serilog;

Serilog.Core.Logger logger = new LoggerConfiguration()
       .WriteTo.Console().CreateLogger();



Dictionary<int,int> magicalPairs = new() {

    {1,2}, {3,4}, {5,6}, {7,8}, {9,10}
};


// With @ operator we can log objects as json
logger.Information("Payment has been completed {@paymentData}",new Payment(99.5m));

// Dictionaries will be automatically converted to json 
logger.Information("Magical pairs {@magicalPairs}", magicalPairs);


Log.CloseAndFlush();

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