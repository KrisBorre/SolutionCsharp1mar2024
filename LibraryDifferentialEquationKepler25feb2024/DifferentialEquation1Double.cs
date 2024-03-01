﻿using LibraryDifferentialEquations25Feb2024;

namespace LibraryDifferentialEquationKepler25feb2024
{
    public class DifferentialEquation1Double : DifferentialEquationBaseClass26feb2024<double>
    {
        private MassExoplanetManagerDouble mass_exoplanet_manager;
        private MassStarManagerDouble mass_star_manager;

        public DifferentialEquation1Double(MassExoplanetManagerDouble mass_exoplanet_manager,
            MassStarManagerDouble mass_star_manager,
            ParameterConfiguration mass_exoplanet_configuration = ParameterConfiguration.Constant,
            ParameterConfiguration mass_star_configuration = ParameterConfiguration.Constant)
        {
            this.mass_exoplanet_manager = mass_exoplanet_manager;
            this.mass_star_manager = mass_star_manager;
        }

        public override double function(double interval, double x, params double[] y)
        {
            double mass = mass_exoplanet_manager.GetMassExoplanet(interval, x);
            return y[2] / mass;
        }
    }
}
