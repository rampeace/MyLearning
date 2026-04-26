using CSharpPractice.DelegatesEvents;
using CSharpPractice.DesignPatterns;
using CSharpPractice.Linq;
using CSharpPractice.Multithreading;
using System.Formats.Asn1;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CSharpPractice
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Func<int, int, int> add = (x, y) => x + y;

            int result = add(2, 4);


            //PauseThread pauseThread = new();

            //Task task = pauseThread.RunTask();

            //await Task.Delay(3000);

            //pauseThread.Pause();

            //await Task.Delay(3000);

            //pauseThread.Resume();

            //await task;

            Console.ReadKey();
        }

        public delegate TResult Add<TOne, TTwo, TResult>(TOne a, TTwo b);

        public class MyClass
        {

        }
    }
}
