using Destructurama;
using Destructurama.Attributed;
using Serilog;

Serilog.Core.Logger logger = new LoggerConfiguration()
       .Destructure.UsingAttributes() // >> its required for masking
       .WriteTo.Console().CreateLogger();


User user = new("Elon Must", "elon@x.com");

logger.Information("User has been created {@userData}", user);

// To mask sensitive data Destructurama.Attributed package is needed

public class User
{
    public User(string name,string email)
    {
        this.Id = Guid.NewGuid().ToString();  
        this.Name = name;
        this.Email = email;
        this.Password= Guid.NewGuid().ToString();
        this.NationalId = Guid.NewGuid().ToString();
    }
    public string Id { get; set; }
    public string Name { get; set; }

    [LogMasked(ShowFirst = 3)]// will mask password and show first three character
    public string NationalId { get; set; }

    [LogMasked(PreserveLength = true)] // will mask password and preserve length
    public string Email { get; set; }

    [LogMasked] // will mask password information on logs
    public string Password { get; set; }

    [NotLogged] // address will be displayed on logs
    public string Address { get; set; }
}