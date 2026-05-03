using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.DesignPatterns
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    namespace CSharpPractice.DesignPatterns
    {
        public enum FolderType
        {
            Normal,
            Hidden,
            Shared
        }

        // =========================
        // 1. Element Abstraction
        // =========================
        public interface INode
        {
            string Name { get; }

            // Visitor entry point
            void Accept(INodeVisitor visitor);
        }

        // =========================
        // 2. Visitor Abstraction
        // =========================
        public interface INodeVisitor
        {
            void Visit(FileNode file);
            void Visit(ShortcutNode shortcut);
            void Visit(FolderNode folder);
        }

        // =========================
        // 3. Leaf Node: File
        // =========================
        public class FileNode : INode
        {
            public string Name { get; }
            public double Size { get; }

            public FileNode(string name, double size)
            {
                Name = name;
                Size = size;
            }

            public void Accept(INodeVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        // =========================
        // 4. Leaf Node: Shortcut
        // =========================
        public class ShortcutNode : INode
        {
            public string Name { get; }
            public INode? Target { get; }

            public ShortcutNode(string name, INode? target = null)
            {
                Name = name;
                Target = target;
            }

            public void Accept(INodeVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        // =========================
        // 5. Composite Node: Folder
        // =========================
        public class FolderNode : INode
        {
            private readonly List<INode> _children = new();

            public string Name { get; }
            public FolderType FolderType { get; set; }

            public IReadOnlyList<INode> Children => _children;

            public FolderNode(string name, FolderType folderType = FolderType.Normal)
            {
                Name = name;
                FolderType = folderType;
            }

            public void Add(INode node)
            {
                if (node == null)
                    throw new ArgumentNullException(nameof(node));

                _children.Add(node);
            }

            public void Accept(INodeVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        // =========================
        // 6. Visitor 1: Calculate Size
        // =========================
        public class SizeVisitor : INodeVisitor
        {
            public double TotalSize { get; private set; }

            public void Visit(FileNode file)
            {
                TotalSize += file.Size;
            }

            public void Visit(ShortcutNode shortcut)
            {
                // Design choice:
                // Shortcut itself occupies 0 size here.
                // If you want target size, use:
                // shortcut.Target?.Accept(this);
                TotalSize += 0;
            }

            public void Visit(FolderNode folder)
            {
                foreach (var child in folder.Children)
                {
                    child.Accept(this);
                }
            }
        }

        // =========================
        // 7. Visitor 2: Print Tree
        // =========================
        public class PrintVisitor : INodeVisitor
        {
            private int _depth;

            public void Visit(FileNode file)
            {
                PrintIndent();
                Console.WriteLine($"File: {file.Name}, Size: {file.Size}");
            }

            public void Visit(ShortcutNode shortcut)
            {
                PrintIndent();
                Console.WriteLine($"Shortcut: {shortcut.Name}");
            }

            public void Visit(FolderNode folder)
            {
                PrintIndent();
                Console.WriteLine($"Folder: {folder.Name}, Type: {folder.FolderType}");

                _depth++;

                foreach (var child in folder.Children)
                {
                    child.Accept(this);
                }

                _depth--;
            }

            private void PrintIndent()
            {
                Console.Write(new string(' ', _depth * 4));
            }
        }

        // =========================
        // 8. Visitor 3: Count Files
        // =========================
        public class FileCountVisitor : INodeVisitor
        {
            public int FileCount { get; private set; }

            public void Visit(FileNode file)
            {
                FileCount++;
            }

            public void Visit(ShortcutNode shortcut)
            {
                // Shortcut is not counted as real file here.
            }

            public void Visit(FolderNode folder)
            {
                foreach (var child in folder.Children)
                {
                    child.Accept(this);
                }
            }
        }

        // =========================
        // 9. Demo Usage
        // =========================
        public static class VisitorPatternDemo
        {
            public static void Run()
            {
                var root = new FolderNode("Root");

                root.Add(new FileNode("Resume.docx", 120));
                root.Add(new FileNode("Photo.png", 500));

                var hiddenFolder = new FolderNode("System", FolderType.Hidden);
                hiddenFolder.Add(new FileNode("config.sys", 50));
                hiddenFolder.Add(new ShortcutNode("config-shortcut"));

                var sharedFolder = new FolderNode("Shared", FolderType.Shared);
                sharedFolder.Add(new FileNode("TeamPlan.xlsx", 300));

                root.Add(hiddenFolder);
                root.Add(sharedFolder);

                // Visitor 1: Print tree
                var printVisitor = new PrintVisitor();
                root.Accept(printVisitor);

                Console.WriteLine();

                // Visitor 2: Calculate size
                var sizeVisitor = new SizeVisitor();
                root.Accept(sizeVisitor);
                Console.WriteLine($"Total size: {sizeVisitor.TotalSize}");

                // Visitor 3: Count files
                var fileCountVisitor = new FileCountVisitor();
                root.Accept(fileCountVisitor);
                Console.WriteLine($"File count: {fileCountVisitor.FileCount}");
            }
        }
    }
}
