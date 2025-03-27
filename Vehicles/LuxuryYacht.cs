using Constants;

namespace Vehicles;

public class LuxuryYacht : Boat
{
    public bool HasHelipad { get; set; }

    public LuxuryYacht(string name, double price, double speed, int seatingCapacity, bool hasHelipad)
        : base(name, price, speed, seatingCapacity)
    {
        HasHelipad = hasHelipad;
        VehicleType = VehicleConstants.VehicleTypes.LuxuryYacht;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Helipad: {(HasHelipad ? "Yes" : "No")}");
    }

    public override string ToString()
    {
        return $"{base.ToString()},{(HasHelipad ? bool.TrueString : bool.FalseString)}";
    }

    public override double CalculateTax() => Price * VehicleConstants.TaxRates.BoatTaxRate;
}
