using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.DesignPatterns
{
    // Prototype is about avoiding expensive or complex object creation, not reducing memory footprint.
    public interface IPrototype<T>
    {
        T Clone();
    }
    public class Metadata
    {
        public string Author { get; set; }
    }
    public class Document : IPrototype<Document>
    {
        public string Title { get; set; }
        public string Content { get; set; }

        // Nested object (to show deep copy)
        public Metadata Meta { get; set; }

        public Document Clone()
        {
            // Deep copy
            return new Document
            {
                Title = this.Title,
                Content = this.Content,
                Meta = new Metadata
                {
                    Author = this.Meta.Author
                }
            };
        }

        public void Print()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Content: {Content}");
            Console.WriteLine($"Author: {Meta.Author}");
            Console.WriteLine("-----------------------");
        }
    }

    class PrototypeTest
    {
        public static void Test()
        {
            // Create a template (prototype)
            var template = new Document
            {
                Title = "Template",
                Content = "Default content...",
                Meta = new Metadata { Author = "Admin" }
            };

            // Clone it
            var doc1 = template.Clone();
            doc1.Title = "Invoice";
            doc1.Content = "Invoice content";

            var doc2 = template.Clone();
            doc2.Title = "Report";
            doc2.Content = "Report content";

            template.Print();
            doc1.Print();
            doc2.Print();
        }
    }
}
