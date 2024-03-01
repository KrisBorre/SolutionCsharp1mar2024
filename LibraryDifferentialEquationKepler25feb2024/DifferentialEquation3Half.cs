using LibraryDifferentialEquations25Feb2024;

namespace LibraryDifferentialEquationKepler25feb2024
{
    public class DifferentialEquation3Half : DifferentialEquationBaseClass26feb2024<Half>
    {
        private MassExoplanetManagerHalf mass_exoplanet_manager;
        private MassStarManagerHalf mass_star_manager;

        public DifferentialEquation3Half(MassExoplanetManagerHalf mass_exoplanet_manager, MassStarManagerHalf mass_star_manager, ParameterConfiguration mass_exoplanet_configuration = ParameterConfiguration.Constant, ParameterConfiguration mass_star_configuration = ParameterConfiguration.Constant)
        {
            this.mass_exoplanet_manager = mass_exoplanet_manager;
            this.mass_star_manager = mass_star_manager;
        }

        public override Half function(Half interval, Half x, params Half[] y)
        {
            Half mass = mass_exoplanet_manager.GetMassExoplanet(interval, x);
            Half Mass = mass_star_manager.GetMassStar(interval, x);

            return -(y[0] * mass * Mass) / (Half)Math.Pow((double)((y[0] * y[0]) + (y[1] * y[1])), 1.5);
        }
    }
}
