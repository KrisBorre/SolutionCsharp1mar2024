using LibraryDifferentialEquations25Feb2024;

namespace LibraryAbstractFactoryDesignPattern12mar2024
{
    public interface ISolverDouble12mar2024
    {
        public abstract void Solve(out double delta_x, out NumericalSolution26feb2024<double> solution);

        public abstract void Solve(out double delta_x, out NumericalSolutions26feb2024<double> solutions, int number_of_solutions = 10000);

        public double Interval { set; }
        public double X_end { set; }
        public ConditionInitial26feb2024<double> InitialCondition { set; }
        public ulong Number_of_steps { set; }
    }
}
