using VehicleManagementSystem.Constants;
using VehicleManagementSystem.Exceptions;

namespace VehicleManagementSystem.Vehicles;
public class Car : Vehicle
{

    public string model = string.Empty;
    public string Model { get { return model; } set { model = value; } }

    private int horsepower;
    public int Horsepower
    {
        get { return horsepower; }
        set
        {
            if (value < 0) throw new InvalidHorsepowerException("Horsepower cannot be negative!"); horsepower = value;
        }
    }

    public Car(string name, double price, double speed, string model, int horsepower)
        : base(name, price, speed, VehicleConstants.VehicleTypes.Car)
    {
        Model = model;
        Horsepower = horsepower;
    }
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Model: {Model}");
        Console.WriteLine($"Horsepower: {Horsepower} hp");
    }

    public override string ToString()
    {
        return $"{base.ToString()},{Model},{Horsepower}";
    }

    public override double CalculateTax() => Price * VehicleConstants.TaxRates.CarTaxRate;
}
