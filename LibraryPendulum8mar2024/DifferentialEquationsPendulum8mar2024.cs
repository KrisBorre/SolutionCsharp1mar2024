using LibraryDifferentialEquations25Feb2024;
using System.Numerics;

namespace LibraryPendulum8mar2024
{
    public class DifferentialEquationsPendulum8mar2024<T> : DifferentialEquationsBaseClass26feb2024<T>
        where T : INumber<T>
    {
        private LengthManager8mar2024<T> length_manager;
        private GravityManager8mar2024<T> gravity_manager;
        private MassManager8mar2024<T> mass_manager;

        // angle: theta, canonical momentum: p_theta
        public DifferentialEquationsPendulum8mar2024(
            ParameterConfiguration length_configuration = ParameterConfiguration.Constant, 
            ParameterConfiguration gravity_configuration = ParameterConfiguration.Constant, 
            ParameterConfiguration mass_configuration = ParameterConfiguration.Constant)
        {
            this.length_manager = new LengthManager8mar2024<T>(length_configuration);
            this.gravity_manager = new GravityManager8mar2024<T>(gravity_configuration);
            this.mass_manager = new MassManager8mar2024<T>(mass_configuration);

            this.NumberOfFirstOrderEquations = 2;
            this[0] = new DifferentialEquation1_8mar2024<T>(length_manager, gravity_manager, mass_manager);
            this[1] = new DifferentialEquation2_8mar2024<T>(length_manager, gravity_manager, mass_manager);
        }

        public T GetLength(T interval, T t)
        {
            return length_manager.GetLength(interval, t);
        }

        public T GetGravity(T interval, T t)
        {
            return gravity_manager.GetGravity(interval, t);
        }

        public T GetMass(T interval, T t)
        {
            return mass_manager.GetMass(interval, t);
        }
    }
}
