using LibraryDifferentialEquations25Feb2024;
using System.Numerics;

namespace LibraryDifferentialEquationDog29Feb2024
{
    public class DifferentialEquation1<T> : DifferentialEquationBaseClass26feb2024<T>
        where T : INumber<T>
    {
        public override T function(T interval, T x, params T[] y)
        {
            return y[1];
        }
    }
}
