namespace ConsoleGeometricFiguresFactoryMethodDesignPattern23Feb2024
{
    internal class Rectangle : GeometricFigure
    {
        protected override int CalculateSurface()
        {
            return Width * Height;
        }
    }
}
