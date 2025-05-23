using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Linq
{
    internal class GroupAnagrams
    {
        public IList<IList<string>> GetGroupedAnagrams(string[] strs)
        {
            return strs
             .GroupBy(s => new string(s.OrderBy(c => c).ToArray()))
             .Select(g => (IList<string>)[.. g])
             .ToList();
        }
    }
}
