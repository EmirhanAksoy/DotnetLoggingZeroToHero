using Serilog;

// Packages
// For logger creation  > Serilog 
// For console provider > Serilog.Sinks.Console

Serilog.Core.Logger logger = new LoggerConfiguration()
       .WriteTo.Console().CreateLogger();

logger.Information("This is an information log");