using LibraryDifferentialEquations25Feb2024;
using System.Numerics;

namespace LibraryPendulum8mar2024
{
    public class LengthManager8mar2024<T> : ParameterManager<T>
       where T : INumber<T>
    {
        public LengthManager8mar2024(ParameterConfiguration length_configuration = ParameterConfiguration.Constant)
              : base(length_configuration)
        {
        }

        public T GetLength(T interval, T t)
        {
            return base.GetParameter(interval, t);
        }
    }
}
