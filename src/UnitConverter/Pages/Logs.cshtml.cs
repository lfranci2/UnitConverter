using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnitConverter.Models;

namespace UnitConverter.Pages;

public class Logs : PageModel
{
    private readonly ILogReader _logger;

    public IEnumerable<LogEntry> Entries { get; set; }

    [BindProperty(SupportsGet = true)]
    public string Search { get; set; } = string.Empty;
    [BindProperty(SupportsGet = true)]
    public string Level { get; set; } = string.Empty;
    [BindProperty(SupportsGet = true)]
    public string ConversionType { get; set; } = string.Empty;
    public bool SubmissionCheck { get; set; }

    public Logs(ILogReader logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        SubmissionCheck = true;
        var filteredEntries = new List<LogEntry>();

        foreach (var log in _logger.Read())
        {
            if (!string.IsNullOrEmpty(Search) &&
                !log.Message.Contains(
                    Search, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            if (!string.IsNullOrEmpty(Level) &&
                log.Level != Level)
            {
                continue;
            }

            if (!string.IsNullOrEmpty(ConversionType) &&
                log.ConversionType != ConversionType)
            {
                continue;
            }
            filteredEntries.Add(log);
        }

        Entries = filteredEntries;
    }
}
