using LibraryDifferentialEquations25Feb2024;

namespace LibraryDifferentialEquationKepler25feb2024
{
    public class DifferentialEquationsKeplerHalf : DifferentialEquationsBaseClass26feb2024<Half>
    {
        private MassExoplanetManagerHalf mass_exoplanet_manager;
        private MassStarManagerHalf mass_star_manager;

        public DifferentialEquationsKeplerHalf(ParameterConfiguration mass_exoplanet_configuration = ParameterConfiguration.Constant, ParameterConfiguration mass_star_configuration = ParameterConfiguration.Constant)
        {
            this.mass_exoplanet_manager = new MassExoplanetManagerHalf(mass_exoplanet_configuration);
            this.mass_star_manager = new MassStarManagerHalf(mass_star_configuration);

            this.NumberOfFirstOrderEquations = 4;
            this[0] = new DifferentialEquation1Half(mass_exoplanet_manager, mass_star_manager);
            this[1] = new DifferentialEquation2Half(mass_exoplanet_manager, mass_star_manager);
            this[2] = new DifferentialEquation3Half(mass_exoplanet_manager, mass_star_manager);
            this[3] = new DifferentialEquation4Half(mass_exoplanet_manager, mass_star_manager);
        }

        public Half GetMassExoplanet(Half interval, Half t)
        {
            return mass_exoplanet_manager.GetMassExoplanet(interval, t);
        }

        public Half GetMassStar(Half interval, Half t)
        {
            return mass_star_manager.GetMassStar(interval, t);
        }
    }
}
