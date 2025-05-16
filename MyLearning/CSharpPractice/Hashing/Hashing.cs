using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Hashing
{
    internal class Hashing
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public override int GetHashCode()
            {
                // Use hash code combination pattern
                int hash = 17; // initial seed
                hash = hash * 23 + (Name?.GetHashCode() ?? 0); // 23: Prime multiplier to spread hash values
                hash = hash * 23 + Age.GetHashCode();
                return hash;
            }

            public override bool Equals(object obj)
            {
                if (obj is Person other)
                    return this.Name == other.Name && this.Age == other.Age;
                return false;
            }
        }

        public class Person2
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public override int GetHashCode()
            {
                return HashCode.Combine(Name, Age);
            }

            public override bool Equals(object obj)
            {
                if (obj is Person other)
                    return this.Name == other.Name && this.Age == other.Age;
                return false;
            }
        }
    }
}
