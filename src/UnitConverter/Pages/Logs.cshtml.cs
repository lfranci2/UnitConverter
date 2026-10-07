using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitConverter.Pages;

public class Logs : PageModel
{
    private readonly ILogReader _logger;
    [BindProperty(SupportsGet = true)]
    public string Entries { get; set; } = string.Empty;
    [BindProperty(SupportsGet = true)]
    public string Search { get; set; } = string.Empty;
    [BindProperty(SupportsGet = true)]
    public string Level { get; set; } = string.Empty;
    [BindProperty(SupportsGet = true)]
    public string ConversionType { get; set; } = string.Empty;

    public Logs(ILogReader logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
