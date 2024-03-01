namespace ConsoleArraysBuilderDesignPattern18Feb2024
{
    internal interface IBuilder
    {
        void AddAlgorithms();
        void AddQuantities();
        void AddProblem();
        Problem GetProblem();
    }
}
