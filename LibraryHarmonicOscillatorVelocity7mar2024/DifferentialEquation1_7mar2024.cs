using LibraryDifferentialEquations25Feb2024;
using System.Numerics;

namespace LibraryHarmonicOscillatorVelocity7mar2024
{
    internal class DifferentialEquation1_7mar2024<T> : DifferentialEquationBaseClass26feb2024<T>
        where T : INumber<T>
    {
        private SpringManager7mar2024<T> spring_manager;
        private MassManager7mar2024<T> mass_manager;

        public DifferentialEquation1_7mar2024(SpringManager7mar2024<T> spring, MassManager7mar2024<T> mass)
        {
            spring_manager = spring;
            mass_manager = mass;
        }

        public override T function(T interval, T x, params T[] y)
        {
            return y[1];
        }
    }
}
