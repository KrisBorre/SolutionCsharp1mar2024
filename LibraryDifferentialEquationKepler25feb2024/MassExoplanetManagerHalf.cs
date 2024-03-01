using LibraryDifferentialEquations25Feb2024;

namespace LibraryDifferentialEquationKepler25feb2024
{
    public class MassExoplanetManagerHalf : ParameterManager<Half>
    {
        public MassExoplanetManagerHalf(ParameterConfiguration mass_exoplanet_configuration = ParameterConfiguration.Constant) : base(mass_exoplanet_configuration)
        { }

        public Half GetMassExoplanet(Half interval, Half t)
        {
            return base.GetParameter(interval, t);
        }
    }
}
