using LibraryDifferentialEquations25Feb2024;

namespace ConsoleDifferentialEquationWorkToCompressASpring28feb2024
{
    internal class DifferentialEquationsWorkToCompressASpring : DifferentialEquationsBaseClass26feb2024<float>
    {
        public DifferentialEquationsWorkToCompressASpring()
        {
            this.NumberOfFirstOrderEquations = 1;
            this[0] = new DifferentialEquation1();
        }
    }
}

