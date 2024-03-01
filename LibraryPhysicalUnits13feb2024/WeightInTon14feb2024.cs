namespace LibraryPhysicalUnits13feb2024
{
    public class MassInTon : WeightInTon14feb2024
    {
        public MassInTon(double massInTon, double accuracyInTon = 0) : base(massInTon, accuracyInTon)
        {

        }
    }

    // https://en.wikipedia.org/wiki/Tonne
    // https://en.wikipedia.org/wiki/Ton
    public class WeightInTon14feb2024 : IWeight7feb2024
    {
        private double m_WeightInTon;
        private double m_PrecisionInTon;

        public WeightInTon14feb2024(double weightInTon, double accuracyInTon = 0)
        {
            m_WeightInTon = weightInTon;
            m_PrecisionInTon = accuracyInTon;
        }

        public double GetInTon()
        {
            return m_WeightInTon;
        }

        public double GetInKilogram()
        {
            return WeightCalculation7feb2024.ConvertTonIntoKilogram(m_WeightInTon);
        }

        public double GetInPounds()
        {
            return WeightCalculation7feb2024.ConvertTonIntoPounds(m_WeightInTon);
        }

        public double GetPrecisionInTon()
        {
            return m_PrecisionInTon;
        }

        public double GetPrecisionInKilogram()
        {
            return WeightCalculation7feb2024.ConvertTonIntoKilogram(m_PrecisionInTon);
        }

        public override string ToString()
        {
            return m_WeightInTon + " Ton";
        }

        public IWeight7feb2024 MultiplyBy(double factor)
        {
            WeightInTon14feb2024 result = new WeightInTon14feb2024(this.m_WeightInTon * factor);
            return result;
        }

        public WeightInTon14feb2024 DivideBy(double factor)
        {
            var result = new WeightInTon14feb2024(this.m_WeightInTon / factor, this.m_PrecisionInTon / factor);
            return result;
        }

        public static WeightInTon14feb2024 operator /(WeightInTon14feb2024 a, double factor)
        {
            var result = new WeightInTon14feb2024(a.GetInTon() / factor);
            return result;
        }


    }
}
