namespace LibraryIntegrationPrototypeDesignPattern12Feb2024
{
    public class IntegrationMidpoint12Feb2024 : IntegrationAbstractClass12Feb2024
    {
        public IntegrationMidpoint12Feb2024(IntegrandAbstractClass12Feb2024 integrand, double a, double b) : base(integrand, a, b)
        {
            this.method = Method12Feb2024.Midpoint;
        }

        public override IntegrationAbstractClass12Feb2024 Clone()
        {
            IntegrationMidpoint12Feb2024 clone = new IntegrationMidpoint12Feb2024(this.Integrand, this.a, this.b);
            return clone;
        }

        public override double Next()
        {
            int it, j;
            double x, tnm, sum, del, ddel;
            m_n++;

            if (m_n == 1)
            {
                solution = (m_b - m_a) * integrand.Function(0.5 * (m_a + m_b));
            }
            else // n != 1
            {
                for (it = 1, j = 1; j < m_n - 1; j++)
                {
                    it *= 3;
                }

                tnm = it;
                del = (m_b - m_a) / (3.0 * tnm);
                ddel = del + del;
                x = m_a + 0.5 * del;
                sum = 0.0;

                for (j = 0; j < it; j++)
                {
                    sum += integrand.Function(x);
                    x += ddel;
                    sum += integrand.Function(x);
                    x += del;
                }

                solution = (solution + (m_b - m_a) * sum / tnm) / 3.0;
            }

            return (double)solution;
        }

        public override string ToString()
        {
            string result;

            result = base.ToString() + " of " + integrand + " using the extended midpoint rule is ";

            if (solution == null) result += "not calculated yet.";
            else result += solution.ToString();

            return result;
        }

    }

}
