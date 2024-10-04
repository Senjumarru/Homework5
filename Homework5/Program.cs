using System;

namespace VehicleFactoryExample
{
    public interface IVehicle
    {
        void Drive();
        void Refuel();
    }

    public class Car : IVehicle
    {
        private string Make;
        private string Model;
        private string FuelType;

        public Car(string make, string model, string fuelType)
        {
            Make = make;
            Model = model;
            FuelType = fuelType;
        }

        public void Drive()
        {
            Console.WriteLine($"Car {Make} {Model} is driving.");
        }

        public void Refuel()
        {
            Console.WriteLine($"Car {Make} {Model} is refueling with {FuelType}.");
        }
    }

    public class Motorcycle : IVehicle
    {
        private string Type;
        private int EngineCapacity;

        public Motorcycle(string type, int engineCapacity)
        {
            Type = type;
            EngineCapacity = engineCapacity;
        }

        public void Drive()
        {
            Console.WriteLine($"Motorcycle {Type} with engine {EngineCapacity}cc is driving.");
        }

        public void Refuel()
        {
            Console.WriteLine($"Motorcycle {Type} is refueling.");
        }
    }

    public class Truck : IVehicle
    {
        private int LoadCapacity;
        private int Axles;

        public Truck(int loadCapacity, int axles)
        {
            LoadCapacity = loadCapacity;
            Axles = axles;
        }

        public void Drive()
        {
            Console.WriteLine($"Truck with load capacity {LoadCapacity}kg and {Axles} axles is driving.");
        }

        public void Refuel()
        {
            Console.WriteLine($"Truck with load capacity {LoadCapacity}kg is refueling.");
        }
    }

    public abstract class VehicleFactory
    {
        public abstract IVehicle CreateVehicle();
    }

    public class CarFactory : VehicleFactory
    {
        private string Make;
        private string Model;
        private string FuelType;

        public CarFactory(string make, string model, string fuelType)
        {
            Make = make;
            Model = model;
            FuelType = fuelType;
        }

        public override IVehicle CreateVehicle()
        {
            return new Car(Make, Model, FuelType);
        }
    }

    public class MotorcycleFactory : VehicleFactory
    {
        private string Type;
        private int EngineCapacity;

        public MotorcycleFactory(string type, int engineCapacity)
        {
            Type = type;
            EngineCapacity = engineCapacity;
        }

        public override IVehicle CreateVehicle()
        {
            return new Motorcycle(Type, EngineCapacity);
        }
    }

    public class TruckFactory : VehicleFactory
    {
        private int LoadCapacity;
        private int Axles;

        public TruckFactory(int loadCapacity, int axles)
        {
            LoadCapacity = loadCapacity;
            Axles = axles;
        }

        public override IVehicle CreateVehicle()
        {
            return new Truck(LoadCapacity, Axles);
        }
    }

    public class Bus : IVehicle
    {
        private int SeatingCapacity;

        public Bus(int seatingCapacity)
        {
            SeatingCapacity = seatingCapacity;
        }

        public void Drive()
        {
            Console.WriteLine($"Bus with seating capacity {SeatingCapacity} is driving.");
        }

        public void Refuel()
        {
            Console.WriteLine($"Bus is refueling.");
        }
    }

    public class BusFactory : VehicleFactory
    {
        private int SeatingCapacity;

        public BusFactory(int seatingCapacity)
        {
            SeatingCapacity = seatingCapacity;
        }

        public override IVehicle CreateVehicle()
        {
            return new Bus(SeatingCapacity);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select vehicle type: 1. Car, 2. Motorcycle, 3. Truck, 4. Bus");
            int choice = int.Parse(Console.ReadLine());

            VehicleFactory factory = null;

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter make, model, and fuel type:");
                    factory = new CarFactory(Console.ReadLine(), Console.ReadLine(), Console.ReadLine());
                    break;
                case 2:
                    Console.WriteLine("Enter motorcycle type and engine capacity:");
                    factory = new MotorcycleFactory(Console.ReadLine(), int.Parse(Console.ReadLine()));
                    break;
                case 3:
                    Console.WriteLine("Enter load capacity and number of axles:");
                    factory = new TruckFactory(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                    break;
                case 4:
                    Console.WriteLine("Enter seating capacity:");
                    factory = new BusFactory(int.Parse(Console.ReadLine()));
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            if (factory != null)
            {
                IVehicle vehicle = factory.CreateVehicle();
                vehicle.Drive();
                vehicle.Refuel();
            }
        }
    }
}
