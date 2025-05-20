using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Trees
{
    internal class BFS
    {
        public void LevelOrderTraversal()
        {
            /*
             *                   A
             *                 /   \
             *                B     C
             *              /  \   /  \
             *             D   E   F   G
             * ABCDEFG
             * 
             */

            TreeNode<string> root =
                new TreeNode<string>("A", 
                new TreeNode<string>("B",
                new TreeNode<string>("D"), 
                new TreeNode<string>("E")), 
                new TreeNode<string>("C", 
                new TreeNode<string>("F"),
                new TreeNode<string>("G")));

            Queue<TreeNode<string>> queue = new();
            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                var current = queue.Dequeue();
                Console.Write(current.Value + " ");

                if (current.Left != null) 
                    queue.Enqueue(current.Left);

                if (current.Right != null)
                    queue.Enqueue(current.Right);
            }
        }
    }
}
