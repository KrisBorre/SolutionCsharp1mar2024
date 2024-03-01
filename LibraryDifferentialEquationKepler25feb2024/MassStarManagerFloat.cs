using LibraryDifferentialEquations25Feb2024;

namespace LibraryDifferentialEquationKepler25feb2024
{
    public class MassStarManagerFloat : ParameterManager<float>
    {
        public MassStarManagerFloat(ParameterConfiguration mass_star_configuration = ParameterConfiguration.Constant) : base(mass_star_configuration)
        { }

        public float GetMassStar(float interval, float t)
        {
            return base.GetParameter(interval, t);
        }
    }
}
