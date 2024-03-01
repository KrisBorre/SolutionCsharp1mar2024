using LibraryDifferentialEquations25Feb2024;
using System.Numerics;

namespace LibraryDifferentialEquationDog29Feb2024
{
    public class DifferentialEquationsDog29Feb2024<T> : DifferentialEquationsBaseClass26feb2024<T>
        where T : INumber<T>
    {
        private void Initialize(T ratio)
        {
            this.NumberOfFirstOrderEquations = 2;
            this[0] = new DifferentialEquation1<T>();
            this[1] = new DifferentialEquation2<T>(ratio);
        }

        public DifferentialEquationsDog29Feb2024()
        {
            T ratio = T.CreateChecked(0.5);
            Initialize(ratio);
        }

        public DifferentialEquationsDog29Feb2024(T ratio)
        {
            Initialize(ratio);
        }
    }
}