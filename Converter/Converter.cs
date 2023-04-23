using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System;
using Units;

namespace Converter
{
    public class Mesuarement
    {
        public static double ToLength(double value, Length inputType)
        {
            return inputType switch
            {
                //Metric
                Length.KiloMeter => value * 1000d,
                Length.HectoMeter => value * 100d,
                Length.DecaMeter => value * 10d,
                Length.Meter => value,
                Length.DeciMeter => value * 1E-01d,
                Length.CentiMeter => value * 1E-02d,
                Length.MilliMeter => value * 1E-03d,
                //Imperial
                Length.Foot => value * 0.3048d,
                Length.Inch => value * ToLength(1d, Length.Foot) / 12d,
                Length.Hand => value * ToLength(1d, Length.Foot) / 3d,
                Length.Yard => value * ToLength(3d, Length.Foot),
                Length.Chain => value * ToLength(66d, Length.Foot),
                Length.Furlong => value * ToLength(220d, Length.Yard),
                Length.Mile => value * ToLength(1760d, Length.Yard),
                Length.League => value * ToLength(3d, Length.Mile),
                _ => throw new NotImplementedException()
            };
        }

        public static double ToWeight(double value, Weight inputType)
        {
            return inputType switch
            {
                //Metric
                Weight.Gigatonne => value * 1E15d,
                Weight.Megatonne => value * 1E12d,
                Weight.Tonne => value * 1E6d,
                Weight.Kilogramm => value * 1E3d,
                Weight.Gramm => value,
                Weight.Milligramm => value * 1E-03d,
                Weight.Microgram => value * 1E-06d,
                Weight.Nanogram => value * 1E-12d,
                Weight.Picogram => value * 1E-15d,
                //Imperial
                Weight.USton => value * ToWeight(0.907d, Weight.Tonne),
                Weight.UKton => value * ToWeight(1.016d, Weight.Tonne),
                Weight.Pound => 453.59d * value,
                Weight.Ounce => 28.35d * value,
                _ => throw new NotImplementedException()
            };
        }

        public static double ToTime(double value, Time inputType)
        {
            return inputType switch
            {
                Time.Millisecond => value * 1E-03d,
                Time.Second => value,
                Time.Minute => value * 60d,
                Time.Kilosecond => value * 1E3d,
                Time.Hour => value * ToTime(60, Time.Minute),
                Time.Day => value * ToTime(24, Time.Hour),
                Time.Week => value * ToTime(7, Time.Day),
                Time.Megasecond => value * 1E6d,
                _ => throw new NotImplementedException()
            };
        }

        public static double ToVolume(double value, Volume inputType)
        {
            return inputType switch
            {
                //Metric
                Volume.Litre => value * 0.001d,
                Volume.CubicDecimetre => value * ToVolume(1, Volume.Litre),
                Volume.CubicMetre => value,
                Volume.CubicCentimetre => value * 1e-6d,
                //Imperial
                Volume.CubicFoot => value * Math.Pow(ToLength(1, Length.Foot), 3d),
                Volume.CubicInch => value * Math.Pow(ToLength(1, Length.Inch), 3d),
                Volume.Barrel => value * ToVolume(9.702d, Volume.CubicInch),
                Volume.USGallon => value * ToVolume(231d, Volume.CubicInch),
                Volume.USPint => value * ToVolume(1, Volume.USGallon) / 8d,
                Volume.USFluidOunce => value * ToVolume(1, Volume.USGallon) / 128d,
                _ => throw new NotImplementedException()
            };
        }

        public static double ToArea(double value, Area inputType)
        {
            return inputType switch
            {
                //Mertic
                Area.SquareKilometer => value * 1E6d,
                Area.SquareHectometer => value * 1E4d,
                Area.SquareDecameter => value * 1E2d,
                Area.SquareMeter => value,
                Area.SquareDecimeter => value * 1E-02d,
                Area.SquareCentimeter => value * 1E-04d,
                Area.SquareMillimeter => value * 1E-06d,
                Area.Hectare => value * ToArea(1, Area.SquareHectometer),
                Area.Are => value * ToArea(1, Area.SquareDecameter),
                Area.Centiare => value * ToArea(1, Area.SquareMeter),
                //Imperial
                Area.Perch => value * 30.25 * Math.Pow(ToLength(1, Length.Yard), 2),
                Area.Rood => value * ToArea(40, Area.Perch),
                Area.Acre => value * ToArea(4, Area.Rood),
                Area.SquareMile => value * ToArea(640, Area.Acre),
                _ => throw new NotImplementedException()
            };

        }

        public static double ToCelsius(double value, Temperature inputType)
        {
            return inputType switch
            {
                Temperature.Celsius => value,
                Temperature.Kelvin => value - 273.15d,
                Temperature.Fahrenheit => (value - 32d) * (5d / 9d),
                Temperature.Rankine => (value - 491.67d) * (5d / 9d),
                Temperature.Newton => value * 33d / 100d,
                Temperature.Romer => (value - 7.5d) * (40d / 21d),
                Temperature.Reaumur => value * 1.25d,
                Temperature.Delisle => (100d - value) * (2d / 3d),
                _ => throw new NotImplementedException()
            };
        }

        public static double ToTemperature(double value, Temperature inputType, Temperature outputType)
        {
            double celsius = ToCelsius(value, inputType);
            return outputType switch
            {
                Temperature.Celsius => celsius,
                Temperature.Kelvin => celsius + 273.15d,
                Temperature.Fahrenheit => (celsius * 9d / 5d) + 32d,
                Temperature.Rankine => (celsius + 273.15d) * 9d / 5d,
                Temperature.Newton => celsius * 100d / 33d,
                Temperature.Romer => (celsius * 21d / 40d) + 7.5d,
                Temperature.Reaumur => celsius * 0.8d,
                Temperature.Delisle => (100d - celsius) * (3d / 2d),
                _ => throw new NotImplementedException()
            };
        }

        public static double Convertation(double value, Unit unit, object inputType, object outputType)
        {
            double As<T>(Func<double, T, double> function)
            {
                return function(value, (T)inputType) / function(1, (T)outputType);
            }

            return unit switch
            {
                Unit.Length => As<Length>(ToLength),
                Unit.Weight => As<Weight>(ToWeight),
                Unit.Time => As<Time>(ToTime),
                Unit.Volume => As<Volume>(ToVolume),
                Unit.Area => As<Area>(ToArea),
                Unit.Temperature => ToTemperature(value, (Temperature)inputType, (Temperature)outputType),
                _ => throw new NotImplementedException()
            };
        }
    }
}