namespace LibraryPhysicalUnits13feb2024
{
    // https://en.wikipedia.org/wiki/Category:Units_of_area
    // https://buildingclub.info/calculator/square-meter-calculator/
    // https://www.mathsisfun.com/measure/metric-area.html#:~:text=The%20square%20meter%20is%20the%20basic%20unit%20of,meter%20on%20each%20side%20is%201%20square%20meter.
    public class AreaInSquareCentimeter : IArea
    {
        private double m_AreaInSquareCentimeter;
        private double m_PrecisionInSquareCentimeter;

        public AreaInSquareCentimeter(double areaInSquareCentimeter, double precisionInSquareCentimeter)
        {
            m_AreaInSquareCentimeter = areaInSquareCentimeter;
            m_PrecisionInSquareCentimeter = precisionInSquareCentimeter;
        }

        public double GetInSquareCentimeter()
        {
            return m_AreaInSquareCentimeter;
        }

        public double GetInSquareMeter()
        {
            return AreaCalculation.ConvertSquareCentimeterIntoSquareMeter(m_AreaInSquareCentimeter);
        }

        public double GetPrecisionInSquareCentimeter()
        {
            return m_PrecisionInSquareCentimeter;
        }

        public double GetPrecisionInSquareMeter()
        {
            return AreaCalculation.ConvertSquareCentimeterIntoSquareMeter(m_PrecisionInSquareCentimeter);
        }

        public override string ToString()
        {
            return m_AreaInSquareCentimeter + " cm^2";
        }
    }
}
