namespace LibraryIntegrationPrototypeDesignPattern12Feb2024
{
    public abstract class IntegrationAbstractClass12Feb2024
    {
        protected IntegrandAbstractClass12Feb2024 integrand;

        internal IntegrandAbstractClass12Feb2024 Integrand
        {
            get
            {
                return integrand;
            }
        }

        protected Method12Feb2024 method;

        internal Method12Feb2024 Method
        {
            get
            {
                return method;
            }
        }

        // Limits of integration and current value of integral.
        protected double m_a, m_b;

        public double a
        {
            get { return this.m_a; }
            set
            {
                this.m_a = value;
                this.m_n = 0;
                solution = null;
            }
        }

        public double b
        {
            get { return this.m_b; }
            set
            {
                this.m_b = value;
                this.m_n = 0;
                solution = null;
            }
        }

        protected int m_n;

        public IntegrationAbstractClass12Feb2024(IntegrandAbstractClass12Feb2024 integrand, double a, double b)
        {
            this.integrand = integrand;
            this.m_a = a;
            this.m_b = b;
            this.m_n = 0;
        }

        protected double? solution = null;

        public abstract double Next();

        public override string ToString()
        {
            return "Integral solution";
        }

        public abstract IntegrationAbstractClass12Feb2024 Clone();

    }
}
