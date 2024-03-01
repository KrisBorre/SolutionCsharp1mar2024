namespace LibraryPhysicalUnits13feb2024
{
    public class LengthInMeter14feb2024 : ILength14feb2024
    {
        private double m_LengthInMeter;
        private double m_PrecisionInMeter;

        public LengthInMeter14feb2024(double lengthInMeter, double accuracyInMeter)
        {
            m_LengthInMeter = lengthInMeter;
            m_PrecisionInMeter = accuracyInMeter;
        }

        public double GetInMeter()
        {
            return m_LengthInMeter;
        }

        public double GetInKilometer()
        {
            return LengthCalculation14feb2024.ConvertMeterIntoKilometer(m_LengthInMeter);
        }

        public double GetInCentimeter()
        {
            return LengthCalculation14feb2024.ConvertMeterIntoCentimeter(m_LengthInMeter);
        }

        public double GetPrecisionInMeter()
        {
            return m_PrecisionInMeter;
        }

        public override string ToString()
        {
            return m_LengthInMeter + " m";
        }

        public LengthInMeter14feb2024 MultiplyBy(double factor)
        {
            var result = new LengthInMeter14feb2024(this.m_LengthInMeter * factor, this.m_PrecisionInMeter * factor);
            return result;
        }

        public static LengthInMeter14feb2024 operator *(double factor, LengthInMeter14feb2024 b)
        {
            var result = new LengthInMeter14feb2024(factor * b.GetInMeter(), factor * b.GetPrecisionInMeter());
            return result;
        }

        public static LengthInMeter14feb2024 operator *(LengthInMeter14feb2024 a, double factor)
        {
            var result = new LengthInMeter14feb2024(a.GetInMeter() * factor, a.GetPrecisionInMeter() * factor);
            return result;
        }

        public LengthInMeter14feb2024 DivideBy(double factor)
        {
            var result = new LengthInMeter14feb2024(this.m_LengthInMeter / factor, this.m_PrecisionInMeter / factor);
            return result;
        }

        //public static InvertedLengthInMeter operator /(double factor, LengthInMeter b)
        //{
        //    var result = new InvertedLengthInMeter(factor / b.GetInMeter(), factor / b.GetPrecisionInMeter());
        //    return result;
        //}

        public static LengthInMeter14feb2024 operator /(LengthInMeter14feb2024 a, double factor)
        {
            var result = new LengthInMeter14feb2024(a.GetInMeter() / factor, a.GetPrecisionInMeter() / factor);
            return result;
        }

        public static AreaInSquareMeter operator *(LengthInMeter14feb2024 a, LengthInMeter14feb2024 b)
        {
            var result = AreaCalculation.Multiply(a, b);
            return result;
        }

        public static AreaInSquareMeter operator *(LengthInMeter14feb2024 a, LengthInCentimeter14feb2024 b)
        {
            var result = AreaCalculation.Multiply(a, b);
            return result;
        }

        public static AreaInSquareMeter operator *(LengthInCentimeter14feb2024 a, LengthInMeter14feb2024 b)
        {
            var result = AreaCalculation.Multiply(a, b);
            return result;
        }

        public static AreaInSquareMeter operator *(LengthInMeter14feb2024 a, LengthInKilometer14feb2024 b)
        {
            var result = AreaCalculation.Multiply(a, b);
            return result;
        }

        public static AreaInSquareMeter operator *(LengthInKilometer14feb2024 a, LengthInMeter14feb2024 b)
        {
            var result = AreaCalculation.Multiply(a, b);
            return result;
        }

        public static LengthInMeter14feb2024 operator +(LengthInMeter14feb2024 a, LengthInMeter14feb2024 b)
        {
            var result = LengthCalculation14feb2024.Add(a, b);
            return result;
        }

        public static LengthInMeter14feb2024 operator +(LengthInMeter14feb2024 a, LengthInCentimeter14feb2024 b)
        {
            var result = LengthCalculation14feb2024.Add(a, b);
            return result;
        }

        public static LengthInMeter14feb2024 operator +(LengthInCentimeter14feb2024 a, LengthInMeter14feb2024 b)
        {
            var result = LengthCalculation14feb2024.Add(a, b);
            return result;
        }

        public static LengthInMeter14feb2024 operator +(LengthInMeter14feb2024 a, LengthInKilometer14feb2024 b)
        {
            var result = LengthCalculation14feb2024.Add(a, b);
            return result;
        }

        public static LengthInMeter14feb2024 operator +(LengthInKilometer14feb2024 a, LengthInMeter14feb2024 b)
        {
            var result = LengthCalculation14feb2024.Add(a, b);
            return result;
        }

        public static LengthInMeter14feb2024 operator -(LengthInMeter14feb2024 a, LengthInCentimeter14feb2024 b)
        {
            var result = LengthCalculation14feb2024.Substract(a, b);
            return result;
        }

        public static LengthInMeter14feb2024 operator -(LengthInMeter14feb2024 a, LengthInMeter14feb2024 b)
        {
            var result = LengthCalculation14feb2024.Substract(a, b);
            return result;
        }

        public static LengthInMeter14feb2024 operator -(LengthInCentimeter14feb2024 a, LengthInMeter14feb2024 b)
        {
            var result = LengthCalculation14feb2024.Substract(a, b);
            return result;
        }

        public static LengthInMeter14feb2024 operator -(LengthInMeter14feb2024 a, LengthInKilometer14feb2024 b)
        {
            var result = LengthCalculation14feb2024.Substract(a, b);
            return result;
        }

        public static LengthInMeter14feb2024 operator -(LengthInKilometer14feb2024 a, LengthInMeter14feb2024 b)
        {
            var result = LengthCalculation14feb2024.Substract(a, b);
            return result;
        }

        public LengthInCentimeter14feb2024 ConvertToCentimeter()
        {
            double lengthInCentimeter = LengthCalculation14feb2024.ConvertMeterIntoCentimeter(m_LengthInMeter);
            double precisionInCentimeter = LengthCalculation14feb2024.ConvertMeterIntoCentimeter(m_PrecisionInMeter);
            return new LengthInCentimeter14feb2024(lengthInCentimeter, precisionInCentimeter);
        }

    }
}
