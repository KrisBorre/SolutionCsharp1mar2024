using LibraryDifferentialEquations25Feb2024;

namespace LibraryDifferentialEquationKepler25feb2024
{
    public class MassStarManagerDouble : ParameterManager<double>
    {
        public MassStarManagerDouble(ParameterConfiguration mass_star_configuration = ParameterConfiguration.Constant) : base(mass_star_configuration)
        { }

        public double GetMassStar(double interval, double t)
        {
            return base.GetParameter(interval, t);
        }
    }
}
