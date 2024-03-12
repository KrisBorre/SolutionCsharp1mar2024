using LibraryDifferentialEquations25Feb2024;
using System.Numerics;

namespace LibraryHarmonicOscillatorMomentum6mar2024
{
    internal class DifferentialEquation1_6mar2024<T> : DifferentialEquationBaseClass26feb2024<T>
        where T : INumber<T>
    {
        private SpringManager6mar2024<T> spring_manager;
        private MassManager6mar2024<T> mass_manager;

        public DifferentialEquation1_6mar2024(SpringManager6mar2024<T> spring, MassManager6mar2024<T> mass)
        {
            spring_manager = spring;
            mass_manager = mass;
        }

        public override T function(T interval, T x, params T[] y)
        {
            T m = mass_manager.GetMass(interval, x);

            return y[1] / m;
        }

    }
}
