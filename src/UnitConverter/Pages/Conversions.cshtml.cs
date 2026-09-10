using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitConverter.Pages;

public class ConversionsModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string Input { get; set; } = string.Empty;
    public string Output { get; set; } = string.Empty;
    [BindProperty(SupportsGet = true)]
    public string ConversionType { get; set; } = string.Empty;

    public void OnGet(string conversionType, string input)
    {
        ConversionType = conversionType;
        Input = input;
        ViewData["ConversionType"] = ConversionType;
        ViewData["Title"] = "Conversions";
        double convertedInput = 0.0;
        try
        {
            convertedInput = Convert.ToDouble(Input);
        }
        catch (FormatException)
        {
            @ViewData["ErrorMessage"] = "Input must be a valid number.";
        }
        double conversion = 0.0;
        switch (conversionType.ToLower())
        {
            case "milestokilometers":
                @ViewData["InputUnit"] = "Miles";
                @ViewData["OutputUnit"] = "Kilometers";
                UnitOf.Length unitMiles = new UnitOf.Length().FromMiles(convertedInput);
                conversion = unitMiles.ToKilometers();
                break;
            case "kilometerstomiles":
                @ViewData["InputUnit"] = "Kilometers";
                @ViewData["OutputUnit"] = "Miles";
                UnitOf.Length unitKilometers = new UnitOf.Length().FromKilometers(convertedInput);
                conversion = unitKilometers.ToMiles();
                break;
            case "fahrenheittocelsius":
                @ViewData["InputUnit"] = "Fahrenheit";
                @ViewData["OutputUnit"] = "Celsius";
                UnitOf.Temperature unitFahrenheit = new UnitOf.Temperature().FromFahrenheit(convertedInput);
                conversion = unitFahrenheit.ToCelsius();
                break;
            case "celsiustofahrenheit":
                @ViewData["InputUnit"] = "Celsius";
                @ViewData["OutputUnit"] = "Fahrenheit";
                UnitOf.Temperature unitCelsius =  new UnitOf.Temperature().FromCelsius(convertedInput);
                conversion = unitCelsius.ToFahrenheit();
                break;
            case "poundstokilograms":
                @ViewData["InputUnit"] = "Pounds";
                @ViewData["OutputUnit"] = "Kilograms";
                UnitOf.Mass unitPounds = new UnitOf.Mass().FromPounds(convertedInput);
                conversion = unitPounds.ToKilograms();
                break;
            case "kilogramstopounds":
                @ViewData["InputUnit"] = "Kilograms";
                @ViewData["OutputUnit"] = "Pounds";
                UnitOf.Mass unitKilograms = new UnitOf.Mass().FromKilograms(convertedInput);
                conversion = unitKilograms.ToPounds();
                break;
            case "secondstominutes":
                @ViewData["InputUnit"] = "Seconds";
                @ViewData["OutputUnit"] = "Minutes";
                UnitOf.Time unitSeconds = new UnitOf.Time().FromSeconds(convertedInput);
                conversion = unitSeconds.ToMinutes();
                break;
            case "minutestoseconds":
                @ViewData["InputUnit"] = "Minutes";
                @ViewData["OutputUnit"] = "Seconds";
                UnitOf.Time unitMinutes = new UnitOf.Time().FromMinutes(convertedInput);
                conversion = unitMinutes.ToSeconds();
                break;
            default:
                @ViewData["ErrorMessage"] = "Unknown conversion type.";
                break;
        }
        Output = Convert.ToString(conversion);
        ViewData["Input"] = convertedInput;
        ViewData["Output"] = Output;
    }
}
