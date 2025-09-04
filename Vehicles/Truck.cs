using VehicleManagementSystem.Constants;
using VehicleManagementSystem.Exceptions;

namespace VehicleManagementSystem.Vehicles;

public class Truck : Vehicle
{
    private double loadCapacity;
    public double LoadCapacity
    {
        get { return loadCapacity; }
        set
        {
            if (value < 0)
                throw new InvalidCargoCapacityException("Load capacity cannot be negative!");
            loadCapacity = value;
        }
    }

    public Truck(string name, double price, double speed, double loadCapacity)
        : base(name, price, speed, VehicleConstants.VehicleTypes.Truck)
    {
        LoadCapacity = loadCapacity;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Load Capacity: {LoadCapacity} kg");
    }

    public override string ToString()
    {
        return $"{base.ToString()},{LoadCapacity}";
    }

    public override double CalculateTax() => Price * VehicleConstants.TaxRates.TruckTaxRate;
}
