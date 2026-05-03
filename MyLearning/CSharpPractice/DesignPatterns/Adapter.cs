using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.DesignPatterns
{
    public interface IPrinter
    {
        void Print(string text);
    }

    public class LegacyPrinter
    {
        public void PrintText(string text) { }
    }

    public class LegacyPrinterAdapter(LegacyPrinter printer) : IPrinter
    {
        LegacyPrinter _printer = printer;

        public void Print(string text)
        {
            _printer.PrintText(text);
        }
    }
}
