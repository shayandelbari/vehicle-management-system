using Constants;
using Exceptions;

namespace Vehicles;

public class Boat : Vehicle
{
    private int seatingCapacity;
    public int SeatingCapacity
    {
        get { return seatingCapacity; }
        set
        {
            if (value < 0) throw new InvalidSeatingCapacityException("Seating capacity cannot be negative!");
            seatingCapacity = value;
        }
    }

    public Boat(string name, double price, double speed, int seatingCapacity)
        : base(name, price, speed, VehicleConstants.VehicleTypes.Boat)
    {
        SeatingCapacity = seatingCapacity;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Seating Capacity: {SeatingCapacity}");
    }

    public override double CalculateTax() => Price * VehicleConstants.TaxRates.BoatTaxRate;
}
