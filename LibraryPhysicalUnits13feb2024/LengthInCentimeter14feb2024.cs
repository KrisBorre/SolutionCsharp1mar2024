namespace LibraryPhysicalUnits13feb2024
{
    public class LengthInCentimeter14feb2024 : ILength14feb2024
    {
        private double m_LengthInCentimeter;
        private double m_PrecisionInCentimeter;

        public LengthInCentimeter14feb2024(double lengthInCentimeter, double accuracyInCentimeter)
        {
            m_LengthInCentimeter = lengthInCentimeter;
            m_PrecisionInCentimeter = accuracyInCentimeter;
        }

        public double GetInCentimeter()
        {
            return m_LengthInCentimeter;
        }

        public double GetInKilometer()
        {
            return LengthCalculation14feb2024.ConvertCentimeterIntoKilometer(m_LengthInCentimeter);
        }

        public double GetInMeter()
        {
            return LengthCalculation14feb2024.ConvertCentimeterIntoMeter(m_LengthInCentimeter);
        }

        public double GetPrecisionInCentimeter()
        {
            return m_PrecisionInCentimeter;
        }

        public double GetPrecisionInMeter()
        {
            return LengthCalculation14feb2024.ConvertCentimeterIntoMeter(m_PrecisionInCentimeter);
        }

        public override string ToString()
        {
            return m_LengthInCentimeter + " m";
        }


        public static LengthInMeter14feb2024 operator +(LengthInCentimeter14feb2024 a, LengthInCentimeter14feb2024 b)
        {
            var result = LengthCalculation14feb2024.Add(a, b);
            return result;
        }

        public static LengthInMeter14feb2024 operator +(LengthInCentimeter14feb2024 a, LengthInKilometer14feb2024 b)
        {
            var result = LengthCalculation14feb2024.Add(a, b);
            return result;
        }

        public static LengthInMeter14feb2024 operator +(LengthInKilometer14feb2024 a, LengthInCentimeter14feb2024 b)
        {
            var result = LengthCalculation14feb2024.Add(a, b);
            return result;
        }


        public static LengthInMeter14feb2024 operator -(LengthInCentimeter14feb2024 a, LengthInCentimeter14feb2024 b)
        {
            var result = LengthCalculation14feb2024.Substract(a, b);
            return result;
        }

        public static LengthInMeter14feb2024 operator -(LengthInCentimeter14feb2024 a, LengthInKilometer14feb2024 b)
        {
            var result = LengthCalculation14feb2024.Substract(a, b);
            return result;
        }

        public static LengthInMeter14feb2024 operator -(LengthInKilometer14feb2024 a, LengthInCentimeter14feb2024 b)
        {
            var result = LengthCalculation14feb2024.Substract(a, b);
            return result;
        }


        public LengthInCentimeter14feb2024 MultiplyBy(double factor)
        {
            var result = new LengthInCentimeter14feb2024(this.m_LengthInCentimeter * factor, this.m_PrecisionInCentimeter * factor);
            return result;
        }

        public static LengthInCentimeter14feb2024 operator *(double factor, LengthInCentimeter14feb2024 b)
        {
            var result = new LengthInCentimeter14feb2024(factor * b.GetInCentimeter(), factor * b.GetPrecisionInCentimeter());
            return result;
        }

        public static LengthInCentimeter14feb2024 operator *(LengthInCentimeter14feb2024 a, double factor)
        {
            var result = new LengthInCentimeter14feb2024(a.GetInCentimeter() * factor, a.GetPrecisionInCentimeter() * factor);
            return result;
        }

        public LengthInMeter14feb2024 ConvertToMeter()
        {
            double lengthInMeter = LengthCalculation14feb2024.ConvertCentimeterIntoMeter(m_LengthInCentimeter);
            double precisionInMeter = LengthCalculation14feb2024.ConvertCentimeterIntoMeter(m_PrecisionInCentimeter);
            return new LengthInMeter14feb2024(lengthInMeter, precisionInMeter);
        }
    }
}
