using LibraryDifferentialEquations25Feb2024;

namespace LibraryDifferentialEquationKepler25feb2024
{
    public class MassExoplanetManagerDouble : ParameterManager<double>
    {
        public MassExoplanetManagerDouble(ParameterConfiguration mass_exoplanet_configuration = ParameterConfiguration.Constant) : base(mass_exoplanet_configuration)
        { }

        public double GetMassExoplanet(double interval, double t)
        {
            return base.GetParameter(interval, t);
        }
    }
}
