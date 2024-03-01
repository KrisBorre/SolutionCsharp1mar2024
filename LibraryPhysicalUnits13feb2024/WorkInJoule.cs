namespace LibraryPhysicalUnits13feb2024
{
    public class WorkInJoule : EnergyInJoule14feb2024
    {
        public WorkInJoule(double energyInJoule, double precisionInJoule = 0) : base(energyInJoule, precisionInJoule)
        {

        }

        public override WorkInJoule MultiplyBy(double factor)
        {
            var result = new WorkInJoule(this.m_EnergyInJoule * factor, this.m_PrecisionInJoule * factor);
            return result;
        }

        public static WorkInJoule operator *(double factor, WorkInJoule b)
        {
            var result = new WorkInJoule(factor * b.GetInJoule(), factor * b.GetPrecisionInJoule());
            return result;
        }

        public static WorkInJoule operator *(WorkInJoule a, double factor)
        {
            var result = new WorkInJoule(a.GetInJoule() * factor, a.GetPrecisionInJoule() * factor);
            return result;
        }

        public static WorkInJoule operator +(WorkInJoule a, WorkInJoule b)
        {
            var result = WorkCalculation.Add(a, b);
            return result;
        }

        public override WorkInJoule DivideBy(double factor)
        {
            var result = new WorkInJoule(this.m_EnergyInJoule / factor, this.m_PrecisionInJoule / factor);
            return result;
        }

        public static WorkInJoule operator /(WorkInJoule a, double factor)
        {
            var result = new WorkInJoule(a.GetInJoule() / factor, a.GetPrecisionInJoule() / factor);
            return result;
        }
    }
}