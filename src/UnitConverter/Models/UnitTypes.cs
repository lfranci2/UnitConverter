namespace UnitConverter.Models;

public static class UnitTypes
{
    public const string Miles = "Miles";
    public const string Kilometers = "Kilometers";
    public const string Fahrenheit = "°F";
    public const string Celsius = "°C";
    public const string Pounds = "Pounds";
    public const string Kilograms = "Kilograms";
    public const string Minutes = "Minutes";
    public const string Seconds = "Seconds";

    public static readonly IReadOnlyDictionary<string, string> All =
        new Dictionary<string, string>
        {
            [Fahrenheit] = "Fahrenheit",
            [Celsius] = "Celsius"
        };
}
