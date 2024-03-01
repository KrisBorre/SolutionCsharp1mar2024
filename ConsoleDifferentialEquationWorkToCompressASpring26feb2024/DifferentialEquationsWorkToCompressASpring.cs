using LibraryDifferentialEquations25Feb2024;

namespace ConsoleDifferentialEquationWorkToCompressASpring26feb2024
{
    internal class DifferentialEquationsWorkToCompressASpring : DifferentialEquationsBaseClass26feb2024<double>
    {
        public DifferentialEquationsWorkToCompressASpring()
        {
            this.NumberOfFirstOrderEquations = 1;
            this[0] = new DifferentialEquation1();
        }
    }
}

