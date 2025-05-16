using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.SOLID
{
    internal class LiskovSubstitutionPrinciple
    {
        /*
        The Liskov Substitution Principle (LSP) states that subtypes must be substitutable 
        for their base types without altering the correctness of the program. 
        */

        // Problem
        public class Bird
        {
            public virtual void Fly()
            {
                Console.WriteLine("Birds can fly");
            }
        }

        public class Penguin : Bird
        {
            public override void Fly()
            {
                throw new InvalidOperationException("Penguin can't fly");
            }
        }

        // Fix
        public abstract class Bird2
        {
            public abstract void Move();
        }

        public class FlyingBird : Bird2
        {
            public override void Move()
            {
                Console.WriteLine("Bird is flying");
            }
        }

        public class Penguin2 : Bird2
        {
            public override void Move()
            {
                Console.WriteLine("Penguin is swimming");
            }
        }

        // Another example
        public class Employee
        {
            public virtual void Bonus()
            {
                Console.WriteLine(20);
            }
        }

        public class RegularEmployee : Employee
        {
            public override void Bonus()
            {
                Console.WriteLine(30);
            }
        }

        public class ContractualEmployee : Employee
        {
            public override void Bonus()
            {
                throw new InvalidOperationException("Contract employees doesn't have bonus");
            }
        }

        // Fix
        public interface IBonus
        {
            void Bonus();
        }

        public class Employee2
        {
            public string Name { get; set; }
        }

        public class ContractualEmployee2 : Employee2
        {

        }

        public class RegularEmployee2 : Employee2, IBonus
        {
            public void Bonus()
            {
                Console.WriteLine(30);
            }
        }
    }
}
