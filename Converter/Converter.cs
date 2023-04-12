using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System;
using System.Xml;

namespace Converter
{

    public readonly struct Length
    {
        //Metric
        public static double KiloMeter = 1000d;
        public static double HectoMeter = 100d;
        public static double DecaMeter = 10d;
        public static double Meter = 1d;
        public static double DeciMeter = 1E-01d;
        public static double CentiMeter = 1E-02d;
        public static double MilliMeter = 1E-03d;
        //Imperial
        public static double Foot = 0.3048d;
        public static double Inch = Foot / 12d;
        public static double Hand = Foot / 3d;
        public static double Yard = 3d * Foot;
        public static double Chain = 66d * Foot;
        public static double Furlong = 220d * Yard;
        public static double Mile = 1760d * Yard;
        public static double League = 3d * Mile;
    }

    public readonly struct Weight
    {
        //Metric
        public static double gigatonne = 1E15d;
        public static double megatonne = 1E12d;
        public static double tonne = 1E6d;
        public static double kilogramm = 1E3d;
        public static double gramm = 1d;
        public static double milligramm = 1E-03d;
        public static double microgram = 1E-06d;
        public static double nanogram = 1E-12d;
        public static double picogram = 1E-15d;
        //Imperial
        public static double USton = 0.907d * tonne;
        public static double UKton = 1.016d * tonne;
        public static double pound = 453.59d;
        public static double ounce = 28.35d;
    }

    class Temperature
    {
        public Temperature(double value) {
            Value = value;
        }

        public Temperature(double value, string inputType) : this(value)
        {

            Value = value;
            InputType = inputType;
            this.From(InputType);
        }

        public Temperature(double value, string inputType, string outputType) : this(value)
        {
            Value = this.From(inputType).To(outputType).Value;
        }

        public double Value { get; set; }
        public string InputType { get; set; }

        public Dictionary<string, double> ToDictionary()
        {
            Dictionary<string, double> result = new Dictionary<string, double>();
            string[] values = { "Celsius" , "Kelvin" , "Fahrenheit" , "Rankine" , "Newton", "Romer", "Reaumur", "Delisle" };
            foreach (string value in values)
            {
                double temp = Value;
                result.Add(value, this.To(value).Value);
                Value = temp;
            }
            return result;
        }

        public Temperature From(string inputType)
        {
            switch (inputType)
            {
                case "Celsius":
                    Value = Value;
                    break;
                case "Kelvin":
                    Value -= 273.15d;
                    break;
                case "Fahrenheit":
                    Value = (Value - 32d) * (5d / 9d);
                    break;
                case "Rankine":
                    Value = (Value - 491.67d) * (5d / 9d);
                    break;
                case "Newton":
                    Value = Value * 33d / 100d;
                    break;
                case "Romer":
                    Value = (Value - 7.5d) * (40d / 21d);
                    break;
                case "Reaumur":
                    Value *= 1.25d;
                    break;
                case "Delisle":
                    Value = (100d - Value) * ( 2d /3d );
                    break;
            }
            return this;
        }

        public Temperature To(string outputType)
        {
            switch (outputType)
            {
                case "Celsius":
                    Value = Value;
                    break;
                case "Kelvin":
                    Value += 273.15d;
                    break;
                case "Fahrenheit":
                    Value = (Value * 9d / 5d) + 32d;
                    break;
                case "Rankine":
                    Value = (Value + 273.15d) * 9d / 5d;
                    break;
                case "Newton":
                    Value = Value * 100d / 33d;
                    break;
                case "Romer":
                    Value = (Value * 21d / 40d) + 7.5d;
                    break;
                case "Reaumur":
                    Value *= 0.8d;
                    break;   
                case "Delisle":
                    Value = (100d - Value) * (3d / 2d);
                    break;
            }
            return this;
        }


    }

    public readonly struct Time
    {
        public static double Millisecond = 1E-03d;
        public static double Second = 1d;
        public static double Minute = 60d;
        public static double Kilosecond = 1E3d;
        public static double Hour = 60d * Minute;
        public static double Day = 24d * Hour;
        public static double Week = 7d * Day;
        public static double Megasecond = 1E6d;
    }

    public readonly struct Volume
    {
        //Metric
        public static double Litre = 0.001d;
        public static double CubicDecimetre = Litre;
        public static double CubicMetre = 1d;
        public static double CubicCentimetre = 1e-6d;
        //Imperial
        public static double CubicFoot = Math.Pow(Length.Foot, 3d);
        public static double CubicInch = Math.Pow(Length.Inch, 3d);
        public static double Barrel = 9.702d * CubicInch;
        public static double USGallon = 231d * CubicInch;
        public static double USPint = USGallon / 8d;
        public static double USFluidOunce = USGallon / 128d;
    }

    public readonly struct Area
    {
        //Mertic
        public static double SquareKilometer = 1E6d;
        public static double SquareHectometer = 1E4d;
        public static double SquareDecameter = 1E2d;
        public static double SquareMeter = 1d;
        public static double SquareDecimeter = 1E-02d;
        public static double SquareCentimeter = 1E-04d;
        public static double SquareMillimeter = 1E-06d;
        public static double Hectare = SquareHectometer;
        public static double Are = SquareDecameter;
        public static double Centiare = SquareMeter;
        //Imperial
        public static double Perch = 30.25 * Math.Pow(Length.Yard, 2);
        public static double Rood = 40 * Perch;
        public static double Acre = 4 * Rood;
        public static double SquareMile = 640 * Acre;

    }
    class Test<T>
    {
        private static string[] Fields()
        {
            return typeof(T).GetFields().Select(item => item.Name).ToArray();
        }

        public static Dictionary<string, double> ToDictionary()
        {
            Dictionary<string, double> temp = new Dictionary<string, double>();
            FieldInfo[] members = typeof(T).GetFields();
            foreach (FieldInfo member in members)
            {
                temp.Add(member.Name, GetValue(member.Name));
            }
            return temp;
        }

        private static double GetValue(string field)
        {
            T instance = (T)Activator.CreateInstance<T>();
            var value = typeof(T).GetField(field).GetValue(instance);
            return Convert.ToDouble(value);

        }
    }

    class Measurement
    {
        public Measurement(double value, string unit, string inputValue, string outValue)
        {
            Value = value;
            Unit = unit;
            Input = inputValue;
            Output = outValue;
        }

        public string Unit { get; set; }
        public double Value { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }

        public double Convert()
        {

            return Value * GetValue(Input) / GetValue(Output);
        }

        public double GetValue(string name)
        {
            var instance = Assembly.GetExecutingAssembly().CreateInstance($"{GetType().Namespace}.{Unit}");
            return (double)instance.GetType().GetField(name).GetValue(instance);
        }
    }

}