using LibraryPhysicalUnits13feb2024;

namespace ConsoleArraysBuilderDesignPattern18Feb2024
{
    internal class WeightInKilogramMatrixBuilder : MatrixBuilder
    {      
        private WeightInKilogram14feb2024[,] matrix;

        public WeightInKilogramMatrixBuilder()
        {

        }

        public override void AddQuantities()
        {
            this.matrix = new WeightInKilogram14feb2024[,]{
                        {new WeightInKilogram14feb2024(1.1,0), new WeightInKilogram14feb2024(1.2,0), new WeightInKilogram14feb2024(1.3, 0)},
                        {new WeightInKilogram14feb2024(4.1, 0), new WeightInKilogram14feb2024(1.5, 0), new WeightInKilogram14feb2024(3.3, 0)},
                        {new WeightInKilogram14feb2024(0.1, 0), new WeightInKilogram14feb2024(1.2, 0), new WeightInKilogram14feb2024(0.3, 0)}
                    };
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
