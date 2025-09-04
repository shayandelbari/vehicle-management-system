using VehicleManagementSystem.Constants;
using VehicleManagementSystem.Exceptions;

namespace VehicleManagementSystem.Vehicles;

public abstract class Vehicle
{
    private string name = string.Empty;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private double price;
    public double Price
    {
        get { return price; }
        set
        {
            if (value < 0)
                throw new InvalidPriceException("Price cannot be negative!");
            price = value;
        }
    }

    private double speed;
    public double Speed
    {
        get { return speed; }
        set
        {
            if (value < 0)
                throw new InvalidSpeedException("Speed cannot be negative!");
            speed = value;
        }
    }

    private VehicleConstants.VehicleTypes vehicleType;
    public VehicleConstants.VehicleTypes VehicleType
    {
        get { return vehicleType; }
        set { vehicleType = value; }
    }

    protected Vehicle(
        string name,
        double price,
        double speed,
        VehicleConstants.VehicleTypes vehicleType
    )
    {
        Name = name;
        Price = price;
        Speed = speed;
        VehicleType = vehicleType;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Price: {Price:C}");
        Console.WriteLine($"Speed: {Speed} km/h");
        Console.WriteLine($"Vehicle Type: {VehicleType}");
    }

    public override string ToString()
    {
        return $"{VehicleType},{Name},{Price},{Speed}";
    }

    public abstract double CalculateTax();
}
