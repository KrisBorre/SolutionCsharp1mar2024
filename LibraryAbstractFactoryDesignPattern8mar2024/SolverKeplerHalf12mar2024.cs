using LibraryDifferentialEquationKepler26Feb2024;
using LibraryDifferentialEquations25Feb2024;

namespace LibraryAbstractFactoryDesignPattern12mar2024
{
    public class SolverKeplerHalf12mar2024 : SolverKepler12mar2024, ISolverHalf12mar2024
    {
        private Half interval;
        private Half x_end;
        private ConditionInitial26feb2024<Half> initialCondition;
        private ulong number_of_steps;

        public Half Interval { set { interval = value; } }
        public Half X_end { set { x_end = value; } }
        public ConditionInitial26feb2024<Half> InitialCondition { set { initialCondition = value; } }
        public ulong Number_of_steps { set { number_of_steps = value; } }

        private DifferentialEquationsSolver26feb2024<Half> solver;

        public SolverKeplerHalf12mar2024(Method method)
        {
            var kepler = new DifferentialEquationsKepler<Half>();
            solver = new DifferentialEquationsSolver26feb2024<Half>(kepler, method);
        }

        public void Solve(out Half delta_x, out NumericalSolution26feb2024<Half> solution)
        {
            solver.Solve(interval, x_end, initialCondition, number_of_steps, out delta_x, out solution);
        }

        public void Solve(out Half delta_x, out NumericalSolutions26feb2024<Half> solutions, int number_of_solutions = 10000)
        {
            solver.Solve(interval, x_end, initialCondition, number_of_steps, out delta_x, out solutions, number_of_solutions);
        }
    }
}
