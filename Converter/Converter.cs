using System;
using System.Collections;
using System.Windows.Input;
using Units;

namespace Converter
{
    abstract class Structure : IStructure
    {
        public Structure(double value, Enum unit)
        {
            Value = value;
            Unit = unit;
        }

        public Enum BaseType {
            get
            {
                return this.GetType().Name switch
                {
                    "Length" => Units.Unit.Length,
                    "Mass" => Units.Unit.Mass,
                    "Time" => Units.Unit.Time,
                    "Volume" => Units.Unit.Volume,
                    "Area" => Units.Unit.Area,
                    "Temperature" => Units.Unit.Temperature,
                    _ => throw new NotImplementedException()
                };
            }
        }
        public double Value { get; set; }
        public Enum Unit { get; set; }

        public void As(Enum unitOut)
        {
            Value = Base.Convert(Value, BaseType, Unit, unitOut);
            Unit = unitOut;
        }
                                                                                                                                                                                                                                                                                                                                                                                                                                
        public override string ToString()
        {
            return $"{Value} {Unit}";
        }
    }

    interface IStructure
    {
        Enum BaseType { get; }
        double Value { get; set; }
        Enum Unit { get; set; }
        void As(Enum unit);
        string ToString();

    }
    class Length : Structure
    {
        public Length(double value, UnitLength unit) : base(value, unit) { }
        public new void As(Enum unitOut)
        {
            Value = Base.Convert(Value, BaseType, Unit, unitOut);
            Unit = unitOut;
        }
    }

    public class Base
    {

        public static double ToLength(double value, Enum inputType)
        {
            return inputType switch
            {
                //Metric
                UnitLength.Kilometer => value * 1000d,
                UnitLength.Hectometer => value * 100d,
                UnitLength.Decameter => value * 10d,
                UnitLength.Meter => value,
                UnitLength.Decimeter => value * 0.1d,
                UnitLength.Centimeter => value * 0.01d,
                UnitLength.Millimeter => value * 0.001d,
                //Imperial
                UnitLength.Foot => value * 0.3048d,
                UnitLength.Thou => value * ToLength(0.01d, UnitLength.Inch),
                UnitLength.Line => value * ToLength(1 / 12d, UnitLength.Inch),
                UnitLength.Point => value * ToLength(1 / 72d, UnitLength.Inch),
                UnitLength.Inch => value * ToLength(1 / 12d, UnitLength.Foot),
                UnitLength.Palm => value * ToLength(3d, UnitLength.Inch),
                UnitLength.Nail => value * ToLength(1 / 16d, UnitLength.Yard),
                UnitLength.Finger => value * ToLength(1 / 8d, UnitLength.Yard),
                UnitLength.Fathom => ToLength(6d, UnitLength.Foot),
                UnitLength.Shackle => ToLength(30d, UnitLength.Yard),
                UnitLength.Mil => value * ToLength(0.001d, UnitLength.Inch),
                UnitLength.Pole => value * ToLength(0.25d, UnitLength.Chain),
                UnitLength.Hand => value * ToLength(1 / 3, UnitLength.Foot),
                UnitLength.Yard => value * ToLength(3d, UnitLength.Foot),
                UnitLength.Chain => value * ToLength(22d, UnitLength.Yard),
                UnitLength.Furlong => value * ToLength(220d, UnitLength.Yard),
                UnitLength.Link => value * ToLength(1 / 1000d, UnitLength.Furlong),
                UnitLength.Mile => value * ToLength(1760d, UnitLength.Yard),
                UnitLength.League => value * ToLength(3d, UnitLength.Mile),
                UnitLength.Cable => value * ToLength(608d, UnitLength.Foot),
                UnitLength.NauticalMile => value * ToLength(10, UnitLength.Cable),
                _ => throw new NotImplementedException()
            };
        }

        public static double ToMass(double value, Enum inputType)
        {
            return inputType switch
            {
                //Metric
                UnitMass.Gigatonne => value * 1E15d,
                UnitMass.Megatonne => value * 1E12d,
                UnitMass.Tonne => value * 1E6d,
                UnitMass.Quintal => value * 1E5d,
                UnitMass.Kilogramm => value * 1E3d,
                UnitMass.Gramm => value,
                UnitMass.Milligramm => value * 1E-03d,
                UnitMass.Microgram => value * 1E-06d,
                UnitMass.Nanogram => value * 1E-12d,
                UnitMass.Picogram => value * 1E-15d,
                //Imperial
                UnitMass.UStonne => value * ToMass(0.90718474d, UnitMass.Tonne),
                UnitMass.UKtonne => value * ToMass(1.016d, UnitMass.Tonne),
                UnitMass.Pound => 453.59d * value,
                UnitMass.Ounce => 28.35d * value,
                UnitMass.Stone => value * ToMass(14d, UnitMass.Pound),
                UnitMass.Quarter => value * ToMass(2d, UnitMass.Stone),
                UnitMass.Hundredweight => value * ToMass(4d, UnitMass.Quarter),
                UnitMass.Carat => value * ToMass(200d, UnitMass.Milligramm),
                UnitMass.Point => value * ToMass(2d, UnitMass.Milligramm),
                _ => throw new NotImplementedException()
            };
        }

        public static double ToTime(double value, Enum inputType)
        {
            return inputType switch
            {
                UnitTime.Millisecond => value * 1E-03d,
                UnitTime.Second => value,
                UnitTime.Minute => value * 60d,
                UnitTime.Kilosecond => value * 1E3d,
                UnitTime.Hour => value * ToTime(60, UnitTime.Minute),
                UnitTime.Day => value * ToTime(24, UnitTime.Hour),
                UnitTime.Week => value * ToTime(7, UnitTime.Day),
                UnitTime.Megasecond => value * 1E6d,
                _ => throw new NotImplementedException()
            };
        }

