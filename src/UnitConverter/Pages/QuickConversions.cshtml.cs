using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UnitConverter.Models;
using UnitConverter.Services;

namespace UnitConverter.Pages;

public class QuickConversionsModel : ConversionsModel
{
    public string Output { get; set; } = string.Empty;
    private readonly IConversionService _conversionService;
    public bool SubmissionCheck { get; set; }

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

    public IActionResult OnGetMilesToKilometers(string input)
    {
        PerformConversion(input, ConversionTypes.MilesToKilometers);
        ViewData["Input"] = input;
        ViewData["InputUnit"] = UnitTypes.Miles;
        ViewData["OutputUnit"] = UnitTypes.Kilometers;
        return Page();
    }

    public IActionResult OnGetKilometersToMiles(string input)
    {
        PerformConversion(input, ConversionTypes.KilometersToMiles);
        ViewData["Input"] = input;
        ViewData["InputUnit"] = UnitTypes.Kilometers;
        ViewData["OutputUnit"] = UnitTypes.Miles;
        return Page();
    }

    public IActionResult OnGetFahrenheitToCelsius(string input)
    {
        PerformConversion(input, ConversionTypes.FahrenheitToCelsius);
        ViewData["Input"] = input;
        ViewData["InputUnit"] = UnitTypes.Fahrenheit;
        ViewData["OutputUnit"] = UnitTypes.Celsius;
        return Page();
    }

    public IActionResult OnGetCelsiusToFahrenheit(string input)
    {
        PerformConversion(input, ConversionTypes.CelsiusToFahrenheit);
        ViewData["Input"] = input;
        ViewData["InputUnit"] = UnitTypes.Celsius;
        ViewData["OutputUnit"] = UnitTypes.Fahrenheit;
        return Page();
    }

    public IActionResult OnGetKilogramsToPounds(string input)
    {
        PerformConversion(input, ConversionTypes.KilogramsToPounds);
        ViewData["Input"] = input;
        ViewData["InputUnit"] = UnitTypes.Kilograms;
        ViewData["OutputUnit"] = UnitTypes.Pounds;
        return Page();
    }

    public IActionResult OnGetPoundsToKilograms(string input)
    {
        PerformConversion(input, ConversionTypes.PoundsToKilograms);
        ViewData["Input"] = input;
        ViewData["InputUnit"] = UnitTypes.Pounds;
        ViewData["OutputUnit"] = UnitTypes.Kilograms;
        return Page();
    }

    public IActionResult OnGetMinutesToSeconds(string input)
    {
        PerformConversion(input, ConversionTypes.MinutesToSeconds);
        ViewData["Input"] = input;
        ViewData["InputUnit"] = UnitTypes.Minutes;
        ViewData["OutputUnit"] = UnitTypes.Seconds;
        return Page();
    }

    public IActionResult OnGetSecondsToMinutes(string input)
    {
        PerformConversion(input, ConversionTypes.SecondsToMinutes);
        ViewData["Input"] = input;
        ViewData["InputUnit"] = UnitTypes.Seconds;
        ViewData["OutputUnit"] = UnitTypes.Minutes;
        return Page();
    }

    public IActionResult PerformConversion(string input, string conversionType)
    {
        SubmissionCheck = true;
        decimal convertedInput = 0;
        try
        {
            convertedInput = Convert.ToDecimal(input);
        }
        catch (FormatException)
        {
            ViewData["ErrorMessage"] = "Input must be a valid number.";

        }
        Conversion.Output = Convert.ToString(_conversionService.Convert(convertedInput, conversionType));
        ViewData["Output"] = Conversion.Output;
        return Page();
    }
}
