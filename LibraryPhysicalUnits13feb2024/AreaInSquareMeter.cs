namespace LibraryPhysicalUnits13feb2024
{
    // https://en.wikipedia.org/wiki/Category:Units_of_area
    public class AreaInSquareMeter : IArea
    {
        private double m_AreaInSquareMeter;
        private double m_PrecisionInSquareMeter;

        public AreaInSquareMeter(double areaInSquareMeter, double precisionInSquareMeter)
        {
            m_AreaInSquareMeter = areaInSquareMeter;
            m_PrecisionInSquareMeter = precisionInSquareMeter;
        }

        public double GetInSquareMeter()
        {
            return m_AreaInSquareMeter;
        }

        public double GetInSquareCentimeter()
        {
            return AreaCalculation.ConvertSquareMeterIntoSquareCentimeter(m_AreaInSquareMeter);
        }

        public double GetPrecisionInSquareMeter()
        {
            return m_PrecisionInSquareMeter;
        }

        public AreaInSquareMeter MultiplyBy(double factor)
        {
            var result = new AreaInSquareMeter(this.m_AreaInSquareMeter * factor, this.m_PrecisionInSquareMeter * factor);
            return result;
        }

        public static AreaInSquareMeter operator *(double factor, AreaInSquareMeter b)
        {
            var result = new AreaInSquareMeter(factor * b.GetInSquareMeter(), factor * b.GetPrecisionInSquareMeter());
            return result;
        }

        public static AreaInSquareMeter operator *(AreaInSquareMeter a, double factor)
        {
            var result = new AreaInSquareMeter(a.GetInSquareMeter() * factor, a.GetPrecisionInSquareMeter() * factor);
            return result;
        }

        public AreaInSquareMeter DivideBy(double factor)
        {
            var result = new AreaInSquareMeter(this.m_AreaInSquareMeter / factor, this.m_PrecisionInSquareMeter / factor);
            return result;
        }

        public static AreaInSquareMeter operator /(AreaInSquareMeter a, double factor)
        {
            var result = new AreaInSquareMeter(a.GetInSquareMeter() / factor, a.GetPrecisionInSquareMeter() / factor);
            return result;
        }

        public override string ToString()
        {
            return m_AreaInSquareMeter + " m^2";
        }


    }
}
