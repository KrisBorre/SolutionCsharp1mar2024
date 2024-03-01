namespace ConsoleArraysBuilderDesignPattern18Feb2024
{
    internal class Directory
    {
        //IBuilder builder;

        public void Construct(IBuilder builder)
        {
            //this.builder = builder;            
            builder.AddQuantities();
            builder.AddAlgorithms();                      
            builder.AddProblem();            
        }
    }
}
