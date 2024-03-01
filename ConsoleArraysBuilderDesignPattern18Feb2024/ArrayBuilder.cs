namespace ConsoleArraysBuilderDesignPattern18Feb2024
{
    internal abstract class ArrayBuilder : IBuilder
    {
        protected Problem problem;

        protected int numberOfItems;

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
