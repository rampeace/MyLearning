using System;
using System.Collections.Generic;
using System.Text;

namespace DsaPractice.Trees
{
    public class LCA
    {
        public class Node(char value, Node left = null, Node right = null)
        {
            public char Value = value;

            public Node Left = left;

            public Node Right = right;
        }

        public Node FindLCA(Node root, char a, char b)
        {
            if (root == null) 
                return null;

            if (root.Value == a || root.Value == b) 
                return root;

            Node left = FindLCA(root.Left, a, b);
            Node right = FindLCA(root.Right, a, b);

            if (left != null && right != null)
                return root;

            return left ?? right;
        }
    }
}
