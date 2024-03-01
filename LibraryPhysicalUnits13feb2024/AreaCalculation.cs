namespace LibraryPhysicalUnits13feb2024
{
    // https://en.wikipedia.org/wiki/Category:Units_of_area
    public class AreaCalculation
    {
        public static double ConvertSquareMeterIntoSquareCentimeter(double length)
        {
            return length * 10000;
        }

        public static double ConvertSquareCentimeterIntoSquareMeter(double length)
        {
            return length / 10000;
        }

        public static AreaInSquareMeter Add(IArea area1, IArea area2)
        {
            double accuracy = Math.Sqrt(Math.Pow(area1.GetPrecisionInSquareMeter(), 2) + Math.Pow(area2.GetPrecisionInSquareMeter(), 2));
            return new AreaInSquareMeter(area1.GetInSquareMeter() + area2.GetInSquareMeter(), accuracy);
        }

        public static AreaInSquareMeter Substract(IArea area1, IArea area2)
        {
            double accuracy = Math.Sqrt(Math.Pow(area1.GetPrecisionInSquareMeter(), 2) + Math.Pow(area2.GetPrecisionInSquareMeter(), 2));
            return new AreaInSquareMeter(area1.GetInSquareMeter() - area2.GetInSquareMeter(), accuracy);
        }

        public static AreaInSquareMeter Multiply(ILength14feb2024 length1, ILength14feb2024 length2)
        {
            double accuracy = Math.Sqrt(Math.Pow(length1.GetPrecisionInMeter() * length2.GetInMeter(), 2) + Math.Pow(length2.GetPrecisionInMeter() * length1.GetInMeter(), 2));
            return new AreaInSquareMeter(length1.GetInMeter() * length2.GetInMeter(), accuracy);
        }
    }
}
