namespace ConsoleGeometricFiguresFactoryMethodDesignPattern23Feb2024
{
    internal class TriangleFactory : GeometricFigureFactory
    {
        public override Triangle Create()
        {
            return new Triangle();
        }
    }
}
