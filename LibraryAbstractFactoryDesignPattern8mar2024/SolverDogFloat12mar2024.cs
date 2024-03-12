using LibraryDifferentialEquationDog29Feb2024;
using LibraryDifferentialEquations25Feb2024;

namespace LibraryAbstractFactoryDesignPattern12mar2024
{
    public class SolverDogFloat12mar2024 : SolverDog12mar2024, ISolverFloat12mar2024
    {
        private float interval;
        private float x_end;
        private ConditionInitial26feb2024<float> initialCondition;
        private ulong number_of_steps;

        public float Interval { set { interval = value; } }
        public float X_end { set { x_end = value; } }
        public ConditionInitial26feb2024<float> InitialCondition { set { initialCondition = value; } }
        public ulong Number_of_steps { set { number_of_steps = value; } }

        private DifferentialEquationsSolver26feb2024<float> solver;

        public SolverDogFloat12mar2024(Method method)
        {
            var dog = new DifferentialEquationsDog29Feb2024<float>();
            solver = new DifferentialEquationsSolver26feb2024<float>(dog, method);
        }

        public void Solve(out float delta_x, out NumericalSolution26feb2024<float> solution)
        {
            solver.Solve(interval, x_end, initialCondition, number_of_steps, out delta_x, out solution);
        }

        public void Solve(out float delta_x, out NumericalSolutions26feb2024<float> solutions, int number_of_solutions = 10000)
        {
            solver.Solve(interval, x_end, initialCondition, number_of_steps, out delta_x, out solutions, number_of_solutions);
        }
    }
}
