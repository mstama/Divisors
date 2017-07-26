// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Divisors.Services;
using Xunit;

namespace UnitTests
{
    public class BruteTests
    {
        private const string _category = "Brute";

        private readonly Brute _target = new Brute();

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