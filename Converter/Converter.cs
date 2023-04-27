using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using Units;

namespace Converter
{
    public abstract class Quantity
    {
        public Quantity(double value, Unit unit)
        { 
            Value = value;
            Unit = unit;
        }

        public double Value { get; protected set; }
        public Unit Unit { get; protected set; }
    }

    class UnitVolume : Quantity
    {
        public UnitVolume(double value, Unit unit) : base(value, unit)
        {

        }
    }

    public class Mesuarement : Quantity
    {
        public Mesuarement(double value, Unit unit, object inputType, object outputType) : base(value, unit)
        {

        }


        public static double ToLength(double value, Length inputType)
        {
            return inputType switch
            {
                //Metric
                Length.Kilometer => value * 1000d,
                Length.Hectometer => value * 100d,
                Length.Decameter => value * 10d,
                Length.Meter => value,
                Length.Decimeter => value * 0.1d,
                Length.Centimeter => value * 0.01d,
                Length.Millimeter => value * 0.001d,
                //Imperial
                Length.Foot => value * 0.3048d,
                Length.Thou => value * ToLength(0.01d, Length.Inch),
                Length.Line => value * ToLength(1/12d, Length.Inch),
                Length.Point => value * ToLength(1/72d, Length.Inch),
                Length.Inch => value * ToLength(1/12d, Length.Foot),
                Length.Palm => value * ToLength(3d, Length.Inch),
                Length.Nail => value * ToLength(1/16d, Length.Yard),
                Length.Finger => value * ToLength(1/8d, Length.Yard),
                Length.Fathom => ToLength(6d, Length.Foot),
                Length.Shackle => ToLength(30d, Length.Yard),
                Length.Mil => value * ToLength(0.001d, Length.Inch),
                Length.Pole => value * ToLength(0.25d, Length.Chain),
                Length.Hand => value * ToLength(1/3, Length.Foot),
                Length.Yard => value * ToLength(3d, Length.Foot),
                Length.Chain => value * ToLength(22d, Length.Yard),
                Length.Furlong => value * ToLength(220d, Length.Yard),
                Length.Link => value * ToLength(1/1000d, Length.Furlong),
                Length.Mile => value * ToLength(1760d, Length.Yard),
                Length.League => value * ToLength(3d, Length.Mile),
                Length.Cable => value * ToLength(608d, Length.Foot),
                Length.NauticalMile => value * ToLength(10, Length.Cable),
                _ => throw new NotImplementedException()
            };
        }

        public static double ToMass(double value, Mass inputType)
        {
            return inputType switch
            {
                //Metric
                Mass.Gigatonne => value * 1E15d,
                Mass.Megatonne => value * 1E12d,
                Mass.Tonne => value * 1E6d,
                Mass.Quintal => value * 1E5d,
                Mass.Kilogramm => value * 1E3d,
                Mass.Gramm => value,
                Mass.Milligramm => value * 1E-03d,
                Mass.Microgram => value * 1E-06d,
                Mass.Nanogram => value * 1E-12d,
                Mass.Picogram => value * 1E-15d,
                //Imperial
                Mass.UStonne => value * ToMass(0.907d, Mass.Tonne),
                Mass.UKtonne => value * ToMass(1.016d, Mass.Tonne),
                Mass.Pound => 453.59d * value,
                Mass.Ounce => 28.35d * value,
                Mass.Stone => value * ToMass(14d, Mass.Pound),
                Mass.Quarter => value * ToMass(2d, Mass.Stone),
                Mass.Hundredweight => value * ToMass(4d, Mass.Quarter),
                Mass.Carat => value * ToMass(200d, Mass.Milligramm),
                Mass.Point => value * ToMass(2d, Mass.Milligramm),
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
                Volume.Millilitre => value * 1e-6d,
                Volume.CubicDecimetre => value * 0.001d,
                Volume.CubicMetre => value,
                Volume.CubicCentimetre => value * 1e-6d,
                //Imperial
                Volume.CubicFoot => value * Math.Pow(ToLength(1, Length.Foot), 3d),
                Volume.CubicInch => value * Math.Pow(ToLength(1, Length.Inch), 3d),
                Volume.CubicYard => value * Math.Pow(ToLength(1, Length.Yard), 3d),
                Volume.Barrel => value * ToVolume(9.702d, Volume.CubicInch),
                Volume.USGallon => value * ToVolume(231d, Volume.CubicInch),
                Volume.Gallon => value * ToVolume(1.20095042342d, Volume.USGallon),
                Volume.Cup => value * ToVolume(0.5d, Volume.Pint),
                Volume.Gill => value * ToVolume(5d, Volume.FluidOunce),
                Volume.USPint => value * ToVolume(16d, Volume.USFluidOunce), 
                Volume.Pint => value * ToVolume(20, Volume.FluidOunce),
                Volume.USQuart => value * ToVolume(0.25d, Volume.USGallon),
                Volume.Quart => value * ToVolume(2d, Volume.Pint),
                Volume.USFluidOunce => value * ToVolume(1/128d, Volume.USGallon),
                Volume.FluidOunce => value * ToVolume(1/160d, Volume.Gallon),
                Volume.Peck => value * ToVolume(2d, Volume.Gallon),
                Volume.Bushel => value * ToVolume(4d, Volume.Peck),
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
                Area.Hectare => value *  1E4d,
                Area.Are => value * 100d,
                Area.Centiare => value,
                //Imperial
                Area.SquareInch => value * Math.Pow(ToLength(1, Length.Inch), 2),
                Area.SquareFoot => value * Math.Pow(ToLength(1, Length.Foot), 2),
                Area.SquareYard => value * Math.Pow(ToLength(1, Length.Yard), 2),
                Area.Perch => value * ToArea(30.25d, Area.SquareYard),
                Area.Rood => value * ToArea(40d, Area.Perch),
                Area.Acre => value * ToArea(4d, Area.Rood),
                Area.SquareMile => value * Math.Pow(ToLength(1, Length.Mile), 2),
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
                Unit.Mass => As<Mass>(ToMass),
                Unit.Time => As<Time>(ToTime),
                Unit.Volume => As<Volume>(ToVolume),
                Unit.Area => As<Area>(ToArea),
                Unit.Temperature => ToTemperature(value, (Temperature)inputType, (Temperature)outputType),
                _ => throw new NotImplementedException()
            };
        }
    }
}