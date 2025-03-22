using Constants;
using Exceptions;

namespace Vehicles;

public class RaceCar : Car
{
    public bool TurboBoost { get; set; }

    public RaceCar(string name, double price, double speed, string model, int horsepower, bool turboBoost)
        : base(name, price, speed, model, horsepower)
    {
        TurboBoost = turboBoost;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Turbo Boost: {(TurboBoost ? "Yes" : "No")}");
    }

    public override double CalculateTax() => Price * VehicleConstants.TaxRates.CarTaxRate;
}
