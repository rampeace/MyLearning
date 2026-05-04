using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.DesignPatterns
{
    /*
     * Multiple cars (what)
       Multiple engines (how)
       Both evolve independently
     */

    // =========================
    // Implementation hierarchy (HOW)
    // =========================
    public interface IEngine
    {
        void Start();
        void Stop();
    }

    public class PetrolEngine : IEngine
    {
        public void Start() => Console.WriteLine("Petrol engine started");
        public void Stop() => Console.WriteLine("Petrol engine stopped");
    }

    public class DieselEngine : IEngine
    {
        public void Start() => Console.WriteLine("Diesel engine started");
        public void Stop() => Console.WriteLine("Diesel engine stopped");
    }

    public class GasEngine : IEngine
    {
        public void Start() => Console.WriteLine("Gas engine started");
        public void Stop() => Console.WriteLine("Gas engine stopped");
    }

    // =========================
    // Abstraction hierarchy (WHAT)
    // =========================
    public abstract class Car
    {
        protected readonly IEngine _engine;

        protected Car(IEngine engine)
        {
            _engine = engine;
        }

        public abstract void Drive();

        public virtual void Stop()
        {
            Console.WriteLine("Car stopping...");
            _engine.Stop();
        }
    }

    public class NormalCar : Car
    {
        public NormalCar(IEngine engine) : base(engine) { }

        public override void Drive()
        {
            _engine.Start();
            Console.WriteLine("Normal car driving");
        }
    }

    public class SportsCar : Car
    {
        public SportsCar(IEngine engine) : base(engine) { }

        public override void Drive()
        {
            _engine.Start();
            Console.WriteLine("Sports car zooming!");
        }
    }

    public class CircusCar : Car
    {
        public CircusCar(IEngine engine) : base(engine) { }

        public override void Drive()
        {
            _engine.Start();
            Console.WriteLine("Circus car doing tricks 🤡");
        }
    }

    // =========================
    // Client
    // =========================
    public static class BridgeTest
    {
        public static void Test()
        {
            Car car1 = new SportsCar(new PetrolEngine());
            car1.Drive();
            car1.Stop();

            Console.WriteLine();

            Car car2 = new CircusCar(new GasEngine());
            car2.Drive();
            car2.Stop();

            Console.WriteLine();

            Car car3 = new NormalCar(new DieselEngine());
            car3.Drive();
            car3.Stop();
        }
    }
}
