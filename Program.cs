using VehicleManagementSystem.Constants;
using VehicleManagementSystem.Exceptions;
using VehicleManagementSystem.IndependentClasses;
using VehicleManagementSystem.Services;
using VehicleManagementSystem.Vehicles;

namespace VehicleManagementSystem;

class Program
{
    static void Main(string[] args)
    {
        VehicleManager vehicleManager = new();
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("====================================");
            Console.WriteLine("       Vehicle Management System    ");
            Console.WriteLine("====================================");
            Console.ResetColor();
            Console.WriteLine("1. Add Vehicle");
            Console.WriteLine("2. Display All Vehicles");
            Console.WriteLine("3. Sort Vehicles");
            Console.WriteLine("4. Analyze Vehicles");
            Console.WriteLine("5. Save Vehicles to File");
            Console.WriteLine("6. Load Vehicles from File");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddVehicle(vehicleManager);
                    break;
                case "2":
                    DisplayVehicles(vehicleManager);
                    break;
                case "3":
                    SortVehicles(vehicleManager);
                    break;
                case "4":
                    AnalyzeVehicles(vehicleManager);
                    break;
                case "5":
                    vehicleManager.SaveVehicles();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Vehicles saved successfully!");
                    Console.ResetColor();
                    break;
                case "6":
                    vehicleManager.LoadVehicles();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Vehicles loaded successfully!");
                    Console.ResetColor();
                    break;
                case "7":
                    exit = true;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("===============================================");
                    Console.WriteLine("Thanks for using the Vehicle Management System!");
                    Console.WriteLine("===============================================");
                    Console.ResetColor();
                    Console.WriteLine(
                        $"The number of exceptions thrown: {VehicleException.VehicleErrors}"
                    );
                    Thread.Sleep(2000);
                    Console.Clear();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.ResetColor();
                    break;
            }

