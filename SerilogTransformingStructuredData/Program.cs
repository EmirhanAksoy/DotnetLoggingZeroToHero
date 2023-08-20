using Serilog;

Serilog.Core.Logger logger = new LoggerConfiguration()
       .WriteTo.Console()
       .Destructure.ByTransforming<Payment>(x=>
       {
           return new
           {
               PaymentId = x.Id,
           };
       }).CreateLogger();



// Objects can be manipulate by Destructure on serilog
// Amount property of payment object will not be displayed

logger.Information("Payment has been completed successfully {@paymentData}", new Payment(88521.5m));

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