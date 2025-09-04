using VehicleManagementSystem.Vehicles;

namespace VehicleManagementSystem.IndependentClasses;

public static class TaxCalculator
{
    public static double CalculateTax(Vehicle vehicle)
    {
        return vehicle.CalculateTax();
    }
}

