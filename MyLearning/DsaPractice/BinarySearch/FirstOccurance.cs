using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.BinarySearch
{
    internal class FirstOccurance
    {
        /*
         *   0  1  2  3  4  5  6   7
         * [ 2, 4, 6, 8, 8, 8, 11, 13 ]
         *                      ^      ^
         * 1) x = 10 => returns 11 as lower bound => Check if nums[lowerBound] == target
         * 2) x = 14 => returns 8 as lower bound index => Check lowerbound(x) != n
         * 
         * */
        LowerBound lowerBound = new LowerBound();
        //int first =

    }
}
