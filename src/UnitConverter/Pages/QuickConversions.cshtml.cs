using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UnitConverter.Services;

namespace UnitConverter.Pages;

public class QuickConversionsModel : ConversionsModel
{
    public string Output { get; set; } = string.Empty;
    private readonly IConversionService _conversionService;

    public QuickConversionsModel(IConversionService conversionService)
    {
        _conversionService = conversionService;
    }

    public IEnumerable<SelectListItem> PoundOptions =>
    [
        new("1 pound", "1"),
        new("5 pounds", "5"),
        new("10 pounds", "10"),
        new("25 pounds", "25"),
        new("50 pounds", "50")
    ];

    private IActionResult RedirectToConversion(string conversionType, string input)
    {
        return RedirectToPage(
            "/Conversions",
            new
            {
                conversionType,
                input
            });
    }

    public IActionResult OnGetMilesToKilometers(decimal input)
    {
        Conversion.Output = Convert.ToString(_conversionService.Convert(input, ConversionTypes.MilesToKilometers));
        return Page();
    }

    public IActionResult OnGetKilometersToMiles(string input)
    {
        return RedirectToConversion(ConversionTypes.KilometersToMiles, input);
    }

    public IActionResult OnGetFahrenheitToCelsius(string input)
    {
        return RedirectToConversion(ConversionTypes.FahrenheitToCelsius, input);
    }

    public IActionResult OnGetCelsiusToFahrenheit(string input)
    {
        return RedirectToConversion(ConversionTypes.CelsiusToFahrenheit, input);
    }

    public IActionResult OnGetKilogramsToPounds(string input)
    {
        return RedirectToConversion(ConversionTypes.KilogramsToPounds, input);
    }

    public IActionResult OnGetPoundsToKilograms(string input)
    {
        return RedirectToConversion(ConversionTypes.PoundsToKilograms, input);
    }

    public IActionResult OnGetMinutesToSeconds(string input)
    {
        return RedirectToConversion(ConversionTypes.MinutesToSeconds, input);
    }

    public IActionResult OnGetSecondsToMinutes(string input)
    {
        return RedirectToConversion(ConversionTypes.SecondsToMinutes, input);
    }

    public IActionResult PerformConversion(string input, string conversionType)
    {

    }
}
