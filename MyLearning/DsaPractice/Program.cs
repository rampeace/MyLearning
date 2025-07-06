using DsaPractice.Arrays;
using DsaPractice.Arrays._2D;
using DsaPractice.BinarySearch;
using DsaPractice.BitManipulation;
using DsaPractice.Graph;
using DsaPractice.Hashing;
using DsaPractice.LinkedList;
using DsaPractice.Maths;
using DsaPractice.MinHeap;
using DsaPractice.Queue;
using DsaPractice.Recursion;
using DsaPractice.Trees;
using System.Linq.Expressions;
using System.Net;
using System.Security.Claims;

namespace DsaPractice
{
    internal class Program
    {
        static void Main()
        {

            BackTrack(0);

            Console.ReadKey();
        }

        private static void BackTrack(int n)
        {
            if (n == 10)
                return;

            n++;

            BackTrack(n);

            Console.WriteLine(n);
        }
    }
}
