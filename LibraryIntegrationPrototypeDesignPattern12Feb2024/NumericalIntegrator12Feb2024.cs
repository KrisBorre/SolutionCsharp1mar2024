namespace LibraryIntegrationPrototypeDesignPattern12Feb2024
{
    public class NumericalIntegrator12Feb2024
    {
        public double a
        {
            get { return integrationAbstractClass12Feb2024.a; }
            set
            {
                integrationAbstractClass12Feb2024.a = value;
            }
        }

        public double b
        {
            get { return integrationAbstractClass12Feb2024.b; }
            set
            {
                integrationAbstractClass12Feb2024.b = value;
            }
        }

        private IntegrationAbstractClass12Feb2024 integrationAbstractClass12Feb2024;

        public NumericalIntegrator12Feb2024(IntegrandAbstractClass12Feb2024 integrand, double a, double b, Method12Feb2024 method = Method12Feb2024.Trapezoidal)
        {
            switch (method)
            {
                case Method12Feb2024.Midpoint:
                    this.integrationAbstractClass12Feb2024 = new IntegrationMidpoint12Feb2024(integrand, a, b);
                    break;
                case Method12Feb2024.Trapezoidal:
                    this.integrationAbstractClass12Feb2024 = new IntegrationTrapezoidal12Feb2024(integrand, a, b);
                    break;
                default:
                    this.integrationAbstractClass12Feb2024 = new IntegrationTrapezoidal12Feb2024(integrand, a, b);
                    break;
            }
        }

        public double Next()
        {
            double solution = this.integrationAbstractClass12Feb2024.Next();
            return solution;
        }

        public override string ToString()
        {
            return this.integrationAbstractClass12Feb2024.ToString();
        }

        public NumericalIntegrator12Feb2024 Clone()
        {
            NumericalIntegrator12Feb2024 clone = new NumericalIntegrator12Feb2024(this.integrationAbstractClass12Feb2024.Integrand, this.a, this.b, this.integrationAbstractClass12Feb2024.Method);
            return clone;
        }
    }
}
