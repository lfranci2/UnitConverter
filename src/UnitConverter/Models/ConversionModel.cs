using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitConverter.Models;

public class ConversionModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string Input { get; set; } = string.Empty;
    [BindProperty(SupportsGet = true)]
    public string Output { get; set; } = string.Empty;
    [BindProperty(SupportsGet = true)]
    public string ConversionType { get; set; } = string.Empty;
}
