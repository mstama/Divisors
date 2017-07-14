using Divisors.Services;
using System;
using Xunit;

namespace UnitTests
{
    public class BruteTests
    {
        private const string _category = "Brute";

        private readonly Brute _target = new Brute(new ProgressEmpty());

        [Fact]
        [Trait("Category", _category)]
        public void TestCalculate()
        {
            var output = _target.Calculate(9, 12);
            Assert.Contains(output, item => item == 1);
            Assert.Contains(output, item => item == 3);
        }

        [Fact]
        [Trait("Category", _category)]
        public void TestCalculate2()
        {
            var output = _target.Calculate(12, 9);
            Assert.Contains(output, item => item == 1);
            Assert.Contains(output, item => item == 3);
        }

        [Fact]
        [Trait("Category", _category)]
        public void TestCalculate3()
        {
            var output = _target.Calculate(20, 100);
            Assert.Contains(output, item => item == 1);
            Assert.Contains(output, item => item == 2);
            Assert.Contains(output, item => item == 4);
            Assert.Contains(output, item => item == 5);
            Assert.Contains(output, item => item == 10);
            Assert.Contains(output, item => item == 20);
        }

        [Fact]
        [Trait("Category", _category)]
        public void TestCalculate4()
        {
            var output = _target.Calculate(100, 20);
            Assert.Contains(output, item => item == 1);
            Assert.Contains(output, item => item == 2);
            Assert.Contains(output, item => item == 4);
            Assert.Contains(output, item => item == 5);
            Assert.Contains(output, item => item == 10);
            Assert.Contains(output, item => item == 20);
        }
    }
}
