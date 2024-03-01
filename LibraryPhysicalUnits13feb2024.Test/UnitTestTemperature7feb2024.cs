namespace LibraryPhysicalUnits13feb2024.Test
{
    public class UnitTestTemperature
    {
        [Fact]
        public void Test1()
        {
            // https://www.metric-conversions.org/convert/1/2/80
            // 80°C = 176.00°F
            TemperatureInCelsius temperature1 = new TemperatureInCelsius(80, 1);
            Assert.Equal(176, temperature1.GetInFahrenheit());
        }

        [Fact]
        public void Test2()
        {
            ITemperature temperature = new TemperatureInCelsius(10, 0);
            Assert.Equal(10, temperature.GetInCelsius());
        }


        [Fact]
        public void Test3()
        {
            TemperatureInFahrenheit temperature1 = new TemperatureInFahrenheit(100, 1);
            Assert.Equal(100, temperature1.GetInFahrenheit());
        }

        [Fact]
        public void Test4()
        {
            // https://www.metric-conversions.org/temperature/fahrenheit-to-celsius.htm
            // 100°F= 37.77778°C
            TemperatureInFahrenheit temperature1 = new TemperatureInFahrenheit(100, 1);
            Assert.Equal(37.77778, temperature1.GetInCelsius(), tolerance: 0.01);
        }


        [Fact]
        public void Test5()
        {
            TemperatureInCelsius temperatureInCelsius = new TemperatureInCelsius(80, 1);

            ITemperature temperature1 = new TemperatureInCelsius(60, 3);

            ITemperature temperature2 = new TemperatureInFahrenheit(100, 0.01);

            TemperatureInCelsius totalTemperature1 = TemperatureCalculation.Add(temperature1, temperatureInCelsius);

            Assert.Equal(expected: 140, actual: totalTemperature1.GetInCelsius());

            TemperatureInCelsius totalTemperature2 = TemperatureCalculation.Add(temperature1, temperature2);

            Assert.Equal(expected: 97.7778, actual: totalTemperature2.GetInCelsius(), 0.1);
        }

        [Fact]
        public void Test6()
        {
            TemperatureInCelsius temperatureInCelsius = new TemperatureInCelsius(80, 1);

            ITemperature temperature1 = new TemperatureInCelsius(80, 3);

            ITemperature temperature2 = new TemperatureInFahrenheit(100, 0.01); // 100°F= 37.77778°C

            TemperatureInCelsius totalTemperature = TemperatureCalculation.Add(temperatureInCelsius, temperature1);

            Assert.Equal(expected: 160, actual: totalTemperature.GetInCelsius());

            // https://www.metric-conversions.org/convert/1/2/160
            // 160°C = 320.00°F
            Assert.Equal(expected: 320, actual: totalTemperature.GetInFahrenheit());

            ITemperature temperature3 = TemperatureCalculation.Add(temperature2, temperature1);

            Assert.Equal(expected: 117.77778, actual: temperature3.GetInCelsius(), 0.001);

            // https://www.metric-conversions.org/convert/1/2/160
            // 117.77778°C = 244.00°F
            Assert.Equal(expected: 244, actual: temperature3.GetInFahrenheit(), 0.002);
        }

        [Fact]
        public void Test7()
        {
            ITemperature temperature2 = new TemperatureInFahrenheit(100, 0.01); // 100°F= 37.77778°C

            ITemperature temperature3 = new TemperatureInFahrenheit(320, 0.01);  // 160°C = 320.00°F

            TemperatureInCelsius totalTemperature = TemperatureCalculation.Add(temperature2, temperature3);

            Assert.Equal(expected: 197.77778, actual: totalTemperature.GetInCelsius(), 0.001);
        }


        [Fact]
        public void Test8()
        {
            ITemperature temperature2 = new TemperatureInFahrenheit(100, 0.01); // 100°F= 37.77778°C

            ITemperature temperature3 = new TemperatureInFahrenheit(320, 0.01);  // 160°C = 320.00°F

            ITemperature totalTemperature = TemperatureCalculation.Add(temperature2, temperature3);

            Assert.Equal(expected: 197.77778, actual: totalTemperature.GetInCelsius(), 0.001);
        }


    }
}
