namespace ConsoleGeometricFiguresFactoryMethodDesignPattern23Feb2024
{
    internal class SquareFactory : GeometricFigureFactory
    {
        public override Square Create()
        {
            return new Square(1);
        }
    }
}
