using UnitConverter.Models;

namespace UnitConverter.Services;

public class UnitOfConversionService : IConversionService
{
    public decimal Convert(decimal value, string conversionType)
    {
        switch (conversionType)
        {
            case ConversionTypes.MilesToKilometers:
                UnitOf.Length unitMiles = new UnitOf.Length().FromMiles((double)value);
                return (decimal)unitMiles.ToKilometers();
            case ConversionTypes.KilometersToMiles:
                UnitOf.Length unitKilometers = new UnitOf.Length().FromKilometers((double)value);
                return (decimal)unitKilometers.ToMiles();
            case ConversionTypes.FahrenheitToCelsius:
                UnitOf.Temperature unitFahrenheit = new UnitOf.Temperature().FromFahrenheit((double)value);
                return (decimal)unitFahrenheit.ToCelsius();
            case ConversionTypes.CelsiusToFahrenheit:
                UnitOf.Temperature unitCelsius = new UnitOf.Temperature().FromCelsius((double)value);
                return (decimal)unitCelsius.ToFahrenheit();
            case ConversionTypes.PoundsToKilograms:
                UnitOf.Mass unitPounds = new UnitOf.Mass().FromPounds((double)value);
                return (decimal)unitPounds.ToKilograms();
            case ConversionTypes.KilogramsToPounds:
                UnitOf.Mass unitKilograms = new UnitOf.Mass().FromKilograms((double)value);
                return (decimal)unitKilograms.ToPounds();
            case ConversionTypes.MinutesToSeconds:
                UnitOf.Time unitMinutes = new UnitOf.Time().FromMinutes((double)value);
                return (decimal)unitMinutes.ToSeconds();
            case ConversionTypes.SecondsToMinutes:
                UnitOf.Time unitSeconds = new UnitOf.Time().FromSeconds((double)value);
                return (decimal)unitSeconds.ToMinutes();
            default:
                throw new ArgumentException("Unknown or unsupported conversion type.");
        }
    }
}
