using LibraryDifferentialEquations25Feb2024;

namespace LibraryDifferentialEquationKepler25feb2024
{
    public class DifferentialEquation2Float : DifferentialEquationBaseClass26feb2024<float>
    {
        private MassExoplanetManagerFloat mass_exoplanet_manager;
        private MassStarManagerFloat mass_star_manager;

        public DifferentialEquation2Float(MassExoplanetManagerFloat mass_exoplanet_manager, 
            MassStarManagerFloat mass_star_manager, 
            ParameterConfiguration mass_exoplanet_configuration = ParameterConfiguration.Constant, 
            ParameterConfiguration mass_star_configuration = ParameterConfiguration.Constant)
        {
            this.mass_exoplanet_manager = mass_exoplanet_manager;
            this.mass_star_manager = mass_star_manager;
        }

        public override float function(float interval, float x, params float[] y)
        {
            float mass = mass_exoplanet_manager.GetMassExoplanet(interval, x);
            return y[3] / mass;
        }
    }
}
