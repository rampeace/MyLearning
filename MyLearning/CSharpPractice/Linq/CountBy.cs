using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice.Linq
{
    internal class CountBy
    {
        public void Count()
        {
            var words = new List<string> { "apple", "banana", "avocado", "blueberry", "cherry" };

            var result = words
                .CountBy(word => word.First())
                .Select(kvp => new
                {
                    Char = kvp.Key,
                    Count = kvp.Value
                });
        }
    }
}
