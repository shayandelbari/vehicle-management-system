using VehicleManagementSystem.Constants;
using VehicleManagementSystem.Exceptions;

namespace VehicleManagementSystem.Vehicles;

public class Train : Vehicle
{
    private int units;
    public int Units
    {
        get { return units; }
        set
        {
            if (value < 0)
                throw new InvalidUnitsException("Units cannot be negative!");
            units = value;
        }
    }

    public Train(string name, double price, double speed, int units)
        : base(name, price, speed, VehicleConstants.VehicleTypes.Train)
    {
        Units = units;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Units: {Units}");
    }

    public override string ToString()
    {
        return $"{base.ToString()},{Units}";
    }

    public override double CalculateTax() => Price * VehicleConstants.TaxRates.TruckTaxRate;
}
