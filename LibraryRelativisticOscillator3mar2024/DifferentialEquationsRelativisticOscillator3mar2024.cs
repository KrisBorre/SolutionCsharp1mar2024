﻿using LibraryDifferentialEquations25Feb2024;
using System.Numerics;

namespace LibraryRelativisticOscillator3mar2024
{
    public class DifferentialEquationsRelativisticOscillator3mar2024<T> : DifferentialEquationsBaseClass26feb2024<T>
        where T : INumber<T>
    {
        private MassManager3mar2024<T> mass_manager;
        private SpringManager3mar2024<T> spring_manager;

        public DifferentialEquationsRelativisticOscillator3mar2024(ParameterConfiguration spring_configuration = ParameterConfiguration.Constant, ParameterConfiguration mass_configuration = ParameterConfiguration.Constant)
        {
            this.spring_manager = new SpringManager3mar2024<T>(spring_configuration);
            this.mass_manager = new MassManager3mar2024<T>(mass_configuration);

            this.NumberOfFirstOrderEquations = 2;
            this[0] = new DifferentialEquation1_3mar2024<T>(spring_manager, mass_manager);
            this[1] = new DifferentialEquation2_3mar2024<T>(spring_manager, mass_manager);
        }

        public T GetSpring(T interval, T t)
        {
            return spring_manager.GetSpring(interval, t);
        }

        public T GetMass(T interval, T t)
        {
            return mass_manager.GetMass(interval, t);
        }
    }
}

