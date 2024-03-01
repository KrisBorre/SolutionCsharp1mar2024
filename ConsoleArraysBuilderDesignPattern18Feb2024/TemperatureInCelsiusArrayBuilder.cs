using LibraryPhysicalUnits13feb2024;

namespace ConsoleArraysBuilderDesignPattern18Feb2024
{
    internal class TemperatureInCelsiusArrayBuilder : ArrayBuilder
    {
        private TemperatureInCelsius[] array;
        private Temperature temperature;
        private Method method;

        public TemperatureInCelsiusArrayBuilder(int numberOfItems = 3, Temperature temperature = Temperature.Cold, Method method = Method.Precise)
        {
            this.numberOfItems = numberOfItems;
            this.temperature = temperature;
            this.method = method;
        }

        public override void AddQuantities()
        {
            Random random = new Random();
            this.array = new TemperatureInCelsius[numberOfItems];
            if (this.method == Method.Precise)
            {
                if (temperature == Temperature.Cold)
                {
                    for (int i = 0; i < this.numberOfItems; i++)
                    {
                        this.array[i] = new TemperatureInCelsius(random.NextDouble(), 0);
                    }
                }
                else
                {
                    for (int i = 0; i < this.numberOfItems; i++)
                    {
                        this.array[i] = new TemperatureInCelsius(1000 * random.NextDouble(), 0);
                    }
                }
            }
            else
            {
                if (temperature == Temperature.Cold)
                {
                    for (int i = 0; i < this.numberOfItems; i++)
                    {
                        this.array[i] = new TemperatureInCelsius(random.NextDouble(), random.NextDouble());
                    }
                }
                else
                {
                    for (int i = 0; i < this.numberOfItems; i++)
                    {
                        this.array[i] = new TemperatureInCelsius(1000 * random.NextDouble(), random.NextDouble());
                    }
                }
            }

        }

        //public override void AddAlgorithms()
        //{

        //}

        public override void AddProblem()
        {
            this.problem = new Problem(this.array);
        }

        //public override Problem GetProblem()
        //{
        //    return this.problem;
        //}
    }
}
