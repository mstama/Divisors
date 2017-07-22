using Divisors.Services;
using Xunit;

namespace UnitTests
{
    public class BruteSqrtTests
    {
        private const string _category = "BruteSqrt";

        private readonly BruteSqrt _target = new BruteSqrt();

        [Theory]
        [Trait("Category", _category)]
        [ClassData(typeof(TestData))]
        public void TestCalculate(int a, int b, params int[] divs)
        {
            var output = _target.Calculate(a, b);

            Assert.Equal<int>(divs.Length, output.Count);

            foreach (var div in divs)
            {
                Assert.Contains(output, item => item == div);
            }
        }
    }
}