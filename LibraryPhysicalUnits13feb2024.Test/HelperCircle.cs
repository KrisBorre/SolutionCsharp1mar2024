namespace LibraryPhysicalUnits13feb2024.Test
{
    internal class HelperCircle
    {
        public static AreaInSquareMeter Square(LengthInMeter14feb2024 x)
        {
            return x * x;
        }

        public static LengthInMeter14feb2024 CalculateRadius(LengthInMeter14feb2024 diameter)
        {
            return diameter / 2;
        }

        // https://en.wikipedia.org/wiki/Circumference
        public static LengthInMeter14feb2024 CalculateCircumference(LengthInMeter14feb2024 diameter)
        {
            return 2 * Math.PI * CalculateRadius(diameter);
        }

        // https://en.wikipedia.org/wiki/Circle
        public static AreaInSquareMeter CalculateArea(LengthInMeter14feb2024 diameter)
        {
            return Math.PI * Square(CalculateRadius(diameter));
        }
    }
}
