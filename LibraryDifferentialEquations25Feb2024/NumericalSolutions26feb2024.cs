using System.Numerics;

namespace LibraryDifferentialEquations25Feb2024
{
    public class NumericalSolutions26feb2024<T>
        //: IIndexInterface26feb2024<NumericalSolution26feb2024<T>>
        where T : INumber<T>
    {
        // https://devblogs.microsoft.com/dotnet/dotnet-7-generic-math/
        // https://en.wikipedia.org/wiki/.NET
        // https://learn.microsoft.com/en-us/dotnet/api/system.numerics?view=net-8.0

        private NumericalSolution26feb2024<T>[] numericalSolutions;

        public int Length
        {
            get { return numericalSolutions.Length; }
        }

        public int NumberOfSolutions
        {
            get { return numericalSolutions.Length; }
            set
            {
                numericalSolutions = new NumericalSolution26feb2024<T>[value];
            }
        }

        public NumericalSolution26feb2024<T> this[int index]
        {
            get
            {
                return numericalSolutions[index];
            }
            set
            {
                numericalSolutions[index] = value;
            }
        }
    }
}
