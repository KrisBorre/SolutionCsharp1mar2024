namespace LibraryPhysicalUnits13feb2024.Test
{
    public class UnitTestWeight9feb2024
    {
        [Fact]
        public void Test1()
        {
            WeightInKilogram14feb2024 weightJohn = new WeightInKilogram14feb2024(80, 1);
            Assert.Equal(0.080, weightJohn.GetInTon());
            Assert.Equal(expected: 80, actual: weightJohn.GetInKilogram());
            Assert.Equal(expected: 176.37, actual: weightJohn.GetInPounds(), tolerance: 0.1);
        }

        [Fact]
        public void Test2()
        {
            IWeight7feb2024 weight = new WeightInKilogram14feb2024(10, 0);
            Assert.Equal(10, weight.GetInKilogram());
            Assert.Equal(expected: 0.01, actual: weight.GetInTon());
            Assert.Equal(expected: 22.046226, actual: weight.GetInPounds(), tolerance: 0.01);
        }

        [Fact]
        public void Test3()
        {
            WeightInKilogram14feb2024 weightInKilogram = new WeightInKilogram14feb2024(80, 1);

            IWeight7feb2024 weight1 = new WeightInKilogram14feb2024(60, 3);

            IWeight7feb2024 weight2 = new WeightInTon14feb2024(0.072, 0.01);

            WeightInKilogram14feb2024 totalWeight = WeightCalculation7feb2024.Add(weight1, weightInKilogram);

            Assert.Equal(expected: 140, actual: totalWeight.GetInKilogram());

            totalWeight = WeightCalculation7feb2024.Add(weight1, weight2);

            Assert.Equal(expected: 132, actual: totalWeight.GetInKilogram());
        }

        [Fact]
        public void Test4()
        {
            WeightInKilogram14feb2024 weightInKilogram = new WeightInKilogram14feb2024(80, 1);

            IWeight7feb2024 weight1 = new WeightInKilogram14feb2024(60, 3);

            IWeight7feb2024 weight2 = new WeightInTon14feb2024(0.072, 0.01);

            WeightInKilogram14feb2024 totalWeight = WeightCalculation7feb2024.Add(weightInKilogram, weight1);

            Assert.Equal(expected: 140, actual: totalWeight.GetInKilogram());

            Assert.Equal(expected: 0.14, actual: totalWeight.GetInTon());

            IWeight7feb2024 weight3 = WeightCalculation7feb2024.Add(weight2, weight1);

            Assert.Equal(expected: 132, actual: weight3.GetInKilogram());

            Assert.Equal(expected: 0.132, actual: weight3.GetInTon());
        }

        [Fact]
        public void Test5()
        {
            WeightInKilogram14feb2024 weightInKilogram = new WeightInKilogram14feb2024(20);
            var result = weightInKilogram.MultiplyBy(5);
            Assert.Equal(expected: 100, actual: result.GetInKilogram());
        }

        [Fact]
        public void Test6()
        {
            WeightInTon14feb2024 weightInTon = new WeightInTon14feb2024(20);
            var result = weightInTon.MultiplyBy(5);
            Assert.Equal(expected: 100, actual: result.GetInTon());
        }

        [Fact]
        public void Test7()
        {
            WeightInPounds14feb2024 weightInPounds = new WeightInPounds14feb2024(20);
            var result = weightInPounds.MultiplyBy(5);
            Assert.Equal(expected: 100, actual: result.GetInPounds());
        }

        [Fact]
        public void Test8()
        {
            WeightInKilogram14feb2024 weightInKilogram = new WeightInKilogram14feb2024(20);
            var result = weightInKilogram * 5;
            Assert.Equal(expected: 100, actual: result.GetInKilogram());
        }

        [Fact]
        public void Test9()
        {
            WeightInKilogram14feb2024 weightInKilogram = new WeightInKilogram14feb2024(20);
            var result = 5 * weightInKilogram;
            Assert.Equal(expected: 100, actual: result.GetInKilogram());
        }

        [Fact]
        public void Test10()
        {
            WeightInKilogram14feb2024 weightInKilogram = new WeightInKilogram14feb2024(80, 1);

            WeightInKilogram14feb2024 weight1 = new WeightInKilogram14feb2024(60, 3);

            WeightInTon14feb2024 weight2 = new WeightInTon14feb2024(0.072, 0.01);

            WeightInKilogram14feb2024 totalWeight = weight1 + weightInKilogram;

            Assert.Equal(expected: 140, actual: totalWeight.GetInKilogram());

            totalWeight = weight1 + weight2;

            Assert.Equal(expected: 132, actual: totalWeight.GetInKilogram());
        }

        [Fact]
        public void Test11()
        {
            WeightInKilogram14feb2024 weightInKilogram = new WeightInKilogram14feb2024(80, 1);

            WeightInKilogram14feb2024 weight1 = new WeightInKilogram14feb2024(60, 3);

            WeightInTon14feb2024 weight2 = new WeightInTon14feb2024(0.072, 0.01);

            WeightInKilogram14feb2024 totalWeight = weightInKilogram + weight1;

            Assert.Equal(expected: 140, actual: totalWeight.GetInKilogram());

            Assert.Equal(expected: 0.14, actual: totalWeight.GetInTon());

            IWeight7feb2024 weight3 = weight2 + weight1;

            Assert.Equal(expected: 132, actual: weight3.GetInKilogram());

            Assert.Equal(expected: 0.132, actual: weight3.GetInTon());
        }

        [Fact]
        public void Test12()
        {
            WeightInKilogram14feb2024 weightInKilogram = new WeightInKilogram14feb2024(20);
            var result = weightInKilogram.DivideBy(5);
            Assert.Equal(expected: 4, actual: result.GetInKilogram());
        }

        [Fact]
        public void Test13()
        {
            WeightInTon14feb2024 weightInTon = new WeightInTon14feb2024(20);
            var result = weightInTon.DivideBy(5);
            Assert.Equal(expected: 4, actual: result.GetInTon());
        }

        [Fact]
        public void Test14()
        {
            WeightInPounds14feb2024 weightInPounds = new WeightInPounds14feb2024(20);
            var result = weightInPounds.DivideBy(5);
            Assert.Equal(expected: 4, actual: result.GetInPounds());
        }

        [Fact]
        public void Test15()
        {
            WeightInKilogram14feb2024 weightInKilogram = new WeightInKilogram14feb2024(20);
            var result = weightInKilogram / 5;
            Assert.Equal(expected: 4, actual: result.GetInKilogram());
        }

        [Fact]
        public void Test16()
        {
            WeightInTon14feb2024 weightInTon = new WeightInTon14feb2024(20);
            var result = weightInTon / 5;
            Assert.Equal(expected: 4, actual: result.GetInTon());
        }

        [Fact]
        public void Test17()
        {
            WeightInPounds14feb2024 weightInPounds = new WeightInPounds14feb2024(20);
            var result = weightInPounds / 5;
            Assert.Equal(expected: 4, actual: result.GetInPounds());
        }

        [Fact]
        public void Test18()
        {
            List<HelperAverage.Animal> animals = new List<HelperAverage.Animal>();
            animals.Add(new HelperAverage.Animal { Weight = new WeightInKilogram14feb2024(10) });
            animals.Add(new HelperAverage.Animal { Weight = new WeightInKilogram14feb2024(20) });
            animals.Add(new HelperAverage.Animal { Weight = new WeightInKilogram14feb2024(30) });
            animals.Add(new HelperAverage.Animal { Weight = new WeightInKilogram14feb2024(5) });

            var average = HelperAverage.GetAverageWeight(animals);

            Assert.Equal(expected: 16.25, actual: average.GetInKilogram(), tolerance: 0.01);
        }
    }
}