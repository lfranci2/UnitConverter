using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnitConverter.Models;

namespace UnitConverter.Pages;

public class ConversionsModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public ConversionModel Conversion { get; set; } = new ConversionModel();

    public void OnGet()
    {
        ViewData["ConversionType"] = Conversion.ConversionType;
        ViewData["Title"] = "Conversions";
        double convertedInput = 0.0;
        try
        {
            convertedInput = Convert.ToDouble(Conversion.Input);
        }
        catch (FormatException)
        {
            ViewData["ErrorMessage"] = "Input must be a valid number.";
        }
        double conversion = 0.0;
        switch (Conversion.ConversionType)
        {
            case ConversionTypes.MilesToKilometers:
                ViewData["InputUnit"] = "Miles";
                ViewData["OutputUnit"] = "Kilometers";
                UnitOf.Length unitMiles = new UnitOf.Length().FromMiles(convertedInput);
                conversion = unitMiles.ToKilometers();
                break;
            case ConversionTypes.KilometersToMiles:
                ViewData["InputUnit"] = "Kilometers";
                ViewData["OutputUnit"] = "Miles";
                UnitOf.Length unitKilometers = new UnitOf.Length().FromKilometers(convertedInput);
                conversion = unitKilometers.ToMiles();
                break;
            case ConversionTypes.FahrenheitToCelsius:
                ViewData["InputUnit"] = "Fahrenheit";
                ViewData["OutputUnit"] = "Celsius";
                UnitOf.Temperature unitFahrenheit = new UnitOf.Temperature().FromFahrenheit(convertedInput);
                conversion = unitFahrenheit.ToCelsius();
                break;
            case ConversionTypes.CelsiusToFahrenheit:
                ViewData["InputUnit"] = "Celsius";
                ViewData["OutputUnit"] = "Fahrenheit";
                UnitOf.Temperature unitCelsius =  new UnitOf.Temperature().FromCelsius(convertedInput);
                conversion = unitCelsius.ToFahrenheit();
                break;
            case ConversionTypes.PoundsToKilograms:
                ViewData["InputUnit"] = "Pounds";
                ViewData["OutputUnit"] = "Kilograms";
                UnitOf.Mass unitPounds = new UnitOf.Mass().FromPounds(convertedInput);
                conversion = unitPounds.ToKilograms();
                break;
            case ConversionTypes.KilogramsToPounds:
                ViewData["InputUnit"] = "Kilograms";
                ViewData["OutputUnit"] = "Pounds";
                UnitOf.Mass unitKilograms = new UnitOf.Mass().FromKilograms(convertedInput);
                conversion = unitKilograms.ToPounds();
                break;
            case ConversionTypes.SecondsToMinutes:
                ViewData["InputUnit"] = "Seconds";
                ViewData["OutputUnit"] = "Minutes";
                UnitOf.Time unitSeconds = new UnitOf.Time().FromSeconds(convertedInput);
                conversion = unitSeconds.ToMinutes();
                break;
            case ConversionTypes.MinutesToSeconds:
                ViewData["InputUnit"] = "Minutes";
                ViewData["OutputUnit"] = "Seconds";
                UnitOf.Time unitMinutes = new UnitOf.Time().FromMinutes(convertedInput);
                conversion = unitMinutes.ToSeconds();
                break;
            default:
                ViewData["ErrorMessage"] = "Unknown or unsupported conversion type.";
                break;
        }
        Conversion.Output = Convert.ToString(conversion);
        ViewData["Input"] = convertedInput;
        ViewData["Output"] = Conversion.Output;
    }
}
