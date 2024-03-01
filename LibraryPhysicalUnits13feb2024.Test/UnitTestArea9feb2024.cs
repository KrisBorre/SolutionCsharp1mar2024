namespace LibraryPhysicalUnits13feb2024.Test
{
    public class UnitTestArea9feb2024
    {
        [Fact]
        public void Test1()
        {
            IArea area = new AreaInSquareMeter(5, 0);
            Assert.Equal(expected: 5, actual: area.GetInSquareMeter());
            Assert.Equal(expected: 50000, actual: area.GetInSquareCentimeter());
        }

        [Fact]
        public void Test2()
        {
            AreaInSquareMeter area = new AreaInSquareMeter(5, 0);
            Assert.Equal(expected: 5, actual: area.GetInSquareMeter());
            Assert.Equal(expected: 50000, actual: area.GetInSquareCentimeter());
        }

        [Fact]
        public void Test3()
        {
            AreaInSquareCentimeter area = new AreaInSquareCentimeter(2, 0);
            Assert.Equal(expected: 2, actual: area.GetInSquareCentimeter());
        }

        [Fact]
        public void Test4()
        {
            AreaInSquareCentimeter area = new AreaInSquareCentimeter(2, 0);
            Assert.Equal(expected: 2, actual: area.GetInSquareCentimeter());
            Assert.Equal(expected: 0.0002, actual: area.GetInSquareMeter());
        }

        [Fact]
        public void Test5()
        {
            AreaInSquareMeter area1 = new AreaInSquareMeter(5, 0);
            Assert.Equal(expected: 5, actual: area1.GetInSquareMeter());
            Assert.Equal(expected: 50000, actual: area1.GetInSquareCentimeter());

            AreaInSquareCentimeter area2 = new AreaInSquareCentimeter(2, 0);
            Assert.Equal(expected: 2, actual: area2.GetInSquareCentimeter());
            Assert.Equal(expected: 0.0002, actual: area2.GetInSquareMeter());

            IArea totalArea = AreaCalculation.Add(area1, area2);

            Assert.Equal(expected: 5.0002, actual: totalArea.GetInSquareMeter(), tolerance: 0.00001);
            Assert.Equal(expected: 50002, actual: totalArea.GetInSquareCentimeter(), tolerance: 0.00001);
        }

        [Fact]
        public void Test6()
        {
            AreaInSquareMeter area = new AreaInSquareMeter(5, 0);
            var result = area.MultiplyBy(3);
            Assert.Equal(expected: 15, actual: result.GetInSquareMeter());
        }

        [Fact]
        public void Test7()
        {
            AreaInSquareMeter area = new AreaInSquareMeter(5, 0);
            var result = area.MultiplyBy(3);
            Assert.Equal(expected: 150000, actual: result.GetInSquareCentimeter());
        }

        [Fact]
        public void Test8()
        {
            AreaInSquareMeter area = new AreaInSquareMeter(5, 0);
            var result = area * 3;
            Assert.Equal(expected: 15, actual: result.GetInSquareMeter());
        }

        [Fact]
        public void Test9()
        {
            AreaInSquareMeter area = new AreaInSquareMeter(5, 0);
            var result = 3 * area;
            Assert.Equal(expected: 15, actual: result.GetInSquareMeter());
        }

        [Fact]
        public void Test10()
        {
            AreaInSquareMeter area = new AreaInSquareMeter(10, 0);
            var result = area.DivideBy(5);
            Assert.Equal(expected: 2, actual: result.GetInSquareMeter());
        }

        [Fact]
        public void Test11()
        {
            AreaInSquareMeter area = new AreaInSquareMeter(10, 0);
            var result = area / 5;
            Assert.Equal(expected: 2, actual: result.GetInSquareMeter());
        }


        [Fact]
        public void Test12()
        {
            LengthInMeter14feb2024 length1 = new LengthInMeter14feb2024(3, 0);

            LengthInMeter14feb2024 length2 = new LengthInMeter14feb2024(4, 0);

            AreaInSquareMeter result = length1 * length2;

            Assert.Equal(expected: 12, actual: result.GetInSquareMeter());
        }

        [Fact]
        public void Test13()
        {
            LengthInMeter14feb2024 length1 = new LengthInMeter14feb2024(5, 0);
            Assert.Equal(expected: 5, actual: length1.GetInMeter());

            LengthInCentimeter14feb2024 length2 = new LengthInCentimeter14feb2024(2, 0);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            AreaInSquareMeter result = length1 * length2;

            Assert.Equal(expected: 0.1, actual: result.GetInSquareMeter());
        }


        [Fact]
        public void Test14()
        {
            LengthInCentimeter14feb2024 length1 = new LengthInCentimeter14feb2024(2, 0);
            Assert.Equal(expected: 2, actual: length1.GetInCentimeter());
            Assert.Equal(expected: 0.02, actual: length1.GetInMeter());

            LengthInMeter14feb2024 length2 = new LengthInMeter14feb2024(5, 0);
            Assert.Equal(expected: 5, actual: length2.GetInMeter());
            Assert.Equal(expected: 500, actual: length2.GetInCentimeter());

            AreaInSquareMeter result = length1 * length2;

            Assert.Equal(expected: 0.1, actual: result.GetInSquareMeter());
        }

        [Fact]
        public void Test15()
        {
            double x = 1;
            var lengthInMeter = new LengthInMeter14feb2024(x, 0);
            var area = HelperCircle.CalculateArea(diameter: lengthInMeter);
            Assert.Equal(expected: 0.7853981633974483, actual: area.GetInSquareMeter(), tolerance: 0.000001);
        }

        [Fact]
        public void Test16()
        {
            double x = 0.35;
            var lengthInMeter = new LengthInMeter14feb2024(x, 0);
            var area = HelperCircle.CalculateArea(diameter: lengthInMeter);
            Assert.Equal(expected: 0.09621127501618, actual: area.GetInSquareMeter(), tolerance: 0.000001);
        }



    }
}
