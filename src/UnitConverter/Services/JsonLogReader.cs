using System.Text.Json;
using UnitConverter.Models;

namespace UnitConverter.Services;


public class JsonLogReader: ILogReader
{
    private readonly string _logDirectory;
    private string[] logFiles;
    public JsonLogReader(IWebHostEnvironment environment)
    {
        _logDirectory = Path.Combine(
            environment.ContentRootPath,
            "Logs");
        logFiles = Directory.GetFiles(_logDirectory, "*.json");
    }

    public IEnumerable<LogEntry> Read()
    {
        IEnumerable<LogEntry> totalLogs = new List<LogEntry>();
        foreach (string logFile in logFiles)
        {
            string[] lines = File.ReadAllLines(logFile);
            foreach (string line in lines)
            {
                // Deserialize this JSON record here.
                LogEntry? entry;
                try
                {
                    entry = JsonSerializer.Deserialize<LogEntry>(line);
                }
                catch (Exception e)
                {
                    entry = new LogEntry();
                    entry.Message = "Failed to deserialize this JSON line.";
                    entry.Level = LogLevel.Error.ToString();
                }
                if (entry.Level == null | entry.Level == "")
                {
                    entry.Level = LogLevel.Information.ToString();
                }
                totalLogs.Append(entry);
            }
        }
        return totalLogs;
    }
}
