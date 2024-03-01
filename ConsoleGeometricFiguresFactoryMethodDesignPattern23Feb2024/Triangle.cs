namespace ConsoleGeometricFiguresFactoryMethodDesignPattern23Feb2024
{
    internal class Triangle : GeometricFigure
    {
        protected override int CalculateSurface()
        {
            return (int)((Height * Width) / 2.0);
        }
    }
}
