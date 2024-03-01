namespace LibraryPhysicalUnits13feb2024
{
    public class TemperatureInCelsius : ITemperature
    {
        private double m_TemperatureInCelsius;
        private double m_PrecisionInCelsius;

        public TemperatureInCelsius(double temperatureInCelsius, double precisionInCelsius)
        {
            m_TemperatureInCelsius = temperatureInCelsius;
            m_PrecisionInCelsius = precisionInCelsius;
        }

        public double GetInCelsius()
        {
            return m_TemperatureInCelsius;
        }

        public double GetInFahrenheit()
        {
            return TemperatureCalculation.ConvertCelsiusIntoFahrenheit(m_TemperatureInCelsius);
        }

        public double GetPrecisionInCelsius()
        {
            return m_PrecisionInCelsius;
        }

        public override string ToString()
        {
            return m_TemperatureInCelsius + " \u00B0C";
        }
    }
}
