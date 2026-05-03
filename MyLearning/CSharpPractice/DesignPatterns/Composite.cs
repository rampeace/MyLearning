using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSharpPractice.DesignPatterns
{
    public enum FolderType
    {
        Normal,
        Hidden,
        Shared
    }
   public interface INode
    {
        double GetSize();
    }

    public class FileNode(double size) : INode
    {
        private double _size = size;
        public double GetSize() => _size;
    }

    public class ShortcutNode : INode
    {
        public double GetSize() => 0;
    }

    // Don’t create new node types unless behavior differs
    public class FolderNode : INode
    {
        public List<INode> Children { get; } = new();

        public FolderType FolderType { get; set; }

        public virtual double GetSize()
        {
            return Children.Sum(node => node.GetSize());
        }
    }
}
