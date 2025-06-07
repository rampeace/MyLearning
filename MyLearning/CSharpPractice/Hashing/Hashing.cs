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
                /* The goal:

                -Every bit of your 32-bit hash should be influenced by every bit of your key.
                -That way, the hash code is well distributed—meaning keys are spread across the dictionary’s slots with minimal clustering.
                -Result: Faster lookups, inserts, and removals—because you have fewer collisions.
                */
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
