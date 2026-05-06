using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.DesignPatterns
{
   // keep the same interface, but put a controlled object in front of the real object.
    public interface IReport
    {
        void Display();
    }

    public class RealReport : IReport
    {
        private readonly string _fileName;

        public RealReport(string fileName)
        {
            _fileName = fileName;
            Console.WriteLine($"Loading heavy report from {_fileName}...");
        }

        public void Display()
        {
            Console.WriteLine($"Displaying report: {_fileName}");
        }
    }

    public class ReportProxy : IReport
    {
        private readonly string _fileName;
        private RealReport? _realReport;

        public ReportProxy(string fileName)
        {
            _fileName = fileName;
        }

        public void Display()
        {
            if (_realReport == null)
            {
                _realReport = new RealReport(_fileName);
            }

            _realReport.Display();
        }
    }

    public class ProxyTest
    {
        public static void Test()
        {
            IReport report = new ReportProxy("SalesReport.pdf");

            Console.WriteLine("Proxy object created.");
            Console.WriteLine("Real report not loaded yet.");

            report.Display();
            report.Display();
        }
    }
}
