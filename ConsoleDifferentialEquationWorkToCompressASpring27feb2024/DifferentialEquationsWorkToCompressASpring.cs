using LibraryDifferentialEquations25Feb2024;

namespace ConsoleDifferentialEquationWorkToCompressASpring27feb2024
{
    internal class DifferentialEquationsWorkToCompressASpring : DifferentialEquationsBaseClass26feb2024<Half>
    {
        public DifferentialEquationsWorkToCompressASpring()
        {
            this.NumberOfFirstOrderEquations = 1;
            double d = 50.0;
            Half k = (Half)d;
            this[0] = new DifferentialEquation1(k);
        }
    }
}

