using LibraryDifferentialEquations25Feb2024;

namespace LibraryDifferentialEquationKepler25feb2024
{
    public class DifferentialEquationsKeplerDouble : DifferentialEquationsBaseClass26feb2024<double>
    {
        private MassExoplanetManagerDouble mass_exoplanet_manager;
        private MassStarManagerDouble mass_star_manager;

        public DifferentialEquationsKeplerDouble(ParameterConfiguration mass_exoplanet_configuration = ParameterConfiguration.Constant, ParameterConfiguration mass_star_configuration = ParameterConfiguration.Constant)
        {
            this.mass_exoplanet_manager = new MassExoplanetManagerDouble(mass_exoplanet_configuration);
            this.mass_star_manager = new MassStarManagerDouble(mass_star_configuration);

            this.NumberOfFirstOrderEquations = 4;
            this[0] = new DifferentialEquation1Double(mass_exoplanet_manager, mass_star_manager);
            this[1] = new DifferentialEquation2Double(mass_exoplanet_manager, mass_star_manager);
            this[2] = new DifferentialEquation3Double(mass_exoplanet_manager, mass_star_manager);
            this[3] = new DifferentialEquation4Double(mass_exoplanet_manager, mass_star_manager);
        }

        public double GetMassExoplanet(double interval, double t)
        {
            return mass_exoplanet_manager.GetMassExoplanet(interval, t);
        }

        public double GetMassStar(double interval, double t)
        {
            return mass_star_manager.GetMassStar(interval, t);
        }
    }
}