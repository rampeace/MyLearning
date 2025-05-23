using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Hashing
{
    internal class EqualPairs
    {
        public int EqualPairsOptimised(int[][] grid)
        {
            int n = grid.Length;
            var rowCount = new Dictionary<string, int>();
            int count = 0;

            rowCount = grid
                .GroupBy(array => string.Concat(array))
                .ToDictionary(g => g.Key, g => g.Count());

            // Compare column patterns with stored rows
            for (int i = 0; i < n; i++)
            {
                int[] col = new int[n];
                for (int j = 0; j < n; j++)
                {
                    col[j] = grid[j][i];
                }
                string colKey = string.Concat(col);

                if (rowCount.ContainsKey(colKey))
                {
                    count += rowCount[colKey];
                }
            }

            return count;
        }
    }
}
