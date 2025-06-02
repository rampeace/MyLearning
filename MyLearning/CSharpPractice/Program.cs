using CSharpPractice.DelegatesEvents;
using CSharpPractice.DesignPatterns;
using CSharpPractice.Linq;
using CSharpPractice.Multithreading;
using System.Formats.Asn1;
using System.Runtime.CompilerServices;

namespace CSharpPractice
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            new LeftJoin().TryLeftJoin();

            Console.ReadKey();
        }
    }
}
