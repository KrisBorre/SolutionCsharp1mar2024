namespace LibraryPhysicalUnits13feb2024
{
    public class SpringInNewtonPerMeter : ISpring
    {
        private double m_SpringInNewtonPerMeter;
        private double m_PrecisionInNewtonPerMeter;

        public SpringInNewtonPerMeter(double springInNewtonPerMeter, double precisionInNewtonPerMeter)
        {
            m_SpringInNewtonPerMeter = springInNewtonPerMeter;
            m_PrecisionInNewtonPerMeter = precisionInNewtonPerMeter;
        }

        public double GetInNewtonPerMeter()
        {
            return m_SpringInNewtonPerMeter;
        }

        public double GetPrecisionInNewtonPerMeter()
        {
            return m_PrecisionInNewtonPerMeter;
        }

        public override string ToString()
        {
            return m_SpringInNewtonPerMeter + " N/m";
        }

        public SpringInNewtonPerMeter MultiplyBy(double factor)
        {
            var result = new SpringInNewtonPerMeter(this.m_SpringInNewtonPerMeter * factor, this.m_PrecisionInNewtonPerMeter * factor);
            return result;
        }

        public static SpringInNewtonPerMeter operator *(double factor, SpringInNewtonPerMeter b)
        {
            var result = new SpringInNewtonPerMeter(factor * b.GetInNewtonPerMeter(), factor * b.GetPrecisionInNewtonPerMeter());
            return result;
        }

        public static SpringInNewtonPerMeter operator *(SpringInNewtonPerMeter a, double factor)
        {
            var result = new SpringInNewtonPerMeter(a.GetInNewtonPerMeter() * factor, a.GetPrecisionInNewtonPerMeter() * factor);
            return result;
        }

        public static SpringInNewtonPerMeter operator +(SpringInNewtonPerMeter a, SpringInNewtonPerMeter b)
        {
            var result = SpringCalculation.Add(a, b);
            return result;
        }

        public SpringInNewtonPerMeter DivideBy(double factor)
        {
            var result = new SpringInNewtonPerMeter(this.m_SpringInNewtonPerMeter / factor, this.m_PrecisionInNewtonPerMeter / factor);
            return result;
        }

        public static SpringInNewtonPerMeter operator /(SpringInNewtonPerMeter a, double factor)
        {
            var result = new SpringInNewtonPerMeter(a.GetInNewtonPerMeter() / factor, a.GetPrecisionInNewtonPerMeter() / factor);
            return result;
        }

        public static ForceInNewton operator *(SpringInNewtonPerMeter springInNewtonPerMeter1, ILength14feb2024 length2)
        {
            var result = ForceCalculation.Multiply(springInNewtonPerMeter1, length2);
            return result;
        }

        public static ForceInNewton operator *(ILength14feb2024 length1, SpringInNewtonPerMeter springInNewtonPerMeter2)
        {
            var result = ForceCalculation.Multiply(length1, springInNewtonPerMeter2);
            return result;
        }
    }
}
