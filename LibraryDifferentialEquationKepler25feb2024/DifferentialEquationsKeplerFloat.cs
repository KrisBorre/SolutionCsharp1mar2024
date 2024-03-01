using LibraryDifferentialEquations25Feb2024;

namespace LibraryDifferentialEquationKepler25feb2024
{
    public class DifferentialEquationsKeplerFloat : DifferentialEquationsBaseClass26feb2024<float>
    {
        private MassExoplanetManagerFloat mass_exoplanet_manager;
        private MassStarManagerFloat mass_star_manager;

        public DifferentialEquationsKeplerFloat(ParameterConfiguration mass_exoplanet_configuration = ParameterConfiguration.Constant, ParameterConfiguration mass_star_configuration = ParameterConfiguration.Constant)
        {
            this.mass_exoplanet_manager = new MassExoplanetManagerFloat(mass_exoplanet_configuration);
            this.mass_star_manager = new MassStarManagerFloat(mass_star_configuration);

            this.NumberOfFirstOrderEquations = 4;
            this[0] = new DifferentialEquation1Float(mass_exoplanet_manager, mass_star_manager);
            this[1] = new DifferentialEquation2Float(mass_exoplanet_manager, mass_star_manager);
            this[2] = new DifferentialEquation3Float(mass_exoplanet_manager, mass_star_manager);
            this[3] = new DifferentialEquation4Float(mass_exoplanet_manager, mass_star_manager);
        }

        public float GetMassExoplanet(float interval, float t)
        {
            return mass_exoplanet_manager.GetMassExoplanet(interval, t);
        }

        public float GetMassStar(float interval, float t)
        {
            return mass_star_manager.GetMassStar(interval, t);
        }
    }
}
