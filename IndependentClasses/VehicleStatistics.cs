using VehicleManagementSystem.Constants;
using VehicleManagementSystem.Vehicles;

namespace VehicleManagementSystem.IndependentClasses;

public static class VehicleStatistics
{
    public static double AveragePrice(Vehicle[] vehicles)
    {
        return vehicles.Average(v => v.Price);
    }

    public static Vehicle FastestVehicle(Vehicle[] vehicles)
    {
        VehicleComparer.SortBySpeed(vehicles);
        return vehicles[^1];
    }

    public static int CountByType(Vehicle[] vehicles, VehicleConstants.VehicleTypes type)
    {
        return vehicles.Count(v => v.VehicleType == type);
    }
}
