using LibraryPhysicalUnits13feb2024;

namespace LibraryIntegrationWork14Feb2024
{
    public class IntegrationTrapezoidal14Feb2024 : IntegrationAbstractClass14Feb2024
    {
        public IntegrationTrapezoidal14Feb2024(IntegrandAbstractClass14Feb2024 integrand, LengthInMeter14feb2024 a, LengthInMeter14feb2024 b) : base(integrand, a, b)
        {
            this.method = Method14Feb2024.Trapezoidal;
        }

        public override IntegrationAbstractClass14Feb2024 Clone()
        {
            IntegrationTrapezoidal14Feb2024 clone = new IntegrationTrapezoidal14Feb2024(this.Integrand, this.a, this.b);
            return clone;
        }

        public override WorkInJoule Next()
        {
            double tnm;
            int it, j;
            LengthInMeter14feb2024 x, del;

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

                ForceInNewton sum = new ForceInNewton(0.0);

                for (j = 0; j < it; j++, x += del)
                {
                    sum += integrand.Function(x);
                }

                solution = 0.5 * (solution + (m_b - m_a) * sum / tnm);
            }

            return solution;
        }

        public override string ToString()
        {
            string result;

            result = base.ToString() + $" using integrand {integrand} and using boundaries from {m_a} to {m_b} using the extended trapezoidal rule is ";

            if (solution == null) result += "not calculated yet.";
            else result += solution.ToString();

            return result;
        }

    }
}
