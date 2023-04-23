using System;

namespace Converter
{
    public class Units
    {
        public enum Length
        {
            //Metric
            KiloMeter,
            HectoMeter,
            DecaMeter,
            Meter,
            DeciMeter,
            CentiMeter,
            MilliMeter,
            //Imperial
            Foot,
            Inch,
            Hand,
            Yard,
            Chain,
            Furlong,
            Mile,
            League

        }

        public enum Weight
        {
            Gigatonne,
            Megatonne,
            Tonne,
            Kilogramm,
            Gramm,
            Milligramm,
            Microgram,
            Nanogram,
            Picogram,
            USton,
            UKton,
            Pound,
            Ounce,
        }

        public enum Time
        {
            Millisecond,
            Second,
            Minute,
            Kilosecond,
            Hour,
            Day,
            Week,
            Megasecond
        }

        public enum Volume
        {
            //Metric
            Litre,
            CubicDecimetre,
            CubicMetre,
            CubicCentimetre,
            //Imperial
            CubicFoot,
            CubicInch,
            Barrel,
            USGallon,
            USPint,
            USFluidOunce
        }

        public enum Area
        {
            SquareKilometer,
            SquareHectometer,
            SquareDecameter,
            SquareMeter,
            SquareDecimeter,
            SquareCentimeter,
            SquareMillimeter,
            Hectare,
            Are,
            Centiare,
            Perch,
            Rood,
            Acre,
            SquareMile
        }

        public enum Temperature
        {
            Celsius,
            Kelvin,
            Fahrenheit,
            Rankine,
            Newton,
            Romer,
            Reaumur,
            Delisle
        }

        public enum Unit
        {
            Length,
            Weight,
            Time,
            Volume,
            Area,
            Temperature
        }
    }
}