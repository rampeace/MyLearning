using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Trees
{
    internal class DFS
    {
        public void PreOrderTraversal(TreeNode<string> node)
        {
            /*
             *                        A
                                     / \
                                    B   C
                                   / \
                                  D   E
             * 
             *  Always to in counter clockwise direction around the tree
             *  
             *  Print when you visit the node for the first time you visit: A B D E C 
             * 
             * */

            if (node == null)
                return;

            Console.Write(node.Value + " ");
            PreOrderTraversal(node.Left);
            PreOrderTraversal(node.Right);
        }

        public void InOrderTraversal(TreeNode<string> node)
        {
            /*
             * 
                              A
                             / \
                            B   C
                           / \
                          D   E
                      
             * Print when you visit the node for the second time you visit: D B E A C
             * */
            if (node == null)
                return;

            InOrderTraversal(node.Left);
            Console.Write(node.Value + " ");
            InOrderTraversal(node.Right);
        }

        public void PostOrderTraversal(TreeNode<string> node)
        {
            /*
                                  A
                                 / \
                                B   C
                               / \
                              D   E
             * 
             * Print when you visit the node for the third time you visit: D E B CA 
             * */
            if (node == null)
                return;

            PostOrderTraversal(node.Left);
            PostOrderTraversal(node.Right);
            Console.Write(node.Value + " ");
        }

        public void Print()
        {
            // Tree:
            //        A
            //       / \
            //      B   C
            //     / \
            //    D   E
            /*
             * Output:
             *  Preorder Traversal:
                A B D E C
                Inorder Traversal:
                D B E A C
                Postorder Traversal:
                D E B C A
             * */
            TreeNode<string> root =
                new TreeNode<string>("A",
                new TreeNode<string>("B",
                new TreeNode<string>("D"),
                new TreeNode<string>("E")),
                new TreeNode<string>("C"));

            Console.WriteLine("Preorder Traversal: ");
            PreOrderTraversal(root);
            Console.WriteLine();

            Console.WriteLine("Inorder Traversal: ");
            InOrderTraversal(root);
            Console.WriteLine();

            Console.WriteLine("Postorder Traversal: ");
            PostOrderTraversal(root);
        }

        public void IterativePreOrderTraversal()
        {
            /*
             * Root -> Left -> Right
             * 
             *                   A
             *                 /   \
             *                B     C
             *              /  \   /  \
             *             D   E   F   G
             *  A B D E C F G
             * 
             *   Stack:
             *   
             *     Pop  Push 
             *     A ->  C B
             *     B ->  E D
             *     D ->  null null
             *     E ->  null null
             *     C ->  G F 
             *     F ->  null null
             *     G ->  null null
             */

            TreeNode<string> root =
                new TreeNode<string>("A",
                new TreeNode<string>("B",
                new TreeNode<string>("D"),
                new TreeNode<string>("E")),
                new TreeNode<string>("C",
                new TreeNode<string>("F"),
                new TreeNode<string>("G")));

            Stack<TreeNode<string>> stack = new();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                Console.Write(current.Value + " ");

                if (current.Right != null)
                    stack.Push(current.Right);

                if (current.Left != null)
                    stack.Push(current.Left);
            }
        }

        public void IterativeInOrderTraversal()
        {
            /*
             *                   A
             *                 /   \
             *                B     C
             *              /  \   /  \
             *             D   E   F   G
             * A B D E C F G
             * 
             *   Stack:
             *   
             *    Pop    Push          Current
             *     - ->  A B D     ->    root 
             *     D ->   
             *     B ->  E D
             *     D ->  null null
             *     E ->  null null
             *     C ->  G F 
             *     F ->  null null
             *     G ->  null null
             */

            TreeNode<string> root =
                new TreeNode<string>("A",
                new TreeNode<string>("B",
                new TreeNode<string>("D"),
                new TreeNode<string>("E")),
                new TreeNode<string>("C",
                new TreeNode<string>("F"),
                new TreeNode<string>("G")));

            Stack<TreeNode<string>> stack = new();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                Console.Write(current.Value + " ");

                if (current.Right != null)
                    stack.Push(current.Right);

                if (current.Left != null)
                    stack.Push(current.Left);
            }
        }
    }
}
