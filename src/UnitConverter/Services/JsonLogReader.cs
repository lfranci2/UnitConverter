using System.Text.Json;
using UnitConverter.Models;

namespace UnitConverter.Services;

public class JsonLogReader : ILogReader
{
    private readonly string _logDirectory;

    public JsonLogReader(IWebHostEnvironment environment)
    {
        _logDirectory = Path.Combine(
            environment.ContentRootPath,
            "Logs");
    }

    public IEnumerable<LogEntry> Read()
    {
        var totalLogs = new List<LogEntry>();

        if (!Directory.Exists(_logDirectory))
        {
            return totalLogs;
        }

        foreach (string logFile in Directory.GetFiles(_logDirectory, "*.json"))
        {
            try
            {
                using var stream = new FileStream(
                    logFile,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.ReadWrite | FileShare.Delete);

                using var reader = new StreamReader(stream);

                string? line;

                while ((line = reader.ReadLine()) != null)
                {
                    LogEntry? entry;

                    try
                    {
                        entry = JsonSerializer.Deserialize<LogEntry>(line);
                    }
                    catch (JsonException)
                    {
                        entry = new LogEntry
                        {
                            Message = "Failed to deserialize this JSON line.",
                            Level = LogLevel.Error.ToString()
                        };
                    }

                    if (entry == null)
                    {
                        entry = new LogEntry
                        {
                            Message = "Failed to deserialize this JSON line.",
                            Level = LogLevel.Error.ToString()
                        };
                    }

                    if (string.IsNullOrEmpty(entry.Level))
                    {
                        entry.Level = LogLevel.Information.ToString();
                    }

                    totalLogs.Add(entry);
                }
            }
            catch (IOException)
            {
                LogEntry entry = new LogEntry
                {
                    Message = "IO exception",
                    Level = LogLevel.Error.ToString()
                };
                totalLogs.Add(entry);
            }
        }

        return totalLogs;
    }
}
