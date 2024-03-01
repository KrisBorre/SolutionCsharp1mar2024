using LibraryIntegrationPrototypeDesignPattern12Feb2024;

namespace LibraryFunctionExamplesPrototypeDesignPattern12Feb2024
{
    public class Square12Feb2024 : IntegrandAbstractClass12Feb2024
    {
        public override IntegrandAbstractClass12Feb2024 Clone()
        {
            return new Square12Feb2024();
        }

        public override double Function(double x)
        {
            return x * x;
        }

        public override string ToString()
        {
            return "x^2";
        }
    }
}