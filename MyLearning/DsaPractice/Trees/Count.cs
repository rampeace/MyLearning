using System;
using System.Collections.Generic;
using System.Text;

namespace DsaPractice.Trees
{
    internal class Count
    {
        int CountNodes(TreeNode<string> node)
        {
            if (node == null) return 0;

            return 1 + CountNodes(node.Left) + CountNodes(node.Right);
        }
    }
}
