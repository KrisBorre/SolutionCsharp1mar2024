namespace LibraryIntegrationPrototypeDesignPattern12Feb2024
{
    public class IntegrationTrapezoidal12Feb2024 : IntegrationAbstractClass12Feb2024
    {
        public IntegrationTrapezoidal12Feb2024(IntegrandAbstractClass12Feb2024 integrand, double a, double b) : base(integrand, a, b)
        {
            this.method = Method12Feb2024.Trapezoidal;
        }

        public override IntegrationAbstractClass12Feb2024 Clone()
        {
            IntegrationTrapezoidal12Feb2024 clone = new IntegrationTrapezoidal12Feb2024(this.Integrand, this.a, this.b);
            return clone;
        }

        public override double Next()
        {
            double x, tnm, sum, del;
            int it, j;
            m_n++;

            if (m_n == 1)
            {
                solution = 0.5 * (m_b - m_a) * (integrand.Function(m_a) + integrand.Function(m_b));
            }
            else // n != 1
            {
                for (it = 1, j = 1; j < m_n - 1; j++)
                {
                    it <<= 1;
                }

                tnm = it;

                del = (m_b - m_a) / tnm;

                x = m_a + 0.5 * del;

                for (sum = 0.0, j = 0; j < it; j++, x += del)
                {
                    sum += integrand.Function(x);
                }

                solution = 0.5 * (solution + (m_b - m_a) * sum / tnm);
            }

            return (double)solution;
        }

        public override string ToString()
        {
            string result;

            result = base.ToString() + " of " + integrand + " using the extended trapezoidal rule is ";

            if (solution == null) result += "not calculated yet.";
            else result += solution.ToString();

            return result;
        }

    }
}
