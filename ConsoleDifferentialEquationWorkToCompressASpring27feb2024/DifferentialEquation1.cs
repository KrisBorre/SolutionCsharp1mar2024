using System;
using System.Collections.Generic;
using LibraryDifferentialEquations25Feb2024;

namespace ConsoleDifferentialEquationWorkToCompressASpring27feb2024
{
    internal class DifferentialEquation1 : DifferentialEquationBaseClass26feb2024<Half>
    {
        Half k;

        public DifferentialEquation1(Half k)
        {
            this.k = k;
        }

        public override Half function(Half interval, Half x, params Half[] y)
        {
            return k * x;
        }
    }
}
