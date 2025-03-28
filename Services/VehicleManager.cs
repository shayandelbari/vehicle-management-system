using VehicleManagementSystem.Vehicles;

namespace VehicleManagementSystem.Services;

public class VehicleManager
{
    private List<Vehicle> vehicles = [];

    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public void RemoveVehicle(Vehicle vehicle)
    {
        vehicles.Remove(vehicle);
    }

    public Vehicle[] GetAllVehicles()
    {
        return [.. vehicles];
    }

    public void SaveVehicles()
    {
        FileHandler.SaveVehicles([.. vehicles]);
    }

    public void LoadVehicles()
    {
        vehicles = [.. FileHandler.LoadVehicles()];
    }
}
