using System.Numerics;

namespace LibraryDifferentialEquations25Feb2024
{
    // Indexer on an interface:
    public interface IIndexInterface26feb2024<T>
        where T : INumber<T>
    {
        // Indexer declaration:
        T this[int index]
        {
            get;
            set;
        }
    }
}
