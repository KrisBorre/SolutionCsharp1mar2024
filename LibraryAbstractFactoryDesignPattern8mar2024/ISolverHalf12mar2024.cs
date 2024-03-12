using LibraryDifferentialEquations25Feb2024;

namespace LibraryAbstractFactoryDesignPattern12mar2024
{
    public interface ISolverHalf12mar2024
    {
        public abstract void Solve(out Half delta_x, out NumericalSolution26feb2024<Half> solution);

        public abstract void Solve(out Half delta_x, out NumericalSolutions26feb2024<Half> solutions, int number_of_solutions = 10000);

        public Half Interval { set; }
        public Half X_end { set; }
        public ConditionInitial26feb2024<Half> InitialCondition { set; }
        public ulong Number_of_steps { set; }
    }
}
