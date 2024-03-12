using LibraryDifferentialEquationDog29Feb2024;
using LibraryDifferentialEquations25Feb2024;

namespace LibraryAbstractFactoryDesignPattern12mar2024
{
    public class SolverDogDouble12mar2024 : SolverDog12mar2024, ISolverDouble12mar2024
    {
        private double interval;
        private double x_end;
        private ConditionInitial26feb2024<double> initialCondition;
        private ulong number_of_steps;

        public double Interval { set { interval = value; } }
        public double X_end { set { x_end = value; } }
        public ConditionInitial26feb2024<double> InitialCondition { set { initialCondition = value; } }
        public ulong Number_of_steps { set { number_of_steps = value; } }

        private DifferentialEquationsSolver26feb2024<double> solver;

        public SolverDogDouble12mar2024(Method method)
        {
            var dog = new DifferentialEquationsDog29Feb2024<double>();
            solver = new DifferentialEquationsSolver26feb2024<double>(dog, method);
        }

        public void Solve(out double delta_x, out NumericalSolution26feb2024<double> solution)
        {
            solver.Solve(this.interval, this.x_end, this.initialCondition, this.number_of_steps, out delta_x, out solution);
        }

        public void Solve(out double delta_x, out NumericalSolutions26feb2024<double> solutions, int number_of_solutions = 10000)
        {
            solver.Solve(this.interval, this.x_end, this.initialCondition, this.number_of_steps, out delta_x, out solutions, number_of_solutions);
        }
    }
}
