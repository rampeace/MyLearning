using CSharpPractice.DelegatesEvents;
using CSharpPractice.DesignPatterns;
using CSharpPractice.Linq;
using CSharpPractice.Multithreading;
using System.Formats.Asn1;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CSharpPractice
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            PauseThread pauseThread = new();

            Task task = pauseThread.RunTask();

            await Task.Delay(3000);

            pauseThread.Pause();

            await Task.Delay(3000);

            pauseThread.Resume();

            await task;

            Console.ReadKey();
        }
    } 
}
