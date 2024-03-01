using LibraryDifferentialEquations25Feb2024;

namespace LibraryDifferentialEquationKepler25feb2024
{
    public class MassExoplanetManagerFloat : ParameterManager<float>
    {
        public MassExoplanetManagerFloat(ParameterConfiguration mass_exoplanet_configuration = ParameterConfiguration.Constant) : base(mass_exoplanet_configuration)
        { }

        public float GetMassExoplanet(float interval, float t)
        {
            return base.GetParameter(interval, t);
        }
    }
}
