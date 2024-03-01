namespace LibraryPhysicalUnits13feb2024
{
    public static class TimeCalculation
    {
        public static double ConvertMillisecondsIntoSeconds(double time)
        {
            return time / 1000;
        }

        public static double ConvertSecondIntoMilliseconds(double time)
        {
            return time * 1000.0;
        }

        public static TimeInSeconds Add(ITime time1, ITime time2)
        {
            double accuracy = Math.Sqrt(Math.Pow(time1.GetPrecisionInSeconds(), 2) + Math.Pow(time2.GetPrecisionInSeconds(), 2));
            return new TimeInSeconds(time1.GetInSeconds() + time2.GetInSeconds(), accuracy);
        }
    }
}
