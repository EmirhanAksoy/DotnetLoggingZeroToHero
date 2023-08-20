using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CustomLogProvider;

public class CustomFileLogProvider : ILoggerProvider, IDisposable
{
    private readonly string _filePath;
    public CustomFileLogProvider(string path)
    {
        _filePath = path;
    }
    public ILogger CreateLogger(string categoryName)
    {
        return new CustomFileLogger(_filePath);
    }

    public void Dispose()
    {

    }
}

public class CustomFileLogger : ILogger
{
    private readonly string _filePath;
    public CustomFileLogger(string filePath)
    {
        _filePath = filePath;
    }

    public IDisposable BeginScope<TState>(TState state) where TState : notnull
    {
        return NullScope.Instance;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel >= LogLevel.Debug;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        if (IsEnabled(logLevel))
        {
            string exceptionMessage = exception is not null ? JsonSerializer.Serialize(exception) : "-";
            File.AppendAllLines(_filePath,new List<string>()
            {
               $"Log Level:{nameof(logLevel)} | EventId:{eventId} | Exception:{exceptionMessage} | Message:{state} | Time:{DateTime.UtcNow}"
            });
        }
    }
}

public static class LoggerFactoryExtensions
{
    public static void AddCustomFileLog(this ILoggingBuilder loggingBuilder, string path)
    {
        loggingBuilder.AddProvider(new CustomFileLogProvider(path));
    }
}

internal sealed class NullScope : IDisposable
{
    public static NullScope Instance { get; } = new();
    public NullScope()
    {
            
    }
    public void Dispose()
    {
        
    }
}
