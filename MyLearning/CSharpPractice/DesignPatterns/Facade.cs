using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.DesignPatterns
{
    /*
     * Facade does not do the complex work. Facade hides and coordinates the complex work.
     * 
     * 
     */
    public class BadPrintFacade
    {
        public void Print(string document)
        {
            // Formatting logic
            string formatted = document.Trim().ToUpper();

            // Validation logic
            if (string.IsNullOrWhiteSpace(formatted))
                throw new Exception("Document is empty");

            // Spooling logic
            Console.WriteLine("Adding document to print queue...");

            // Hardware logic
            Console.WriteLine("Checking ink level...");
            Console.WriteLine("Sending raw commands to printer...");

            // Notification logic
            Console.WriteLine("Print completed");
        }
    }


    public class DocumentFormatter
    {
        public string Format(string document)
        {
            Console.WriteLine("Formatting document...");
            return document.Trim();
        }
    }

    public class PrintValidator
    {
        public void Validate(string document)
        {
            Console.WriteLine("Validating document...");

            if (string.IsNullOrWhiteSpace(document))
                throw new Exception("Document is empty");
        }
    }

    public class PrintSpooler
    {
        public void AddToQueue(string document)
        {
            Console.WriteLine("Adding document to print queue...");
        }
    }

    public class PrinterDriver
    {
        public void Print()
        {
            Console.WriteLine("Sending document to printer hardware...");
        }
    }

    public class PrintNotificationService
    {
        public void NotifySuccess()
        {
            Console.WriteLine("Print completed successfully");
        }
    }

    // Facade
    public class PrintFacade
    {
        private readonly DocumentFormatter _formatter = new();
        private readonly PrintValidator _validator = new();
        private readonly PrintSpooler _spooler = new();
        private readonly PrinterDriver _driver = new();
        private readonly PrintNotificationService _notification = new();

        public void Print(string document)
        {
            string formattedDocument = _formatter.Format(document);
            _validator.Validate(formattedDocument);
            _spooler.AddToQueue(formattedDocument);
            _driver.Print();
            _notification.NotifySuccess();
        }
    }

    public class FacadeTest
    {
        public static void Test()
        {
            var printer = new PrintFacade();

            printer.Print("   Monthly report   ");
        }
    }
}
