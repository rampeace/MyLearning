using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.DesignPatterns
{

    /*
     * Template Method = a base class defines the fixed algorithm (skeleton)
        and lets subclasses customize specific steps. 

       virtual method alone is not Template Method. 
        The non-virtual method that controls the fixed sequence is the Template Method. The virtual methods are hooks used inside it.
     */

    // Example 1
    public class Control
    {
        public void ApplyTemplate()
        {
            // Create Border and basic control outline

            OnApplyTemplate();

            // Finalize the looks
        }

        protected virtual void OnApplyTemplate()
        {

        }
    }

    public class Button : Control
    {
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
    }

    // Example 2
    public abstract class ReportGenerator
    {
        public void ProcessReport()
        {
            object o = FetchData();

            ProcessData(o);

            GenerateReport();
        }

        private object FetchData() => 1;

        protected abstract void ProcessData(object data);

        private void GenerateReport() { }
    }
}
