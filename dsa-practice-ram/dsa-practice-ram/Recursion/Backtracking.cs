namespace DsaPractice.Recursion
{
    internal class Backtracking
    {
        public void PermuteBySwapping()
        {
            /*                             ---               -> Level 0
             *                          /   |     \       
             *                        A--   B--    C--       -> Level 1: 3 choices for the first character
             *                      / \    / \    /  \
             *                    AB- AC- BA- BC- CA- CB-    -> Level 2: 2 choices for the second character
             *                    |   |   |   |   |   |
             *                   ABC ACB BAC BCA  CAB CBA    -> Level 3: 1 choice for the last character
             *                                               => n x n-1 x n-2...x1
             * 
             * Swapping technique:
             * 
                                Level 0:
                                         ABC
                                          ↓
                                Level 1 (Fix index 0):
                                     ┌────────────┬────────────┬────────────┐
                                     ↓            ↓            ↓
                                    ABC          BAC          CAB
                                     ↓            ↓            ↓
                                Level 2 (Fix index 1):
                                 ┌────┬────   ┌────┬────   ┌────┬────
                                 ↓    ↓       ↓    ↓       ↓    ↓
                                ABC  ACB     BAC  BCA     CAB  CBA
                                 ↑    ↑       ↑    ↑       ↑    ↑
                                 └────┘       └────┘       └────┘
                                  backtrack   backtrack   backtrack
                                     to          to          to
                                    ABC         BAC         CAB
                                     ↑           ↑           ↑
                                     └────── backtrack to original ABC ──────┘

                                Final Output:
                                [ABC] [ACB] [BAC] [BCA] [CAB] [CBA]
             * 
             *                     
             *                     
             *              Permute(index = 0)
                            ├── Swap(0, 0) → "ABC"   ← FORWARD
                            │   └── Permute(index = 1)
                            │       ├── Swap(1, 1) → "ABC"   ← FORWARD
                            │       │   └── Permute(index = 2) → Add "ABC"
                            │       └── Swap(1, 1) → "ABC"   ← BACKTRACK
                            │
                            │       ├── Swap(1, 2) → "ACB"   ← FORWARD
                            │       │   └── Permute(index = 2) → Add "ACB"
                            │       └── Swap(1, 2) → "ABC"   ← BACKTRACK
                            ├── Swap(0, 0) → "ABC"   ← BACKTRACK


                            ├── Swap(0, 1) → "BAC"   ← FORWARD
                            │   └── Permute(index = 1)
                            │       ├── Swap(1, 1) → "BAC"   ← FORWARD
                            │       │   └── Permute(index = 2) → Add "BAC"
                            │       └── Swap(1, 1) → "BAC"   ← BACKTRACK
                            │
                            │       ├── Swap(1, 2) → "BCA"   ← FORWARD
                            │       │   └── Permute(index = 2) → Add "BCA"
                            │       └── Swap(1, 2) → "BAC"   ← BACKTRACK
                            ├── Swap(0, 1) → "ABC"   ← BACKTRACK


                            ├── Swap(0, 2) → "CBA"   ← FORWARD
                            │   └── Permute(index = 1)
                            │       ├── Swap(1, 1) → "CBA"   ← FORWARD
                            │       │   └── Permute(index = 2) → Add "CBA"
                            │       └── Swap(1, 1) → "CBA"   ← BACKTRACK
                            │
                            │       ├── Swap(1, 2) → "CAB"   ← FORWARD
                            │       │   └── Permute(index = 2) → Add "CAB"
                            │       └── Swap(1, 2) → "CBA"   ← BACKTRACK
                            └── Swap(0, 2) → "ABC"   ← BACKTRACK
             * */

            List<string> result = new List<string>();

            PermuteBySwapping("ABC".ToArray(), 0, result);

            Console.WriteLine(string.Join(", ", result));
        }

        private void PermuteBySwapping(char[] chars, int index, List<string> result)
        {
            if (index == chars.Length - 1)
            {
                result.Add(new string(chars));
            }

            for (int i = index; i < chars.Length; i++)
            {
                Swap(chars, index, i);
                PermuteBySwapping(chars, index + 1, result);
                Swap(chars, index, i);
            }

            /* 
             * Swaps: ABC
             * 0, 0 -> ABC
             * 1, 1 -> ABC
             * Permute(chars, 2, result) => Add ABC
             * 1, 1 -> backtrack
             * 1, 2 -> ACB
             * Permute -> Add ACB
             * 1, 2 -> backtrack
             * 0, 0 -> backtrack
             * 
             * 0, 1 -> BAC        
             * 1, 1 -> BAC            * 
             *  
             * */
        }

        private void Swap(char[] chars, int i, int j)
        {
            if (i == j)
                return;

            char temp = chars[i];
            chars[i] = chars[j];
            chars[j] = temp;
        }
    }
}
