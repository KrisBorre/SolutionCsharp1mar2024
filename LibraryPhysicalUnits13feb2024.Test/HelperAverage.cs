namespace LibraryPhysicalUnits13feb2024.Test
{
    internal class HelperAverage
    {
        public class Animal
        {
            public WeightInKilogram14feb2024 Weight { get; set; }
        }

        public static WeightInKilogram14feb2024 GetAverageWeight(List<Animal> list)
        {
            WeightInKilogram14feb2024 average = new WeightInKilogram14feb2024(0);
            if (list != null && list.Count > 0)
            {
                foreach (Animal animal in list)
                {
                    average += animal.Weight;
                }
                average /= list.Count;
            }
            return average;
        }
    }
}
