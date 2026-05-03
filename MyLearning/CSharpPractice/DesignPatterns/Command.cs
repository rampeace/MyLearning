using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.DesignPatterns
{
    using System;

    // 1. Command interface
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    // 2. Receiver (actual work)
    public class Light
    {
        public void On() => Console.WriteLine("Light ON");
        public void Off() => Console.WriteLine("Light OFF");
    }

    // 3. Concrete Command
    public class LightOnCommand : ICommand
    {
        private readonly Light _light;

        public LightOnCommand(Light light)
        {
            _light = light;
        }

        public void Execute() => _light.On();
        public void Undo() => _light.Off();
    }

    // 4. Usage (Invoker is just the caller here)
    public class Program
    {
        public static void Main()
        {
            var light = new Light();
            ICommand cmd = new LightOnCommand(light);

            cmd.Execute(); // Light ON
            cmd.Undo();    // Light OFF
        }
    }

    /*
    INTERVIEW NOTE:

    - ICommand = Command abstraction
    - LightOnCommand = Concrete command (wraps the action)
    - Light = Receiver (real logic)

    - Key idea:
      We turned "turn on light" into an object → can execute, undo, store, etc.

    ------------------------------------------------------------

    WPF NOTE:

    - WPF ICommand is a simplified Command pattern:
        void Execute(object parameter)
        bool CanExecute(object parameter)

    - Used mainly for:
      ✔ UI decoupling (View ↔ ViewModel)
      ✔ Enabling/disabling controls via CanExecute

    - Unlike full Command pattern:
      ❌ No built-in undo/redo/history
    */
}
