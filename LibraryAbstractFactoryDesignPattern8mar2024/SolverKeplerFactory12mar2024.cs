using LibraryDifferentialEquations25Feb2024;

namespace LibraryAbstractFactoryDesignPattern12mar2024
{
    public class SolverKeplerFactory12mar2024 : SolverFactory12mar2024
    {
        public SolverKeplerFactory12mar2024()
        {

        }
        public override ISolverDouble12mar2024 GetSolverDouble12mar2024(Method method)
        {
            return new SolverKeplerDouble12mar2024(method);
        }

        public override ISolverFloat12mar2024 GetSolverFloat12mar2024(Method method)
        {
            return new SolverKeplerFloat12mar2024(method);
        }

        public override ISolverHalf12mar2024 GetSolverHalf12mar2024(Method method)
        {
            return new SolverKeplerHalf12mar2024(method);
        }
    }
}
