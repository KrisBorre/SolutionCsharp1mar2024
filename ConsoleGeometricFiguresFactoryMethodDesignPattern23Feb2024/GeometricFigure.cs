namespace ConsoleGeometricFiguresFactoryMethodDesignPattern23Feb2024
{
    internal abstract class GeometricFigure : IGeometricFigure
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public int Surface { get { return CalculateSurface(); } }

        protected abstract int CalculateSurface();
    }
}
