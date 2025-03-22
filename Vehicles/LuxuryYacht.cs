using Constants;
using Exceptions;

namespace Vehicles;

public class LuxuryYacht : Boat
{
    public bool HasHelipad { get; set; }

    public LuxuryYacht(string name, double price, double speed, int seatingCapacity, bool hasHelipad)
        : base(name, price, speed, seatingCapacity)
    {
        if (seatingCapacity < 0)
        {
            throw new InvalidSeatingCapacityException("Seating capacity cannot be negative.");
        }
        HasHelipad = hasHelipad;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Helipad: {(HasHelipad ? "Yes" : "No")}");
    }

    public override double CalculateTax() => Price * VehicleConstants.TaxRates.BoatTaxRate;
}
