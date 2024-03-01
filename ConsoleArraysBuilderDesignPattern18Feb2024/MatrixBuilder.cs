namespace ConsoleArraysBuilderDesignPattern18Feb2024
{
    internal abstract class MatrixBuilder : IBuilder
    {
        protected Problem problem;

        public virtual void AddAlgorithms()
        {
            
        }

        public virtual void AddQuantities()
        {
           
        }

        public virtual void AddProblem()
        {
           
        }

        public virtual Problem GetProblem()
        {
            return problem;
        }
    }
}
