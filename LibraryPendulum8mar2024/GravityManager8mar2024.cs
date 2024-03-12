using LibraryDifferentialEquations25Feb2024;
using System.Numerics;

namespace LibraryPendulum8mar2024
{
    public class GravityManager8mar2024<T> : ParameterManager<T>
       where T : INumber<T>
    {
        public GravityManager8mar2024(ParameterConfiguration gravity_configuration = ParameterConfiguration.Constant)
            : base(gravity_configuration)
        {
        }

        public T GetGravity(T interval, T t)
        {
            return base.GetParameter(interval, t);
        }
    }
}
