namespace LibraryPhysicalUnits13feb2024
{
    public class Spring2Calculation
    {
        public static SpringInNewtonPerSquareMeter Add(ISpring2 spring1, ISpring2 spring2)
        {
            double accuracy = Math.Sqrt(Math.Pow(spring1.GetPrecisionInNewtonPerSquareMeter(), 2) + Math.Pow(spring2.GetPrecisionInNewtonPerSquareMeter(), 2));
            return new SpringInNewtonPerSquareMeter(spring1.GetInNewtonPerSquareMeter() + spring2.GetInNewtonPerSquareMeter(), accuracy);
        }

        public static SpringInNewtonPerSquareMeter Substract(ISpring2 spring1, ISpring2 spring2)
        {
            double accuracy = Math.Sqrt(Math.Pow(spring1.GetPrecisionInNewtonPerSquareMeter(), 2) + Math.Pow(spring2.GetPrecisionInNewtonPerSquareMeter(), 2));
            return new SpringInNewtonPerSquareMeter(spring1.GetInNewtonPerSquareMeter() - spring2.GetInNewtonPerSquareMeter(), accuracy);
        }
    }
}