        public static double ToVolume(double value, Enum inputType)
        {
            return inputType switch
            {
                //Metric
                UnitVolume.Litre => value * 0.001d,
                UnitVolume.Millilitre => value * 1e-6d,
                UnitVolume.CubicDecimetre => value * 0.001d,
                UnitVolume.CubicMetre => value,
                UnitVolume.CubicCentimetre => value * 1e-6d,
                //Imperial
                UnitVolume.CubicFoot => value * Math.Pow(ToLength(1, UnitLength.Foot), 3d),
                UnitVolume.CubicInch => value * Math.Pow(ToLength(1, UnitLength.Inch), 3d),
                UnitVolume.CubicYard => value * Math.Pow(ToLength(1, UnitLength.Yard), 3d),
                UnitVolume.Barrel => value * ToVolume(9.702d, UnitVolume.CubicInch),
                UnitVolume.USGallon => value * ToVolume(231d, UnitVolume.CubicInch),
                UnitVolume.Gallon => value * ToVolume(1.20095042342d, UnitVolume.USGallon),
                UnitVolume.Cup => value * ToVolume(0.5d, UnitVolume.Pint),
                UnitVolume.Gill => value * ToVolume(5d, UnitVolume.FluidOunce),
                UnitVolume.USPint => value * ToVolume(16d, UnitVolume.USFluidOunce),
                UnitVolume.Pint => value * ToVolume(20, UnitVolume.FluidOunce),
                UnitVolume.USQuart => value * ToVolume(0.25d, UnitVolume.USGallon),
                UnitVolume.Quart => value * ToVolume(2d, UnitVolume.Pint),
                UnitVolume.USFluidOunce => value * ToVolume(1 / 128d, UnitVolume.USGallon),
                UnitVolume.FluidOunce => value * ToVolume(1 / 160d, UnitVolume.Gallon),
                UnitVolume.Peck => value * ToVolume(2d, UnitVolume.Gallon),
                UnitVolume.Bushel => value * ToVolume(4d, UnitVolume.Peck),
                _ => throw new NotImplementedException()
            };
        }

        public static double ToArea(double value, Enum inputType)
        {
            return inputType switch
            {
                //Mertic
                UnitArea.SquareKilometer => value * 1E6d,
                UnitArea.SquareHectometer => value * 1E4d,
                UnitArea.SquareDecameter => value * 1E2d,
                UnitArea.SquareMeter => value,
                UnitArea.SquareDecimeter => value * 1E-02d,
                UnitArea.SquareCentimeter => value * 1E-04d,
                UnitArea.SquareMillimeter => value * 1E-06d,
                UnitArea.Hectare => value * 1E4d,
                UnitArea.Are => value * 100d,
                UnitArea.Centiare => value,
                //Imperial
                UnitArea.SquareInch => value * Math.Pow(ToLength(1, UnitLength.Inch), 2),
                UnitArea.SquareFoot => value * Math.Pow(ToLength(1, UnitLength.Foot), 2),
                UnitArea.SquareYard => value * Math.Pow(ToLength(1, UnitLength.Yard), 2),
                UnitArea.Perch => value * ToArea(30.25d, UnitArea.SquareYard),
                UnitArea.Rood => value * ToArea(40d, UnitArea.Perch),
                UnitArea.Acre => value * ToArea(4d, UnitArea.Rood),
                UnitArea.SquareMile => value * Math.Pow(ToLength(1, UnitLength.Mile), 2),
                _ => throw new NotImplementedException()
            };

        }

        public static double ToCelsius(double value, Enum inputType)
        {
            return inputType switch
            {
                UnitTemperature.Celsius => value,
                UnitTemperature.Kelvin => value - 273.15d,
                UnitTemperature.Fahrenheit => (value - 32d) * (5d / 9d),
                UnitTemperature.Rankine => (value - 491.67d) * (5d / 9d),
                UnitTemperature.Newton => value * 33d / 100d,
                UnitTemperature.Romer => (value - 7.5d) * (40d / 21d),
                UnitTemperature.Reaumur => value * 1.25d,
                UnitTemperature.Delisle => (100d - value) * (2d / 3d),
                _ => throw new NotImplementedException()
            };
        }

        public static double ToTemperature(double value, Enum inputType, Enum outputType)
        {
            double celsius = ToCelsius(value, inputType);
            return outputType switch
            {
                UnitTemperature.Celsius => celsius,
                UnitTemperature.Kelvin => celsius + 273.15d,
                UnitTemperature.Fahrenheit => (celsius * 9d / 5d) + 32d,
                UnitTemperature.Rankine => (celsius + 273.15d) * 9d / 5d,
                UnitTemperature.Newton => celsius * 100d / 33d,
                UnitTemperature.Romer => (celsius * 21d / 40d) + 7.5d,
                UnitTemperature.Reaumur => celsius * 0.8d,
                UnitTemperature.Delisle => (100d - celsius) * (3d / 2d),
                _ => throw new NotImplementedException()
            };
        }

        public static double Convert(double value, Enum unit, Enum inputType, Enum outputType)
        {
            double As(Func<double, Enum, double> function)
            {
                return function(value, inputType) / function(1, outputType);
            }

            return unit switch
            {
                Units.Unit.Length => As(ToLength),
                Units.Unit.Mass => As(ToMass),
                Units.Unit.Time => As(ToTime),
                Units.Unit.Volume => As(ToVolume),
                Units.Unit.Area => As(ToArea),
                Units.Unit.Temperature => ToTemperature(value, inputType, outputType),
                _ => throw new NotImplementedException()
            };
        }

    }
}