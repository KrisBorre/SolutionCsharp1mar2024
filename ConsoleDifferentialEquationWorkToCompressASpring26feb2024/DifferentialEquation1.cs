using LibraryDifferentialEquations25Feb2024;

namespace ConsoleDifferentialEquationWorkToCompressASpring26feb2024
{
    internal class DifferentialEquation1 : DifferentialEquationBaseClass26feb2024<double>
    {
        double k;

        public DifferentialEquation1(double k = 50)
        {
            this.k = k;
        }

        public override double function(double interval, double x, params double[] y)
        {
            return k * x;
        }
    }
}
