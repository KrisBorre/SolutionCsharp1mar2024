using LibraryDifferentialEquations25Feb2024;
using System.Numerics;

namespace LibraryDifferentialEquationKepler26Feb2024
{
    public class MassExoplanetManager<T> : ParameterManager<T>
        where T : INumber<T>

    {
        public MassExoplanetManager(ParameterConfiguration mass_exoplanet_configuration = ParameterConfiguration.Constant) : base(mass_exoplanet_configuration)
        { }

        public T GetMassExoplanet(T interval, T t)
        {
            return base.GetParameter(interval, t);
        }
    }
}
