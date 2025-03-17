using Exceptions;
namespace finalProject;

public abstract class Vehicle
{
    private string name = string.Empty;
    public string Name { get { return name; } set { name = value; } }

    private double price;
    public double Price
    {
        get { return price; }
        set { if (value < 0) throw new InvalidPriceException("Price cannot be negative!"); price = value; }
    }

    private double speed;
    public double Speed
    {
        get { return speed; }
        set { if (value < 0) throw new InvalidSpeedException("Speed cannot be negative!"); speed = value; }
    }

    private string vehicleType = string.Empty;
    public string VehicleType { get { return vehicleType; } set { vehicleType = value; } }

    public Vehicle(string name, double price, double speed, string vehicleType)
    {
        Name = name;
        Price = price;
        Speed = speed;
        VehicleType = vehicleType;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Price: {Price}");
        Console.WriteLine($"Speed: {Speed}");
        Console.WriteLine($"Vehicle Type: {VehicleType}");
    }

    public abstract double CalculateTax();
}
