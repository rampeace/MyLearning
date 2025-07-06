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

            TreeNode<string> d = new TreeNode<string>("D");
            TreeNode<string> e = new TreeNode<string>("E");

            TreeNode<string> f = new TreeNode<string>("F");
            TreeNode<string> g = new TreeNode<string>("G");

            TreeNode<string> b = new TreeNode<string>("B", d, e);
            TreeNode<string> c = new TreeNode<string>("B", f, g);

            TreeNode<string> a = new TreeNode<string>("A", b, c);

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
