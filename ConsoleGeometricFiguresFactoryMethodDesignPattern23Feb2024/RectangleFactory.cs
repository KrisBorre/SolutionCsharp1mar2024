namespace ConsoleGeometricFiguresFactoryMethodDesignPattern23Feb2024
{
    internal class RectangleFactory : GeometricFigureFactory
    {
        public override GeometricFigure Create()
        {
            return new Rectangle();
        }
    }
}
