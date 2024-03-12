using LibraryDifferentialEquations25Feb2024;

namespace LibraryAbstractFactoryDesignPattern12mar2024
{
    public abstract class SolverFactory12mar2024
    {
        public abstract ISolverDouble12mar2024 GetSolverDouble12mar2024(Method method);
        public abstract ISolverFloat12mar2024 GetSolverFloat12mar2024(Method method);
        public abstract ISolverHalf12mar2024 GetSolverHalf12mar2024(Method method);
    }
}
