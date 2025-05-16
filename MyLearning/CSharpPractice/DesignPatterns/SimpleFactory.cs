using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.DesignPatterns
{
    internal class SimpleFactory
    {
        public void Test()
        {
            var vehicle = VehicleFactory("car");
            vehicle.Move();

            vehicle = VehicleFactory("bike");
            vehicle.Move();
        }
        public interface IVehicle
        {
            void Move();
        }

        public class Car : IVehicle
        {
            public void Move()
            {
                Console.WriteLine("Car moves");
            }
        }

        public class MotorBike : IVehicle
        {
            public void Move()
            {
                Console.WriteLine("Bike moves");
            }
        }

        public IVehicle VehicleFactory(string type)
        {
            return type switch
            {
                "car" => new Car(),
                "bike" => new MotorBike(),
                _ => throw new ArgumentException("Invalid type")
            };
        }
    }
}
