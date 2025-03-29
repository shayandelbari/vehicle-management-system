using VehicleManagementSystem.Constants;
using VehicleManagementSystem.Exceptions;

namespace VehicleManagementSystem.Vehicles;

public class Airplane : Vehicle
{
    private double altitude;
    public double Altitude
    {
        get { return altitude; }
        set
        {
            if (value < 0)
                throw new InvalidAltitudeException("Altitude cannot be negative!");
            altitude = value;
        }
    }

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

    public override string ToString()
    {
        return $"{base.ToString()},{Altitude}";
    }

    public override double CalculateTax() => Price * VehicleConstants.TaxRates.AirplaneTaxRate;
}
