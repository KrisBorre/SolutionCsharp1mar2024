namespace LibraryPhysicalUnits13feb2024
{
    public class TimeInMilliseconds : ITime
    {
        private double m_TimeInMilliseconds;
        private double m_PrecisionInMilliseconds;

        public TimeInMilliseconds(double timeInMilliseconds, double accuracyInMilliseconds)
        {
            m_TimeInMilliseconds = timeInMilliseconds;
            m_PrecisionInMilliseconds = accuracyInMilliseconds;
        }

        public double GetInMilliseconds()
        {
            return m_TimeInMilliseconds;
        }

        public double GetInSeconds()
        {
            return TimeCalculation.ConvertMillisecondsIntoSeconds(m_TimeInMilliseconds);
        }

        public double GetPrecisionInMilliseconds()
        {
            return m_PrecisionInMilliseconds;
        }

        public double GetPrecisionInSeconds()
        {
            return TimeCalculation.ConvertMillisecondsIntoSeconds(m_PrecisionInMilliseconds);
        }

        public override string ToString()
        {
            return m_TimeInMilliseconds + " ms";
        }
    }
}
