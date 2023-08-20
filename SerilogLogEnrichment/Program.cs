using Serilog;


Serilog.ILogger logger = new LoggerConfiguration()
    .WriteTo.Console()
    .Enrich.WithMachineName()
    .Enrich.WithThreadId()
    .Enrich.WithProperty("Kiosk","KioskNo1") // custom enricher
    .CreateLogger();

Log.Logger = logger;


// In this example log echriched by WithMachineName and WithThreadId methods

// Need to install Enricher packages separately

//Packages :
// Serilog.Enrichers.Thread > for thread id
// Serilog.Enrichers.Environment > for machine name

logger.Information("This is an information log Machine :{MachineName} ThreadId:{ThreadId} Kiosk:{Kiosk} ");