            if (!exit)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }

    static void AddVehicle(VehicleManager vehicleManager)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Add a New Vehicle");
        Console.ResetColor();
        Console.WriteLine("Select Vehicle Type:");
        foreach (var type in Enum.GetValues<VehicleConstants.VehicleTypes>())
        {
            Console.WriteLine($"- {type}");
        }

        VehicleConstants.VehicleTypes vehicleType;
        while (true)
        {
            try
            {
                Console.Write("Enter vehicle type: ");
                if (!Enum.TryParse(Console.ReadLine(), out vehicleType))
                    throw new FormatException("Invalid vehicle type.");
                break;
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        Console.Write("Enter name: ");
        string name = Console.ReadLine() ?? string.Empty;

        double price;
        while (true)
        {
            try
            {
                Console.Write("Enter price: ");
                price = Convert.ToDouble(Console.ReadLine());
                break;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid number for price.");
                Console.ResetColor();
            }
        }

        double speed;
        while (true)
        {
            try
            {
                Console.Write("Enter speed: ");
                speed = Convert.ToDouble(Console.ReadLine());
                break;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid number for speed.");
                Console.ResetColor();
            }
        }

        Vehicle? vehicle = null;
        try
        {
            vehicle = vehicleType switch
            {
                VehicleConstants.VehicleTypes.Car => CreateCar(name, price, speed),
                VehicleConstants.VehicleTypes.RaceCar => CreateRaceCar(name, price, speed),
                VehicleConstants.VehicleTypes.Truck => CreateTruck(name, price, speed),
                VehicleConstants.VehicleTypes.Train => CreateTrain(name, price, speed),
                VehicleConstants.VehicleTypes.Boat => CreateBoat(name, price, speed),
                VehicleConstants.VehicleTypes.LuxuryYacht => CreateLuxuryYacht(name, price, speed),
                VehicleConstants.VehicleTypes.Airplane => CreateAirplane(name, price, speed),
                VehicleConstants.VehicleTypes.CargoAirplane => CreateCargoAirplane(
                    name,
                    price,
                    speed
                ),
                _ => null,
            };
        }
        catch (VehicleException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error creating vehicle: {ex.Message}");
            Console.ResetColor();
            return;
        }

        if (vehicle != null)
        {
            vehicleManager.AddVehicle(vehicle);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Vehicle added successfully!");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Failed to create vehicle.");
            Console.ResetColor();
        }
    }

    static void DisplayVehicles(VehicleManager vehicleManager)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("All Vehicles");
        Console.ResetColor();
        var vehicles = vehicleManager.GetAllVehicles();
        if (vehicles.Length == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No vehicles available.");
            Console.ResetColor();
            return;
        }

        foreach (var vehicle in vehicles)
        {
            vehicle.DisplayInfo();
            Console.WriteLine();
        }
    }

    static void SortVehicles(VehicleManager vehicleManager)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Sort Vehicles");
        Console.ResetColor();
        Console.WriteLine("Sort By:");
        Console.WriteLine("1. Price");
        Console.WriteLine("2. Speed");
        Console.WriteLine("3. Type");
        Console.Write("Select an option: ");

        var vehicles = vehicleManager.GetAllVehicles();
        switch (Console.ReadLine())
        {
            case "1":
                VehicleComparer.SortByPrice(vehicles);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Vehicles sorted by price.");
                Console.ResetColor();
                break;
            case "2":
                VehicleComparer.SortBySpeed(vehicles);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Vehicles sorted by speed.");
                Console.ResetColor();
                break;
            case "3":
                VehicleComparer.SortByType(vehicles);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Vehicles sorted by type.");
                Console.ResetColor();
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid option.");
                Console.ResetColor();
                break;
        }
    }

    static void AnalyzeVehicles(VehicleManager vehicleManager)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Vehicle Analysis");
        Console.ResetColor();
        var vehicles = vehicleManager.GetAllVehicles();
        if (vehicles.Length == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No vehicles available for analysis.");
            Console.ResetColor();
            return;
        }

        Console.WriteLine($"Average Price: {VehicleStatistics.AveragePrice(vehicles):C}");
        Console.WriteLine($"Fastest Vehicle: {VehicleStatistics.FastestVehicle(vehicles).Name}");
        foreach (var type in Enum.GetValues<VehicleConstants.VehicleTypes>())
        {
            Console.WriteLine($"{type}: {VehicleStatistics.CountByType(vehicles, type)}");
        }
    }

    static Car CreateCar(string name, double price, double speed)
    {
        Console.Write("Enter model: ");
        string model = Console.ReadLine() ?? string.Empty;

        int horsepower;
        while (true)
        {
            try
            {
                Console.Write("Enter horsepower: ");
                horsepower = Convert.ToInt32(Console.ReadLine());
                break;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid integer for horsepower.");
                Console.ResetColor();
            }
        }

        return new Car(name, price, speed, model, horsepower);
    }

    static RaceCar CreateRaceCar(string name, double price, double speed)
    {
        var car = CreateCar(name, price, speed);
        Console.Write("Has Turbo Boost (true/false): ");
        bool turboBoost = Console.ReadLine()?.ToLower() == "true";

        return new RaceCar(car.Name, car.Price, car.Speed, car.Model, car.Horsepower, turboBoost);
    }

    static Truck CreateTruck(string name, double price, double speed)
    {
        double loadCapacity;
        while (true)
        {
            try
            {
                Console.Write("Enter load capacity: ");
                loadCapacity = Convert.ToDouble(Console.ReadLine());
                break;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid number for load capacity.");
                Console.ResetColor();
            }
        }

        return new Truck(name, price, speed, loadCapacity);
    }

    static Train CreateTrain(string name, double price, double speed)
    {
        int units;
        while (true)
        {
            try
            {
                Console.Write("Enter number of units: ");
                units = Convert.ToInt32(Console.ReadLine());
                break;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    "Invalid input. Please enter a valid integer for number of units."
                );
                Console.ResetColor();
            }
        }

        return new Train(name, price, speed, units);
    }

    static Boat CreateBoat(string name, double price, double speed)
    {
        Console.Write("Enter seating capacity: ");
        int seatingCapacity = Convert.ToInt32(Console.ReadLine());

        return new Boat(name, price, speed, seatingCapacity);
    }

    static LuxuryYacht CreateLuxuryYacht(string name, double price, double speed)
    {
        var boat = CreateBoat(name, price, speed);
        Console.Write("Has Helipad (true/false): ");
        bool hasHelipad = Console.ReadLine()?.ToLower() == "true";

        return new LuxuryYacht(boat.Name, boat.Price, boat.Speed, boat.SeatingCapacity, hasHelipad);
    }

    static Airplane CreateAirplane(string name, double price, double speed)
    {
        double altitude;
        while (true)
        {
            try
            {
                Console.Write("Enter altitude: ");
                altitude = Convert.ToDouble(Console.ReadLine());
                break;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid number for altitude.");
                Console.ResetColor();
            }
        }

        return new Airplane(name, price, speed, altitude);
    }

    static CargoAirplane CreateCargoAirplane(string name, double price, double speed)
    {
        var airplane = CreateAirplane(name, price, speed);
        Console.Write("Enter cargo capacity: ");
        double cargoCapacity = Convert.ToDouble(Console.ReadLine());

        return new CargoAirplane(
            airplane.Name,
            airplane.Price,
            airplane.Speed,
            airplane.Altitude,
            cargoCapacity
        );
    }
}
