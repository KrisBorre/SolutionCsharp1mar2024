using LibraryDifferentialEquations25Feb2024;

namespace LibraryDifferentialEquationKepler25feb2024
{
    public class MassStarManagerHalf : ParameterManager<Half>
    {
        public MassStarManagerHalf(ParameterConfiguration mass_star_configuration = ParameterConfiguration.Constant) : base(mass_star_configuration)
        { }

        public Half GetMassStar(Half interval, Half t)
        {
            return base.GetParameter(interval, t);
        }
    }
}
