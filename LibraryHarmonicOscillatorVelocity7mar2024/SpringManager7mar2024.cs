﻿using LibraryDifferentialEquations25Feb2024;
using System.Numerics;

namespace LibraryHarmonicOscillatorVelocity7mar2024
{
    public class SpringManager7mar2024<T> : ParameterManager<T>
        where T : INumber<T>
    {
        public SpringManager7mar2024(ParameterConfiguration spring_configuration = ParameterConfiguration.Constant)
              : base(spring_configuration)
        {
        }

        public T GetSpring(T interval, T t)
        {
            return base.GetParameter(interval, t);
        }
    }
}