using Serilog;

Serilog.Core.Logger logger = new LoggerConfiguration()
       .WriteTo.Console().CreateLogger();

// Serilog has also static class to log
// It is gloabally-shared logger
// We're setting gloabally-shared logger with our configured logger
// Without this line no log will be displayed
Log.Logger = logger;    

Log.Information("This is an information log");
