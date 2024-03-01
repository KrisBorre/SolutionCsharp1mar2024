namespace LibraryPhysicalUnits13feb2024
{
    public static class TemperatureCalculation
    {
        public static double ConvertFahrenheitIntoCelsius(double temperature)
        {
            // https://www.metric-conversions.org/temperature/fahrenheit-to-celsius.htm
            // 100°F= 37.77778°C            
            return (temperature - 32) / 1.8;
        }

        public static double ConvertCelsiusIntoFahrenheit(double temperature)
        {            
            return (temperature * 1.8) + 32;
        }

        public static TemperatureInCelsius Add(ITemperature temperature1, ITemperature temperature2)
        {
            double accuracy = Math.Sqrt(Math.Pow(temperature1.GetPrecisionInCelsius(), 2) + Math.Pow(temperature2.GetPrecisionInCelsius(), 2));
            return new TemperatureInCelsius(temperature1.GetInCelsius() + temperature2.GetInCelsius(), accuracy);
        }
    }
}
