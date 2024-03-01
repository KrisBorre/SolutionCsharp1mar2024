using LibraryPhysicalUnits13feb2024;

namespace ConsoleArraysBuilderDesignPattern18Feb2024
{
    internal enum Temperature { Cold, Hot };

    internal enum Method { Measurements, Precise }

    internal class TemperatureInCelsiusMatrixBuilder : MatrixBuilder
    {     
        private TemperatureInCelsius[,] matrix;
        private Temperature temperature;
        private Method method;

        public TemperatureInCelsiusMatrixBuilder(Temperature temperature = Temperature.Cold, Method method = Method.Precise)
        {
            this.temperature = temperature;
            this.method = method;
        }

        public override void AddQuantities()
        {
            Random random = new Random();
            if (this.method == Method.Precise)
            {
                if (temperature == Temperature.Cold)
                {
                    this.matrix = new TemperatureInCelsius[,]{
                        {new TemperatureInCelsius(random.NextDouble(),0), new TemperatureInCelsius(random.NextDouble(),0), new TemperatureInCelsius(random.NextDouble(), 0)},
                        {new TemperatureInCelsius(random.NextDouble(), 0), new TemperatureInCelsius(random.NextDouble(), 0), new TemperatureInCelsius(random.NextDouble(), 0)},
                        {new TemperatureInCelsius(random.NextDouble(), 0), new TemperatureInCelsius(random.NextDouble(), 0), new TemperatureInCelsius(random.NextDouble(), 0)}
                    };
                }
                else
                {
                    double factor = 1000;
                    this.matrix = new TemperatureInCelsius[,]{
                        {new TemperatureInCelsius(factor*random.NextDouble(), 0), new TemperatureInCelsius(factor*random.NextDouble(), 0), new TemperatureInCelsius(factor*random.NextDouble(), 0)},
                        {new TemperatureInCelsius(factor*random.NextDouble(), 0), new TemperatureInCelsius(factor*random.NextDouble(), 0), new TemperatureInCelsius(factor*random.NextDouble(), 0)},
                        {new TemperatureInCelsius(factor*random.NextDouble(), 0), new TemperatureInCelsius(factor*random.NextDouble(), 0), new TemperatureInCelsius(factor*random.NextDouble(), 0)}
                    };
                }
            }
            else
            {
                if (temperature == Temperature.Cold)
                {
                    this.matrix = new TemperatureInCelsius[,]{
                        {new TemperatureInCelsius(random.NextDouble(), random.NextDouble()), new TemperatureInCelsius(random.NextDouble(), random.NextDouble()), new TemperatureInCelsius(random.NextDouble(), random.NextDouble())},
                        {new TemperatureInCelsius(random.NextDouble(), random.NextDouble()), new TemperatureInCelsius(random.NextDouble(), random.NextDouble()), new TemperatureInCelsius(random.NextDouble(), random.NextDouble())},
                        {new TemperatureInCelsius(random.NextDouble(), random.NextDouble()), new TemperatureInCelsius(random.NextDouble(), random.NextDouble()), new TemperatureInCelsius(random.NextDouble(), random.NextDouble())}
                    };
                }
                else
                {
                    double factor = 1000;
                    this.matrix = new TemperatureInCelsius[,]{
                        {new TemperatureInCelsius(factor*random.NextDouble(), random.NextDouble()), new TemperatureInCelsius(factor*random.NextDouble(),random.NextDouble()), new TemperatureInCelsius(factor*random.NextDouble(), random.NextDouble())},
                        {new TemperatureInCelsius(factor*random.NextDouble(), random.NextDouble()), new TemperatureInCelsius(factor*random.NextDouble(), random.NextDouble()), new TemperatureInCelsius(factor*random.NextDouble(), random.NextDouble())},
                        {new TemperatureInCelsius(factor*random.NextDouble(), random.NextDouble()), new TemperatureInCelsius(factor*random.NextDouble(), random.NextDouble()), new TemperatureInCelsius(factor*random.NextDouble(), random.NextDouble())}
                    };
                }
            }
        }

        //public override void AddAlgorithms()
        //{

        //}

        public override void AddProblem()
        {
            this.problem = new Problem(this.matrix);
        }

        //public override Problem GetProblem()
        //{
        //    return this.problem;
        //}
    }
}
