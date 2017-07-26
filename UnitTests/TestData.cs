// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections;
using System.Collections.Generic;

namespace UnitTests
{
    internal class TestData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
        new object[]{9, 12, 1, 3 },
        new object[]{12, 9,  1, 3 },
        new object[]{20, 100,  1, 2, 4, 5, 10, 20 },
        new object[]{100, 20,  1, 2, 4, 5, 10, 20 },
        new object[]{13, 17,  1 },
        new object[]{17, 13,  1 },
        new object[]{5, 7,  1 },
        new object[]{7, 5,  1 },
        new object[]{50, 70,  1, 2, 5, 10 },
        new object[]{70, 50,  1, 2, 5, 10 }
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}