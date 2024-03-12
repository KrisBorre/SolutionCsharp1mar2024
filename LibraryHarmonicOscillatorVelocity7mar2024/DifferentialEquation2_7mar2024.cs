using LibraryDifferentialEquations25Feb2024;
using System.Numerics;

namespace LibraryHarmonicOscillatorVelocity7mar2024
{
    internal class DifferentialEquation2_7mar2024<T> : DifferentialEquationBaseClass26feb2024<T>
        where T : INumber<T>
    {
        private SpringManager7mar2024<T> spring_manager;
        private MassManager7mar2024<T> mass_manager;

        public DifferentialEquation2_7mar2024(SpringManager7mar2024<T> spring, MassManager7mar2024<T> mass)
        {
            spring_manager = spring;
            mass_manager = mass;
        }

        public override T function(T interval, T x, params T[] y)
        {
            // interval is the entire time span that we want to simulate.
            // interval is a simulation configuration parameter that stays constant during the calculation of the solution of the differential equation.
            // x is the time during the simulation.
            // x is the x or t of the differential equation.

            T k = spring_manager.GetSpring(interval, x);
            T m = mass_manager.GetMass(interval, x);

            return -(k / m) * y[0];
        }
    }
}
