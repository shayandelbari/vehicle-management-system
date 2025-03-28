using VehicleManagementSystem.Vehicles;

namespace VehicleManagementSystem.IndependentClasses;

public class VehicleComparer
{
    public static void SortByPrice(Vehicle[] vehicles)
    {
        BubbleSort(vehicles, (v1, v2) => v1.Price.CompareTo(v2.Price));
    }

    public static void SortBySpeed(Vehicle[] vehicles)
    {
        BubbleSort(vehicles, (v1, v2) => v1.Speed.CompareTo(v2.Speed));
    }

    public static void SortByType(Vehicle[] vehicles)
    {
        BubbleSort(vehicles, (v1, v2) => v1.VehicleType.ToString().CompareTo(v2.VehicleType.ToString()));
    }

    private static void BubbleSort(Vehicle[] vehicles, Comparison<Vehicle> comparison)
    {
        for (int i = 0; i < vehicles.Length - 1; i++)
        {
            for (int j = 0; j < vehicles.Length - i - 1; j++)
            {
                if (comparison(vehicles[j], vehicles[j + 1]) > 0)
                {
                    (vehicles[j + 1], vehicles[j]) = (vehicles[j], vehicles[j + 1]);
                }
            }
        }
    }
}
