using LibraryDifferentialEquations25Feb2024;
using System.Numerics;

namespace LibraryPendulum8mar2024
{
    internal class DifferentialEquation1_8mar2024<T> : DifferentialEquationBaseClass26feb2024<T>
        where T : INumber<T>
    {
        private LengthManager8mar2024<T> length_manager;
        private GravityManager8mar2024<T> gravity_manager;
        private MassManager8mar2024<T> mass_manager;

        public DifferentialEquation1_8mar2024(LengthManager8mar2024<T> length_manager, GravityManager8mar2024<T> gravity_manager, MassManager8mar2024<T> mass_manager)
        {
            this.length_manager = length_manager;
            this.gravity_manager = gravity_manager;
            this.mass_manager = mass_manager;
        }

        public override T function(T interval, T x, params T[] y)
        {
            T l = length_manager.GetLength(interval, x);
            T g = gravity_manager.GetGravity(interval, x);
            T m = mass_manager.GetMass(interval, x);

            return y[1] / (m * l * l);
        }
    }
}
