namespace LibraryPhysicalUnits13feb2024
{
    public class TimeInSeconds : ITime
    {
        private double m_TimeInSeconds;
        private double m_PrecisionInSeconds;

        public TimeInSeconds(double timeInSeconds, double accuracyInSeconds)
        {
            m_TimeInSeconds = timeInSeconds;
            m_PrecisionInSeconds = accuracyInSeconds;
        }

        public double GetInSeconds()
        {
            return m_TimeInSeconds;
        }

        public double GetInMilliseconds()
        {
            return TimeCalculation.ConvertSecondIntoMilliseconds(m_TimeInSeconds);
        }

        public double GetPrecisionInSeconds()
        {
            return m_PrecisionInSeconds;
        }

        public double GetPrecisionInMilliseconds()
        {
            return TimeCalculation.ConvertSecondIntoMilliseconds(m_PrecisionInSeconds);
        }

        public override string ToString()
        {
            return m_TimeInSeconds + " s";
        }
    }
}
