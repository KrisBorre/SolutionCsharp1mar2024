namespace LibraryPhysicalUnits13feb2024.Test
{
    public class UnitTestTime7feb2024
    {
        [Fact]
        public void Test1()
        {
            ITime time = new TimeInSeconds(5, 0);
            Assert.Equal(expected: 5, actual: time.GetInSeconds());
        }

        [Fact]
        public void Test2()
        {
            TimeInMilliseconds time = new TimeInMilliseconds(2, 0);
            Assert.Equal(expected: 2, actual: time.GetInMilliseconds());
        }

        [Fact]
        public void Test3()
        {
            TimeInMilliseconds time = new TimeInMilliseconds(2, 0);
            Assert.Equal(expected: 2, actual: time.GetInMilliseconds());
            Assert.Equal(expected: 0.002, actual: time.GetInSeconds());
        }

        [Fact]
        public void Test4()
        {
            ITime time = new TimeInSeconds(5, 0);
            Assert.Equal(expected: 5, actual: time.GetInSeconds());
            Assert.Equal(expected: 5000, actual: time.GetInMilliseconds());
        }

        [Fact]
        public void Test5()
        {
            ITime time = new TimeInSeconds(5, 1);
            Assert.Equal(expected: 5, actual: time.GetInSeconds(), tolerance: 1);
        }

        [Fact]
        public void Test6()
        {
            TimeInMilliseconds time = new TimeInMilliseconds(2, 0.1);
            Assert.Equal(expected: 2, actual: time.GetInMilliseconds(), tolerance: 0.1);
        }

        [Fact]
        public void Test7()
        {
            ITime time = new TimeInSeconds(5, 1);
            Assert.Equal(expected: 5, actual: time.GetInSeconds(), tolerance: 1);
            Assert.Equal(expected: 5000, actual: time.GetInMilliseconds(), tolerance: 1000);
        }

        [Fact]
        public void Test8()
        {
            ITime time1 = new TimeInSeconds(5, 0);
            Assert.Equal(expected: 5, actual: time1.GetInSeconds());

            TimeInMilliseconds time2 = new TimeInMilliseconds(2, 0);
            Assert.Equal(expected: 2, actual: time2.GetInMilliseconds());

            ITime totalTime = TimeCalculation.Add(time1, time2);

            Assert.Equal(expected: 5002, actual: totalTime.GetInMilliseconds(), tolerance: 1);
        }

        [Fact]
        public void Test9()
        {
            ITime time1 = new TimeInSeconds(5, 0);
            Assert.Equal(expected: 5, actual: time1.GetInSeconds());

            TimeInMilliseconds time2 = new TimeInMilliseconds(2, 0);
            Assert.Equal(expected: 2, actual: time2.GetInMilliseconds());

            ITime totalTime = TimeCalculation.Add(time1, time2);

            Assert.Equal(expected: 5.002, actual: totalTime.GetInSeconds(), tolerance: 0.001);
        }

        [Fact]
        public void Test10()
        {
            ITime time1 = new TimeInMilliseconds(5, 0);
            Assert.Equal(expected: 0.005, actual: time1.GetInSeconds());

            ITime time2 = new TimeInMilliseconds(2, 0);
            Assert.Equal(expected: 2, actual: time2.GetInMilliseconds());

            ITime totalTime = TimeCalculation.Add(time1, time2);

            Assert.Equal(expected: 0.007, actual: totalTime.GetInSeconds(), tolerance: 0.001);
        }

        [Fact]
        public void Test11()
        {
            ITime time1 = new TimeInSeconds(5, 1);
            Assert.Equal(expected: 5, actual: time1.GetInSeconds());

            TimeInMilliseconds time2 = new TimeInMilliseconds(2, 0.1);
            Assert.Equal(expected: 2, actual: time2.GetInMilliseconds());

            ITime totalTime = TimeCalculation.Add(time1, time2);

            Assert.Equal(expected: 5002, actual: totalTime.GetInMilliseconds(), tolerance: 1500);
        }

        [Fact]
        public void Test12()
        {
            ITime time1 = new TimeInSeconds(5, 0.1);
            Assert.Equal(expected: 5, actual: time1.GetInSeconds());

            TimeInMilliseconds time2 = new TimeInMilliseconds(2, 1);
            Assert.Equal(expected: 2, actual: time2.GetInMilliseconds());

            ITime totalTime = TimeCalculation.Add(time1, time2);

            Assert.Equal(expected: 5.002, actual: totalTime.GetInSeconds(), tolerance: 0.15);
        }

        [Fact]
        public void Test13()
        {
            ITime time1 = new TimeInMilliseconds(5, 0.002);
            Assert.Equal(expected: 0.005, actual: time1.GetInSeconds());

            ITime time2 = new TimeInMilliseconds(2, 0);
            Assert.Equal(expected: 2, actual: time2.GetInMilliseconds());

            ITime totalTime = TimeCalculation.Add(time1, time2);

            Assert.Equal(expected: 0.007, actual: totalTime.GetInSeconds(), tolerance: 0.002);
        }
    }
}
