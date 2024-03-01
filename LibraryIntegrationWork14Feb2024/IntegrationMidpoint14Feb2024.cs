using LibraryPhysicalUnits13feb2024;

namespace LibraryIntegrationWork14Feb2024
{
    public class IntegrationMidpoint14Feb2024 : IntegrationAbstractClass14Feb2024
    {
        public IntegrationMidpoint14Feb2024(IntegrandAbstractClass14Feb2024 integrand, LengthInMeter14feb2024 a, LengthInMeter14feb2024 b) : base(integrand, a, b)
        {
            this.method = Method14Feb2024.Midpoint;
        }

        public override IntegrationAbstractClass14Feb2024 Clone()
        {
            IntegrationMidpoint14Feb2024 clone = new IntegrationMidpoint14Feb2024(this.Integrand, this.a, this.b);
            return clone;
        }

        public override WorkInJoule Next()
        {
            int it, j;
            double tnm;
            LengthInMeter14feb2024 x, del, ddel;
             
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
                var sum = new ForceInNewton(0.0);

                for (j = 0; j < it; j++)
                {
                    sum += integrand.Function(x);
                    x += ddel;
                    sum += integrand.Function(x);
                    x += del;
                }

                solution = (solution + (m_b - m_a) * sum / tnm) / 3.0;
            }

            return solution;
        }

        public override string ToString()
        {
            string result;

            result = base.ToString() + $" using integrand {integrand} and using boundaries from {m_a} to {m_b} using the extended midpoint rule is ";

            if (solution == null) result += "not calculated yet.";
            else result += solution.ToString();

            return result;
        }

    }

}
