using Serilog;

// NOTE :
// In this example currently we have built in microsofts logs and serilog logs
// Serilog is not interated with microsoft build-in logger log yet


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Serilog.ILogger interface is an abstraction for serilog its different from Microsoft build-in logger
Serilog.ILogger logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

// Set global logger
Log.Logger = logger;

// Provide service  
builder.Services.AddSingleton(logger);

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", (Serilog.ILogger weatherForecastLogger) =>
{
    weatherForecastLogger.Information("Weather forecast retrieved | {date}",DateTime.UtcNow);
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
