using LibraryDifferentialEquations25Feb2024;
using System.Numerics;

namespace LibraryDifferentialEquationDog29Feb2024
{
    public class DifferentialEquation2<T> : DifferentialEquationBaseClass26feb2024<T>
        where T : INumber<T>
    {
        public T ratio; // ratio is a constant, but it could also be a function of x.

        public DifferentialEquation2(T ratio)
        {
            this.ratio = ratio;
        }

        public DifferentialEquation2()
        {
            this.ratio = T.CreateChecked(0.5); // 1.0 / 2; // v / w
                                               // Dog is twice as fast as the master.
        }

        public override T function(T interval, T x, params T[] y)
        {
            return (ratio / x) * T.CreateChecked(Math.Pow(1.0 + double.CreateChecked(y[1] * y[1]), 0.5));
        }
    }
}
