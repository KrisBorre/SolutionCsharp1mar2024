namespace LibraryPhysicalUnits13feb2024
{
    public class EnergyInJoule14feb2024 : IEnergy
    {
        protected double m_EnergyInJoule;
        protected double m_PrecisionInJoule;

        public EnergyInJoule14feb2024(double energyInJoule, double precisionInJoule = 0)
        {
            m_EnergyInJoule = energyInJoule;
            m_PrecisionInJoule = precisionInJoule;
        }

        public double GetInJoule()
        {
            return m_EnergyInJoule;
        }

        public double GetPrecisionInJoule()
        {
            return m_PrecisionInJoule;
        }

        public virtual EnergyInJoule14feb2024 MultiplyBy(double factor)
        {
            var result = new EnergyInJoule14feb2024(this.m_EnergyInJoule * factor, this.m_PrecisionInJoule * factor);
            return result;
        }

        public static EnergyInJoule14feb2024 operator *(double factor, EnergyInJoule14feb2024 b)
        {
            var result = new EnergyInJoule14feb2024(factor * b.GetInJoule(), factor * b.GetPrecisionInJoule());
            return result;
        }

        public static EnergyInJoule14feb2024 operator *(EnergyInJoule14feb2024 a, double factor)
        {
            var result = new EnergyInJoule14feb2024(a.GetInJoule() * factor, a.GetPrecisionInJoule() * factor);
            return result;
        }

        public override string ToString()
        {
            return "( " + this.m_EnergyInJoule + " ± " + this.m_PrecisionInJoule + " ) Joule";
        }

        public static EnergyInJoule14feb2024 operator +(EnergyInJoule14feb2024 a, EnergyInJoule14feb2024 b)
        {
            var result = EnergyCalculation.Add(a, b);
            return result;
        }

        public virtual EnergyInJoule14feb2024 DivideBy(double factor)
        {
            var result = new EnergyInJoule14feb2024(this.m_EnergyInJoule / factor, this.m_PrecisionInJoule / factor);
            return result;
        }

        public static EnergyInJoule14feb2024 operator /(EnergyInJoule14feb2024 a, double factor)
        {
            var result = new EnergyInJoule14feb2024(a.GetInJoule() / factor, a.GetPrecisionInJoule() / factor);
            return result;
        }


    }
}
