namespace LibraryPhysicalUnits13feb2024
{
    public class MassInKilogram : WeightInKilogram14feb2024
    {
        public MassInKilogram(double massInKilogram, double precisionInKilogram = 0) : base(massInKilogram, precisionInKilogram)
        {

        }
    }

    public class WeightInKilogram14feb2024 : IWeight7feb2024
    {
        private double m_WeightInKilogram;
        private double m_PrecisionInKilogram;

        public WeightInKilogram14feb2024(double weightInKilogram, double precisionInKilogram = 0)
        {
            m_WeightInKilogram = weightInKilogram;
            m_PrecisionInKilogram = precisionInKilogram;
        }

        public double GetInKilogram()
        {
            return m_WeightInKilogram;
        }

        public double GetInTon()
        {
            return WeightCalculation7feb2024.ConvertKilogramIntoTon(m_WeightInKilogram);
        }

        public double GetInPounds()
        {
            return WeightCalculation7feb2024.ConvertKilogramIntoPounds(m_WeightInKilogram);
        }

        public double GetPrecisionInKilogram()
        {
            return m_PrecisionInKilogram;
        }

        public IWeight7feb2024 MultiplyBy(double factor)
        {
            var result = new WeightInKilogram14feb2024(this.m_WeightInKilogram * factor);
            return result;
        }

        public static WeightInKilogram14feb2024 operator *(double factor, WeightInKilogram14feb2024 b)
        {
            var result = new WeightInKilogram14feb2024(factor * b.GetInKilogram());
            return result;
        }

        public static WeightInKilogram14feb2024 operator *(WeightInKilogram14feb2024 a, double factor)
        {
            var result = new WeightInKilogram14feb2024(a.GetInKilogram() * factor);
            return result;
        }

        public override string ToString()
        {
            return m_WeightInKilogram + " kg";
        }

        public static WeightInKilogram14feb2024 operator +(WeightInKilogram14feb2024 a, WeightInKilogram14feb2024 b)
        {
            var result = WeightCalculation7feb2024.Add(a, b);
            return result;
        }

        public static WeightInKilogram14feb2024 operator +(WeightInKilogram14feb2024 a, WeightInTon14feb2024 b)
        {
            var result = WeightCalculation7feb2024.Add(a, b);
            return result;
        }

        public static WeightInKilogram14feb2024 operator +(WeightInTon14feb2024 a, WeightInKilogram14feb2024 b)
        {
            var result = WeightCalculation7feb2024.Add(a, b);
            return result;
        }

        public static WeightInKilogram14feb2024 operator +(WeightInKilogram14feb2024 a, WeightInPounds14feb2024 b)
        {
            var result = WeightCalculation7feb2024.Add(a, b);
            return result;
        }

        public static WeightInKilogram14feb2024 operator +(WeightInPounds14feb2024 a, WeightInKilogram14feb2024 b)
        {
            var result = WeightCalculation7feb2024.Add(a, b);
            return result;
        }

        public WeightInKilogram14feb2024 DivideBy(double factor)
        {
            var result = new WeightInKilogram14feb2024(this.m_WeightInKilogram / factor, this.m_PrecisionInKilogram / factor);
            return result;
        }

        public static WeightInKilogram14feb2024 operator /(WeightInKilogram14feb2024 a, double factor)
        {
            var result = new WeightInKilogram14feb2024(a.GetInKilogram() / factor);
            return result;
        }
    }
}
