using LibraryDifferentialEquations25Feb2024;

namespace ConsoleDifferentialEquationWorkToCompressASpring28feb2024
{
    internal class DifferentialEquation1 : DifferentialEquationBaseClass26feb2024<float>
    {
        float k;

        public DifferentialEquation1(float k = 50)
        {
            this.k = k;
        }

        public override float function(float interval, float x, params float[] y)
        {
            return k * x;
        }
    }
}
