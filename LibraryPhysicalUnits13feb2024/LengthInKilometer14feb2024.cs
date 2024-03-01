namespace LibraryPhysicalUnits13feb2024
{
    public class LengthInKilometer14feb2024 : ILength14feb2024
    {
        private double m_LengthInKilometer;
        private double m_PrecisionInKilometer;

        public LengthInKilometer14feb2024(double lengthInKilometer, double accuracyInKilometer)
        {
            m_LengthInKilometer = lengthInKilometer;
            m_PrecisionInKilometer = accuracyInKilometer;
        }

        public double GetInKilometer()
        {
            return m_LengthInKilometer;
        }

        public double GetInMeter()
        {
            return LengthCalculation14feb2024.ConvertKilometerIntoMeter(m_LengthInKilometer);
        }

        public double GetInCentimeter()
        {
            return LengthCalculation14feb2024.ConvertKilometerIntoCentimeter(m_LengthInKilometer);
        }

        public double GetPrecisionInKilometer()
        {
            return m_PrecisionInKilometer;
        }

        public double GetPrecisionInMeter()
        {
            return LengthCalculation14feb2024.ConvertKilometerIntoMeter(m_PrecisionInKilometer);
        }

        public override string ToString()
        {
            return m_LengthInKilometer + " km";
        }

        public LengthInKilometer14feb2024 MultiplyBy(double factor)
        {
            var result = new LengthInKilometer14feb2024(this.m_LengthInKilometer * factor, this.m_PrecisionInKilometer * factor);
            return result;
        }

        public static LengthInKilometer14feb2024 operator *(double factor, LengthInKilometer14feb2024 b)
        {
            var result = new LengthInKilometer14feb2024(factor * b.GetInKilometer(), factor * b.GetPrecisionInKilometer());
            return result;
        }

        public static LengthInKilometer14feb2024 operator *(LengthInKilometer14feb2024 a, double factor)
        {
            var result = new LengthInKilometer14feb2024(a.GetInKilometer() * factor, a.GetPrecisionInKilometer() * factor);
            return result;
        }


    }
}
