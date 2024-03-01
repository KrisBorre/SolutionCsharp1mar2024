namespace LibraryPhysicalUnits13feb2024
{
    public static class WeightCalculation7feb2024
    {
        public static double ConvertTonIntoKilogram(double weight)
        {
            return weight * 1000;
        }

        public static double ConvertKilogramIntoTon(double weight)
        {
            return weight / 1000.0;
        }

        /// <summary>
        /// Precondition: weight1 and weight2 are independently measured
        /// </summary>
        /// <param name="weight1"></param>
        /// <param name="weight2"></param>
        /// <returns></returns>
        public static WeightInKilogram14feb2024 Add(IWeight7feb2024 weight1, IWeight7feb2024 weight2)
        {
            double accuracy = Math.Sqrt(Math.Pow(weight1.GetPrecisionInKilogram(), 2) + Math.Pow(weight2.GetPrecisionInKilogram(), 2));
            return new WeightInKilogram14feb2024(weight1.GetInKilogram() + weight2.GetInKilogram(), accuracy);
        }

        // 1 kilogram (kg) is equal to 2,20462262185 pounds (lbs).
        public static double ConvertPoundsIntoKilogram(double weight)
        {
            return weight / 2.20462262185;
        }

        // 1 kilogram (kg) is equal to 2,20462262185 pounds (lbs).
        public static double ConvertKilogramIntoPounds(double weight)
        {
            return weight * 2.20462262185;
        }

        public static double ConvertTonIntoPounds(double weight)
        {
            return weight * 2204.62262185;
        }

        public static double ConvertPoundsIntoTon(double weight)
        {
            return weight / 2204.62262185;
        }
    }
}
