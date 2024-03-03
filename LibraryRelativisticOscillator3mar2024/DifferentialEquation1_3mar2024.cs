using LibraryDifferentialEquations25Feb2024;
using System.Numerics;

namespace LibraryRelativisticOscillator3mar2024
{
    // The derivative of the displacement is the first equation.
    // More specifically, the derivative of the displacement is the velocity.
    internal class DifferentialEquation1_3mar2024<T> : DifferentialEquationBaseClass26feb2024<T>
        where T : INumber<T>
    {
        private SpringManager3mar2024<T> spring_manager;
        private MassManager3mar2024<T> mass_manager;

        public DifferentialEquation1_3mar2024(SpringManager3mar2024<T> spring, MassManager3mar2024<T> mass)
        {
            spring_manager = spring;
            mass_manager = mass;
        }

        // d(displacement) / dt    =   velocity
        public override T function(T interval, T x, params T[] y)
        {
            return y[1];
        }
    }
}
