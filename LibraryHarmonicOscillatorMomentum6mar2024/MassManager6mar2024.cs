using LibraryDifferentialEquations25Feb2024;
using System.Numerics;

namespace LibraryHarmonicOscillatorMomentum6mar2024
{
    public class MassManager6mar2024<T> : ParameterManager<T>
        where T : INumber<T>
    {
        public MassManager6mar2024(ParameterConfiguration mass_configuration = ParameterConfiguration.Constant)
            : base(mass_configuration)
        {
        }

        public T GetMass(T interval, T t)
        {
            return base.GetParameter(interval, t);
        }

    }
}
