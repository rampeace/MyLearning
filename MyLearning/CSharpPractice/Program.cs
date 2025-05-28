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
            int[] array = [1, 2, 3, 5, 4, 5];

            List<int> list = [];

            array.ForEach(x => list.Add(x));

            Console.ReadKey();
        }
    }
}
