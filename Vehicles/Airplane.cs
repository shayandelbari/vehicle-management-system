using Constants;

namespace Vehicles;

public class Airplane : Vehicle
{
    public double Altitude { get; set; }

    public Airplane(string name, double price, double speed, double altitude)
        : base(name, price, speed, VehicleConstants.VehicleTypes.Airplane)
    {
        Altitude = altitude;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Altitude: {Altitude} meters");
    }

    public override double CalculateTax() => Price * VehicleConstants.TaxRates.AirplaneTaxRate;
}
