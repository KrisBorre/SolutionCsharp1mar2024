using LibraryIntegrationPrototypeDesignPattern12Feb2024;

namespace LibraryFunctionExamplesPrototypeDesignPattern12Feb2024
{
    public class Integrand2_12Feb2024 : IntegrandAbstractClass12Feb2024
    {
        private double p1, p2;
        // https://www.whitman.edu/mathematics/calculus_late_online/section10.05.html
        // Als power1 = 0.5 en power2 = 4 dan is de integraal van 0 tot 1 gelijk aan 1.089 ...

        public Integrand2_12Feb2024(double power1 = 0.5, double power2 = 4)
        {
            p1 = power1;
            p2 = power2;
        }

        public override IntegrandAbstractClass12Feb2024 Clone()
        {
            Integrand2_12Feb2024 clone = new Integrand2_12Feb2024(this.p1, this.p2);
            return clone;
        }

        public override double Function(double x)
        {
            return Math.Pow(Math.Pow(x, p2) + 1, p1);
        }

        public override string ToString()
        {
            return $"Math.Pow(Math.Pow(x, {p2}) + 1, {p1})";
        }
    }
}
