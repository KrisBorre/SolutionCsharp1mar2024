using LibraryPhysicalUnits13feb2024;

namespace ConsoleArraysBuilderDesignPattern18Feb2024
{
    internal class WeightInKilogramArrayBuilder : ArrayBuilder
    {
        private WeightInKilogram14feb2024[] array;

        public WeightInKilogramArrayBuilder(int numberOfItems = 3)
        {
            this.numberOfItems = numberOfItems;
        }

        public override void AddQuantities()
        {
            this.array = new WeightInKilogram14feb2024[this.numberOfItems];
            for (int i = 1; i <= this.numberOfItems; i++)
            {
                this.array[i - 1] = new WeightInKilogram14feb2024(1 + 0.1 * i, 0);
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
