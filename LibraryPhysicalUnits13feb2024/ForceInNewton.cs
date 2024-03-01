namespace LibraryPhysicalUnits13feb2024
{
    public class ForceInNewton : IForce
    {
        private double m_ForceInNewton;
        private double m_PrecisionInNewton;

        public ForceInNewton(double forceInNewton, double precisionInNewton = 0)
        {
            m_ForceInNewton = forceInNewton;
            m_PrecisionInNewton = precisionInNewton;
        }

        public double GetInNewton()
        {
            return m_ForceInNewton;
        }

        public double GetPrecisionInNewton()
        {
            return m_PrecisionInNewton;
        }

        public IForce MultiplyBy(double factor)
        {
            var result = new ForceInNewton(this.m_ForceInNewton * factor, this.m_PrecisionInNewton * factor);
            return result;
        }

        public static ForceInNewton operator *(double factor, ForceInNewton b)
        {
            var result = new ForceInNewton(factor * b.GetInNewton(), factor * b.GetPrecisionInNewton());
            return result;
        }

        public static ForceInNewton operator *(ForceInNewton a, double factor)
        {
            var result = new ForceInNewton(a.GetInNewton() * factor, a.GetPrecisionInNewton() * factor);
            return result;
        }

        public override string ToString()
        {
            return m_ForceInNewton + " N";
        }

        public static ForceInNewton operator +(ForceInNewton a, ForceInNewton b)
        {
            var result = ForceCalculation.Add(a, b);
            return result;
        }

        public ForceInNewton DivideBy(double factor)
        {
            var result = new ForceInNewton(this.m_ForceInNewton / factor, this.m_PrecisionInNewton / factor);
            return result;
        }

        public static ForceInNewton operator /(ForceInNewton a, double factor)
        {
            var result = new ForceInNewton(a.GetInNewton() / factor, a.GetPrecisionInNewton() / factor);
            return result;
        }


        public static WorkInJoule operator *(ForceInNewton force1, ILength14feb2024 length2)
        {
            var result = WorkCalculation.Multiply(force1, length2);
            return result;
        }

        public static WorkInJoule operator *(ILength14feb2024 length1, ForceInNewton force2)
        {
            var result = WorkCalculation.Multiply(length1, force2);
            return result;
        }

        public static SpringInNewtonPerMeter operator /(ForceInNewton force1, ILength14feb2024 length2)
        {
            var result = SpringCalculation.Divide(force1, length2);
            return result;
        }


    }
}


