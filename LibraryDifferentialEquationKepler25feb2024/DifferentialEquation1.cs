using LibraryDifferentialEquations25Feb2024;

namespace LibraryDifferentialEquationKepler25feb2024
{
    public class DifferentialEquation1 : DifferentialEquation1Double
    {
        public DifferentialEquation1(MassExoplanetManagerDouble mass_exoplanet_manager, MassStarManagerDouble mass_star_manager,
            ParameterConfiguration mass_exoplanet_configuration = ParameterConfiguration.Constant,
            ParameterConfiguration mass_star_configuration = ParameterConfiguration.Constant)
            : base(mass_exoplanet_manager, mass_star_manager, mass_exoplanet_configuration, mass_star_configuration)
        {
        }
    }
}
