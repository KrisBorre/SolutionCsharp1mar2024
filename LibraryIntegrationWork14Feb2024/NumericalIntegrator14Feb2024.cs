using LibraryPhysicalUnits13feb2024;

namespace LibraryIntegrationWork14Feb2024
{
    public class NumericalIntegrator14Feb2024
    {
        public LengthInMeter14feb2024 a
        {
            get { return integrationAbstractClass12Feb2024.a; }
            set
            {
                integrationAbstractClass12Feb2024.a = value;
            }
        }

        public LengthInMeter14feb2024 b
        {
            get { return integrationAbstractClass12Feb2024.b; }
            set
            {
                integrationAbstractClass12Feb2024.b = value;
            }
        }

        private IntegrationAbstractClass14Feb2024 integrationAbstractClass12Feb2024;

        public NumericalIntegrator14Feb2024(IntegrandAbstractClass14Feb2024 integrand, LengthInMeter14feb2024 a, LengthInMeter14feb2024 b, Method14Feb2024 method = Method14Feb2024.Trapezoidal)
        {
            switch (method)
            {
                case Method14Feb2024.Midpoint:
                    this.integrationAbstractClass12Feb2024 = new IntegrationMidpoint14Feb2024(integrand, a, b);
                    break;
                case Method14Feb2024.Trapezoidal:
                    this.integrationAbstractClass12Feb2024 = new IntegrationTrapezoidal14Feb2024(integrand, a, b);
                    break;
                default:
                    this.integrationAbstractClass12Feb2024 = new IntegrationTrapezoidal14Feb2024(integrand, a, b);
                    break;
            }
        }

        public NumericalIntegrator14Feb2024(IntegrandAbstractClass14Feb2024 integrand, LengthInCentimeter14feb2024 a, LengthInCentimeter14feb2024 b, Method14Feb2024 method = Method14Feb2024.Trapezoidal)
        {
            throw new NotImplementedException();
        }

        public WorkInJoule Next()
        {
            WorkInJoule solution = this.integrationAbstractClass12Feb2024.Next();
            return solution;
        }

        public override string ToString()
        {
            return this.integrationAbstractClass12Feb2024.ToString();
        }

        public NumericalIntegrator14Feb2024 Clone()
        {
            NumericalIntegrator14Feb2024 clone = new NumericalIntegrator14Feb2024(this.integrationAbstractClass12Feb2024.Integrand, this.a, this.b, this.integrationAbstractClass12Feb2024.Method);
            return clone;
        }
    }
}
