using LibraryDifferentialEquations25Feb2024;
using System.Numerics;

namespace LibraryRelativisticOscillator3mar2024
{
    public class MassManager3mar2024<T> : ParameterManager<T>
        where T : INumber<T>
    {
        public MassManager3mar2024(ParameterConfiguration mass_configuration = ParameterConfiguration.Constant)
            : base(mass_configuration)
        {
        }

        public T GetMass(T interval, T t)
        {
            return base.GetParameter(interval, t);
        }
    }
}
