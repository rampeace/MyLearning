using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Trees
{
    internal class PrintFileNames
    {
        public void PrintFileNamesBFS(string root)
        {
            Queue<string> queue = new();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                string path = queue.Dequeue();

                Console.WriteLine(path);

                foreach (var file in Directory.GetFiles(path))
                {
                    Console.WriteLine($"   -{Path.GetFileName(file)}");
                }

                foreach (var directory in Directory.GetDirectories(path))
                {
                    queue.Enqueue(directory);
                }
            }
        }

        public void PrintFileNamesDFS(string root, int depth = 0)
        {
            string indent = new string(' ', depth * 2);

            Console.WriteLine($"{indent}{root}");

            foreach (var file in Directory.GetFiles(root))
            {
                Console.WriteLine($"{indent}   -{Path.GetFileName(file)}");
            }
            foreach (var directory in Directory.GetDirectories(root))
            {
                PrintFileNamesDFS(directory, depth + 1);
            }
        }

        public void Test()
        {
            //PrintAllFileNames("C:\\Projects\\DSA Practice Git Repo");
            PrintFileNamesDFS("C:\\Projects\\DSA Practice Git Repo");
        }
    }
}
