using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.DelegatesEvents
{
    public delegate TResult AddDelegate<TOne, TTwo, TResult>(TOne one, TTwo two);
    public delegate int Operation(int a, int b);

    internal class BasicDelegate
    {
        public void TestDelegates()
        {
            //generic delegates
            Func<int, int, int> func = (first, second) => first + second;

            AddDelegate<int, int, int> addDelegate = (first, second) => first + second;

            int result = addDelegate(1, 2);

            Operation add = (first, second) => first + second; // mini method with parameters
            Operation subtract = (a,  b) => a - b;
            Operation multiply = Multiply;

            Console.WriteLine(result);
        }

        public int Multiply(int a, int b) 
        {
            return a + b;
        }
    }
}
