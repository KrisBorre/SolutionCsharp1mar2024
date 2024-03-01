namespace LibraryPhysicalUnits13feb2024.Test
{
    public class UnitTestLength14feb2024
    {
        [Fact]
        public void Test1()
        {
            ILength14feb2024 length = new LengthInMeter14feb2024(5, 0);
            Assert.Equal(expected: 5, actual: length.GetInMeter());
        }

        [Fact]
        public void Test2()
        {
            LengthInCentimeter14feb2024 length = new LengthInCentimeter14feb2024(2, 0);
            Assert.Equal(expected: 2, actual: length.GetInCentimeter());
        }

        [Fact]
        public void Test3()
        {
            LengthInCentimeter14feb2024 length = new LengthInCentimeter14feb2024(2, 0);
            Assert.Equal(expected: 2, actual: length.GetInCentimeter());
            Assert.Equal(expected: 0.02, actual: length.GetInMeter());
        }

        [Fact]
        public void Test4()
        {
            ILength14feb2024 length = new LengthInMeter14feb2024(5, 0);
            Assert.Equal(expected: 5, actual: length.GetInMeter());
            Assert.Equal(expected: 500, actual: length.GetInCentimeter());
        }

        [Fact]
        public void Test5()
        {
            ILength14feb2024 length = new LengthInMeter14feb2024(5, 1);
            Assert.Equal(expected: 5, actual: length.GetInMeter(), tolerance: 1);
        }

        [Fact]
        public void Test6()
        {
            LengthInCentimeter14feb2024 length = new LengthInCentimeter14feb2024(2, 0.1);
            Assert.Equal(expected: 2, actual: length.GetInCentimeter(), tolerance: 0.1);
        }

        [Fact]
        public void Test7()
        {
            ILength14feb2024 length = new LengthInMeter14feb2024(5, 1);
            Assert.Equal(expected: 5, actual: length.GetInMeter(), tolerance: 1);
            Assert.Equal(expected: 500, actual: length.GetInCentimeter(), tolerance: 100);
        }

        [Fact]
        public void Test8()
        {
            ILength14feb2024 length1 = new LengthInMeter14feb2024(5, 0);
            Assert.Equal(expected: 5, actual: length1.GetInMeter());

            LengthInCentimeter14feb2024 length2 = new LengthInCentimeter14feb2024(2, 0);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            ILength14feb2024 totalLength = LengthCalculation14feb2024.Add(length1, length2);

            Assert.Equal(expected: 502, actual: totalLength.GetInCentimeter(), tolerance: 1);
        }

        [Fact]
        public void Test9()
        {
            ILength14feb2024 length1 = new LengthInMeter14feb2024(5, 0);
            Assert.Equal(expected: 5, actual: length1.GetInMeter());

            LengthInCentimeter14feb2024 length2 = new LengthInCentimeter14feb2024(2, 0);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            ILength14feb2024 totalLength = LengthCalculation14feb2024.Add(length1, length2);

            Assert.Equal(expected: 5.02, actual: totalLength.GetInMeter(), tolerance: 0.01);
        }

        [Fact]
        public void Test10()
        {
            ILength14feb2024 length1 = new LengthInCentimeter14feb2024(5, 0);
            Assert.Equal(expected: 0.05, actual: length1.GetInMeter());

            ILength14feb2024 length2 = new LengthInCentimeter14feb2024(2, 0);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            ILength14feb2024 totalLength = LengthCalculation14feb2024.Add(length1, length2);

            Assert.Equal(expected: 0.07, actual: totalLength.GetInMeter(), tolerance: 0.01);
        }

        [Fact]
        public void Test11()
        {
            ILength14feb2024 length1 = new LengthInMeter14feb2024(5, 1);
            Assert.Equal(expected: 5, actual: length1.GetInMeter());

            LengthInCentimeter14feb2024 length2 = new LengthInCentimeter14feb2024(2, 0.1);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            ILength14feb2024 totalLength = LengthCalculation14feb2024.Add(length1, length2);

            Assert.Equal(expected: 502, actual: totalLength.GetInCentimeter(), tolerance: 150);
        }

        [Fact]
        public void Test12()
        {
            ILength14feb2024 length1 = new LengthInMeter14feb2024(5, 0.1);
            Assert.Equal(expected: 5, actual: length1.GetInMeter());

            LengthInCentimeter14feb2024 length2 = new LengthInCentimeter14feb2024(2, 1);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            ILength14feb2024 totalLength = LengthCalculation14feb2024.Add(length1, length2);

            Assert.Equal(expected: 5.02, actual: totalLength.GetInMeter(), tolerance: 0.15);
        }

        [Fact]
        public void Test13()
        {
            ILength14feb2024 length1 = new LengthInCentimeter14feb2024(5, 0.002);
            Assert.Equal(expected: 0.05, actual: length1.GetInMeter());

            ILength14feb2024 length2 = new LengthInCentimeter14feb2024(2, 0);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            ILength14feb2024 totalLength = LengthCalculation14feb2024.Add(length1, length2);

            Assert.Equal(expected: 0.07, actual: totalLength.GetInMeter(), tolerance: 0.002);
        }

        [Fact]
        public void Test14()
        {
            LengthInMeter14feb2024 lengthInMeter = new LengthInMeter14feb2024(5, 0);
            ILength14feb2024 result = lengthInMeter.MultiplyBy(20);
            Assert.Equal(expected: 100, actual: result.GetInMeter());
        }

        [Fact]
        public void Test15()
        {
            LengthInMeter14feb2024 lengthInMeter = new LengthInMeter14feb2024(5, 0);
            LengthInMeter14feb2024 result = lengthInMeter * 20;
            Assert.Equal(expected: 100, actual: result.GetInMeter());
        }

        [Fact]
        public void Test16()
        {
            LengthInMeter14feb2024 lengthInMeter = new LengthInMeter14feb2024(5, 0);
            LengthInMeter14feb2024 result = 20 * lengthInMeter;
            Assert.Equal(expected: 100, actual: result.GetInMeter());
        }

        [Fact]
        public void Test17()
        {
            LengthInMeter14feb2024 lengthInMeter = new LengthInMeter14feb2024(5, 1);
            ILength14feb2024 result = lengthInMeter.MultiplyBy(20);
            Assert.Equal(expected: 100, actual: result.GetInMeter());
            Assert.Equal(expected: 20, actual: result.GetPrecisionInMeter());
        }

        [Fact]
        public void Test18()
        {
            LengthInMeter14feb2024 lengthInMeter = new LengthInMeter14feb2024(5, 1);
            LengthInMeter14feb2024 result = lengthInMeter * 20;
            Assert.Equal(expected: 100, actual: result.GetInMeter());
            Assert.Equal(expected: 20, actual: result.GetPrecisionInMeter());
        }

        [Fact]
        public void Test19()
        {
            LengthInMeter14feb2024 lengthInMeter = new LengthInMeter14feb2024(5, 1);
            LengthInMeter14feb2024 result = 20 * lengthInMeter;
            Assert.Equal(expected: 100, actual: result.GetInMeter());
            Assert.Equal(expected: 20, actual: result.GetPrecisionInMeter());
        }

        [Fact]
        public void Test20()
        {
            LengthInMeter14feb2024 lengthInMeter = new LengthInMeter14feb2024(5, 0);
            LengthInMeter14feb2024 result = lengthInMeter.DivideBy(5);
            Assert.Equal(expected: 1, actual: result.GetInMeter());
        }

        [Fact]
        public void Test21()
        {
            LengthInMeter14feb2024 lengthInMeter = new LengthInMeter14feb2024(5, 0);
            LengthInMeter14feb2024 result = lengthInMeter / 5;
            Assert.Equal(expected: 1, actual: result.GetInMeter());
        }

        [Fact]
        public void Test22()
        {
            //LengthInMeter lengthInMeter = new LengthInMeter(5, 0);
            // InvertedLengthInMeter result = 5 / lengthInMeter;
            //Assert.Equal(expected: 1, actual: result.GetInInvertedMeter());
        }

        [Fact]
        public void Test23()
        {
            LengthInMeter14feb2024 lengthInMeter = new LengthInMeter14feb2024(5, 1);
            LengthInMeter14feb2024 result = lengthInMeter.DivideBy(5);
            Assert.Equal(expected: 1, actual: result.GetInMeter());
            Assert.Equal(expected: 0.2, actual: result.GetPrecisionInMeter());
        }

        [Fact]
        public void Test24()
        {
            LengthInMeter14feb2024 lengthInMeter = new LengthInMeter14feb2024(5, 1);
            LengthInMeter14feb2024 result = lengthInMeter / 5;
            Assert.Equal(expected: 1, actual: result.GetInMeter());
            Assert.Equal(expected: 0.2, actual: result.GetPrecisionInMeter());
        }

        [Fact]
        public void Test25()
        {
            LengthInMeter14feb2024 length1 = new LengthInMeter14feb2024(5, 0);
            Assert.Equal(expected: 5, actual: length1.GetInMeter());

            LengthInCentimeter14feb2024 length2 = new LengthInCentimeter14feb2024(2, 0);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            LengthInMeter14feb2024 totalLength = length1 + length2;

            Assert.Equal(expected: 502, actual: totalLength.GetInCentimeter(), tolerance: 1);
        }

        [Fact]
        public void Test26()
        {
            LengthInMeter14feb2024 length1 = new LengthInMeter14feb2024(5, 0);
            Assert.Equal(expected: 5, actual: length1.GetInMeter());

            LengthInCentimeter14feb2024 length2 = new LengthInCentimeter14feb2024(2, 0);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            LengthInMeter14feb2024 totalLength = length1 + length2;

            Assert.Equal(expected: 5.02, actual: totalLength.GetInMeter(), tolerance: 0.01);
        }

        [Fact]
        public void Test27()
        {
            LengthInCentimeter14feb2024 length1 = new LengthInCentimeter14feb2024(5, 0);
            Assert.Equal(expected: 0.05, actual: length1.GetInMeter());

            LengthInCentimeter14feb2024 length2 = new LengthInCentimeter14feb2024(2, 0);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            ILength14feb2024 totalLength = length1 + length2;

            Assert.Equal(expected: 0.07, actual: totalLength.GetInMeter(), tolerance: 0.01);
        }

        [Fact]
        public void Test28()
        {
            LengthInMeter14feb2024 length1 = new LengthInMeter14feb2024(5, 1);
            Assert.Equal(expected: 5, actual: length1.GetInMeter());

            LengthInCentimeter14feb2024 length2 = new LengthInCentimeter14feb2024(2, 0.1);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            ILength14feb2024 totalLength = length1 + length2;

            Assert.Equal(expected: 502, actual: totalLength.GetInCentimeter(), tolerance: 150);
        }


        [Fact]
        public void Test29()
        {
            LengthInMeter14feb2024 length1 = new LengthInMeter14feb2024(5, 0.1);
            Assert.Equal(expected: 5, actual: length1.GetInMeter());

            LengthInCentimeter14feb2024 length2 = new LengthInCentimeter14feb2024(2, 1);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            ILength14feb2024 totalLength = length1 + length2;

            Assert.Equal(expected: 5.02, actual: totalLength.GetInMeter(), tolerance: 0.15);
        }

        [Fact]
        public void Test30()
        {
            LengthInCentimeter14feb2024 length1 = new LengthInCentimeter14feb2024(5, 0.002);
            Assert.Equal(expected: 0.05, actual: length1.GetInMeter());

            LengthInCentimeter14feb2024 length2 = new LengthInCentimeter14feb2024(2, 0);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            ILength14feb2024 totalLength = length1 + length2;

            Assert.Equal(expected: 0.07, actual: totalLength.GetInMeter(), tolerance: 0.002);
        }

        [Fact]
        public void Test31()
        {
            double x = 1;
            var lengthInMeter = new LengthInMeter14feb2024(x, 0);
            var radius = HelperCircle.CalculateRadius(diameter: lengthInMeter);
            Assert.Equal(expected: 0.5, actual: radius.GetInMeter());

            var circumferenceOfCircle = HelperCircle.CalculateCircumference(diameter: lengthInMeter);
            Assert.Equal(expected: 3.141592653589793, actual: circumferenceOfCircle.GetInMeter(), tolerance: 0.00001);
        }

        [Fact]
        public void Test32()
        {
            double x = 0.35;
            var lengthInMeter = new LengthInMeter14feb2024(x, 0);
            var radius = HelperCircle.CalculateRadius(diameter: lengthInMeter);
            Assert.Equal(expected: 0.175, actual: radius.GetInMeter());

            var circumferenceOfCircle = HelperCircle.CalculateCircumference(diameter: lengthInMeter);
            Assert.Equal(expected: 1.0995574287564276, actual: circumferenceOfCircle.GetInMeter(), tolerance: 0.00001);
        }


        [Fact]
        public void Test33()
        {
            ILength14feb2024 length1 = new LengthInMeter14feb2024(5, 0);
            Assert.Equal(expected: 5, actual: length1.GetInMeter());

            LengthInCentimeter14feb2024 length2 = new LengthInCentimeter14feb2024(2, 0);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            LengthInMeter14feb2024 totalLength = LengthCalculation14feb2024.Add(length1, length2);

            Assert.Equal(expected: 502, actual: totalLength.GetInCentimeter(), tolerance: 1);
        }

        [Fact]
        public void Test34()
        {
            ILength14feb2024 length1 = new LengthInMeter14feb2024(5, 0);
            Assert.Equal(expected: 5, actual: length1.GetInMeter());

            LengthInCentimeter14feb2024 length2 = new LengthInCentimeter14feb2024(2, 0);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            LengthInMeter14feb2024 totalLength = LengthCalculation14feb2024.Add(length1, length2);

            Assert.Equal(expected: 5.02, actual: totalLength.GetInMeter(), tolerance: 0.01);
        }

        [Fact]
        public void Test35()
        {
            ILength14feb2024 length1 = new LengthInCentimeter14feb2024(5, 0);
            Assert.Equal(expected: 0.05, actual: length1.GetInMeter());

            ILength14feb2024 length2 = new LengthInCentimeter14feb2024(2, 0);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            LengthInMeter14feb2024 totalLength = LengthCalculation14feb2024.Add(length1, length2);

            Assert.Equal(expected: 0.07, actual: totalLength.GetInMeter(), tolerance: 0.01);
        }

        [Fact]
        public void Test36()
        {
            ILength14feb2024 length1 = new LengthInMeter14feb2024(5, 1);
            Assert.Equal(expected: 5, actual: length1.GetInMeter());

            LengthInCentimeter14feb2024 length2 = new LengthInCentimeter14feb2024(2, 0.1);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            LengthInMeter14feb2024 totalLength = LengthCalculation14feb2024.Add(length1, length2);

            Assert.Equal(expected: 502, actual: totalLength.GetInCentimeter(), tolerance: 150);
        }

        [Fact]
        public void Test37()
        {
            ILength14feb2024 length1 = new LengthInMeter14feb2024(5, 0.1);
            Assert.Equal(expected: 5, actual: length1.GetInMeter());

            LengthInCentimeter14feb2024 length2 = new LengthInCentimeter14feb2024(2, 1);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            LengthInMeter14feb2024 totalLength = LengthCalculation14feb2024.Add(length1, length2);

            Assert.Equal(expected: 5.02, actual: totalLength.GetInMeter(), tolerance: 0.15);
        }

        [Fact]
        public void Test38()
        {
            ILength14feb2024 length1 = new LengthInCentimeter14feb2024(5, 0.002);
            Assert.Equal(expected: 0.05, actual: length1.GetInMeter());

            ILength14feb2024 length2 = new LengthInCentimeter14feb2024(2, 0);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            LengthInMeter14feb2024 totalLength = LengthCalculation14feb2024.Add(length1, length2);

            Assert.Equal(expected: 0.07, actual: totalLength.GetInMeter(), tolerance: 0.002);
        }

        [Fact]
        public void Test39()
        {
            LengthInCentimeter14feb2024 length1 = new LengthInCentimeter14feb2024(5, 0.002);
            Assert.Equal(expected: 0.05, actual: length1.GetInMeter());

            LengthInCentimeter14feb2024 length2 = new LengthInCentimeter14feb2024(2, 0);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            LengthInMeter14feb2024 totalLength = length1 + length2;

            Assert.Equal(expected: 0.07, actual: totalLength.GetInMeter(), tolerance: 0.002);
        }

        [Fact]
        public void Test40()
        {
            LengthInMeter14feb2024 length1 = new LengthInMeter14feb2024(5, 0.002);
            Assert.Equal(expected: 5, actual: length1.GetInMeter(), tolerance: 0.01);

            LengthInMeter14feb2024 length2 = new LengthInMeter14feb2024(2, 0);
            Assert.Equal(expected: 200, actual: length2.GetInCentimeter());

            LengthInMeter14feb2024 totalLength = LengthCalculation14feb2024.Add(length1, length2);

            Assert.Equal(expected: 7, actual: totalLength.GetInMeter(), tolerance: 0.02);
        }

        [Fact]
        public void Test41()
        {
            LengthInMeter14feb2024 length1 = new LengthInMeter14feb2024(5, 0.002);
            Assert.Equal(expected: 5, actual: length1.GetInMeter());

            LengthInMeter14feb2024 length2 = new LengthInMeter14feb2024(2, 0);
            Assert.Equal(expected: 200, actual: length2.GetInCentimeter());

            LengthInMeter14feb2024 totalLength = LengthCalculation14feb2024.Substract(length1, length2);

            Assert.Equal(expected: 3, actual: totalLength.GetInMeter(), tolerance: 0.002);
        }

        [Fact]
        public void Test42()
        {
            LengthInMeter14feb2024 length1 = new LengthInMeter14feb2024(5, 0.002);
            Assert.Equal(expected: 5, actual: length1.GetInMeter());

            LengthInMeter14feb2024 length2 = new LengthInMeter14feb2024(2, 0);
            Assert.Equal(expected: 200, actual: length2.GetInCentimeter());

            LengthInMeter14feb2024 totalLength = length1 + length2;

            Assert.Equal(expected: 7, actual: totalLength.GetInMeter(), tolerance: 0.02);
        }

        [Fact]
        public void Test43()
        {
            LengthInMeter14feb2024 length1 = new LengthInMeter14feb2024(5, 0.002);
            Assert.Equal(expected: 5, actual: length1.GetInMeter());

            LengthInMeter14feb2024 length2 = new LengthInMeter14feb2024(2, 0);
            Assert.Equal(expected: 200, actual: length2.GetInCentimeter());

            LengthInMeter14feb2024 totalLength = length1 - length2;

            Assert.Equal(expected: 3, actual: totalLength.GetInMeter(), tolerance: 0.02);
        }

        [Fact]
        public void Test44()
        {
            var displacementInCentimeter = new LengthInCentimeter14feb2024(0.5, 0);
            var displacementInMeter = displacementInCentimeter.GetInMeter();
            Assert.Equal(expected: 0.005, actual: displacementInMeter);
        }

        [Fact]
        public void Test45()
        {
            var displacementInMeter = new LengthInMeter14feb2024(0.5, 0);
            var displacementInCentimeter = displacementInMeter.GetInCentimeter();
            Assert.Equal(expected: 50, actual: displacementInCentimeter);
        }

    }
}
