using LibraryDifferentialEquations25Feb2024;

namespace LibraryDifferentialEquationKepler25feb2024
{
    public class DifferentialEquationsKepler : DifferentialEquationsKeplerDouble
    {
        public DifferentialEquationsKepler(ParameterConfiguration mass_exoplanet_configuration = ParameterConfiguration.Constant,
            ParameterConfiguration mass_star_configuration = ParameterConfiguration.Constant) : base(mass_exoplanet_configuration, mass_star_configuration)
        {
        }
    }
}

