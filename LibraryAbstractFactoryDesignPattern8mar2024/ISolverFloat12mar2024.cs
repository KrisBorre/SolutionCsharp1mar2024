using LibraryDifferentialEquations25Feb2024;

namespace LibraryAbstractFactoryDesignPattern12mar2024
{
    public interface ISolverFloat12mar2024
    {
        public abstract void Solve(out float delta_x, out NumericalSolution26feb2024<float> solution);

        public abstract void Solve(out float delta_x, out NumericalSolutions26feb2024<float> solutions, int number_of_solutions = 10000);

        public float Interval { set; }
        public float X_end { set; }
        public ConditionInitial26feb2024<float> InitialCondition { set; }
        public ulong Number_of_steps { set; }
    }
}
