using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Recursion
{
    internal class Backtracking
    {
        public void Test()
        {
            int n = 0;

            BackTrack(n);

            Console.WriteLine("\n\n");

            BackTrackByRef(ref n);
        }

        // BackTrack(int n) uses a value copy, so each recursive call works with an independent value.
        private void BackTrack(int n)
        {
            if (n == 10)
                return;

            n++;

            BackTrack(n);

            Console.WriteLine(n);
        }

        // BackTrack(ref int n) uses a reference, so each recursive call shares and modifies the same variable.
        private void BackTrackByRef(ref int n)
        {
            if (n == 10)
                return;

            n++;

            BackTrackByRef(ref n);

            Console.WriteLine(n);
        }
    }
}
