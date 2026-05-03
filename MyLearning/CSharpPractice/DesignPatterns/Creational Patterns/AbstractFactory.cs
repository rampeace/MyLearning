using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.DesignPatterns
{
    /*
     * Factory → creates one object
       Abstract Factory → creates a family of objects
     * 
     */

    // =========================
    // 1. Abstract Products
    // =========================
    public interface IFileSystem
    {
        void ReadFile(string path);
    }

    public interface IProcessManager
    {
        void StartProcess(string name);
    }

    // =========================
    // 2. Windows Products
    // =========================
    public class WindowsFileSystem : IFileSystem
    {
        public void ReadFile(string path)
        {
            Console.WriteLine($"Windows reading file: {path}");
        }
    }

    public class WindowsProcessManager : IProcessManager
    {
        public void StartProcess(string name)
        {
            Console.WriteLine($"Windows starting process: {name}");
        }
    }

    // =========================
    // 3. Linux Products
    // =========================
    public class LinuxFileSystem : IFileSystem
    {
        public void ReadFile(string path)
        {
            Console.WriteLine($"Linux reading file: {path}");
        }
    }

    public class LinuxProcessManager : IProcessManager
    {
        public void StartProcess(string name)
        {
            Console.WriteLine($"Linux starting process: {name}");
        }
    }

    // =========================
    // 4. Abstract Factory
    // =========================
    public interface IOSFactory
    {
        IFileSystem CreateFileSystem();
        IProcessManager CreateProcessManager();
    }

    // =========================
    // 5. Concrete Factories
    // =========================
    public class WindowsFactory : IOSFactory
    {
        public IFileSystem CreateFileSystem()
        {
            return new WindowsFileSystem();
        }

        public IProcessManager CreateProcessManager()
        {
            return new WindowsProcessManager();
        }
    }

    public class LinuxFactory : IOSFactory
    {
        public IFileSystem CreateFileSystem()
        {
            return new LinuxFileSystem();
        }

        public IProcessManager CreateProcessManager()
        {
            return new LinuxProcessManager();
        }
    }

    // =========================
    // 6. Client
    // =========================
    public class Application
    {
        private readonly IFileSystem _fileSystem;
        private readonly IProcessManager _processManager;

        public Application(IOSFactory factory)
        {
            _fileSystem = factory.CreateFileSystem();
            _processManager = factory.CreateProcessManager();
        }

        public void Run()
        {
            _fileSystem.ReadFile("/home/data.txt");
            _processManager.StartProcess("MyApp");
        }
    }

    // =========================
    // 7. Entry Point
    // =========================
    class ProgramTest
    {
        public static void Test()
        {
            IOSFactory factory;

            Console.WriteLine("Choose OS: 1 = Windows, 2 = Linux");
            var input = Console.ReadLine();

            if (input == "1")
                factory = new WindowsFactory();
            else
                factory = new LinuxFactory();

            var app = new Application(factory);
            app.Run();

            Console.ReadLine();
        }
    }
}
