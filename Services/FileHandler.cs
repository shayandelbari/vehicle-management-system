using Vehicles;
using Constants;

namespace vehicleManagementSystem;

public static class FileHandler
{
    private static readonly string filePath = "vehicles.csv";

    public static void SaveVehicles(Vehicle[] vehicles)
    {
        using StreamWriter writer = new(filePath);
        foreach (Vehicle vehicle in vehicles) writer.WriteLine(vehicle.ToString());
    }

    public static Vehicle[] LoadVehicles()
    {
        if (!File.Exists(filePath))
        {
            return [];
        }

        List<Vehicle> vehicles = [];
        using StreamReader reader = new(filePath);
        while (!reader.EndOfStream)
        {
            string? dataLine = reader.ReadLine();
            if (string.IsNullOrWhiteSpace(dataLine)) continue;

            string[] data = dataLine.Split(',');
            VehicleConstants.VehicleTypes vehicleType = Enum.Parse<VehicleConstants.VehicleTypes>(data[0]);

            switch (vehicleType)
            {
                case VehicleConstants.VehicleTypes.Car:
                    vehicles.Add(new Car(data[1], Convert.ToDouble(data[2]), Convert.ToDouble(data[3]), data[4], Convert.ToInt32(data[5])));
                    break;
                case VehicleConstants.VehicleTypes.RaceCar:
                    vehicles.Add(new RaceCar(data[1], Convert.ToDouble(data[2]), Convert.ToDouble(data[3]), data[4], Convert.ToInt32(data[5]), Convert.ToBoolean(data[6])));
                    break;
                case VehicleConstants.VehicleTypes.Truck:
                    vehicles.Add(new Truck(data[1], Convert.ToDouble(data[2]), Convert.ToDouble(data[3]), Convert.ToDouble(data[4])));
                    break;
                case VehicleConstants.VehicleTypes.Train:
                    vehicles.Add(new Train(data[1], Convert.ToDouble(data[2]), Convert.ToDouble(data[3]), Convert.ToInt32(data[4])));
                    break;
                case VehicleConstants.VehicleTypes.Boat:
                    vehicles.Add(new Boat(data[1], Convert.ToDouble(data[2]), Convert.ToDouble(data[3]), Convert.ToInt32(data[4])));
                    break;
                case VehicleConstants.VehicleTypes.LuxuryYacht:
                    vehicles.Add(new LuxuryYacht(data[1], Convert.ToDouble(data[2]), Convert.ToDouble(data[3]), Convert.ToInt32(data[4]), Convert.ToBoolean(data[5])));
                    break;
                case VehicleConstants.VehicleTypes.Airplane:
                    vehicles.Add(new Airplane(data[1], Convert.ToDouble(data[2]), Convert.ToDouble(data[3]), Convert.ToDouble(data[4])));
                    break;
                case VehicleConstants.VehicleTypes.CargoAirplane:
                    vehicles.Add(new CargoAirplane(data[1], Convert.ToDouble(data[2]), Convert.ToDouble(data[3]), Convert.ToDouble(data[4]), Convert.ToDouble(data[5])));
                    break;
            }
        }

        return [.. vehicles];
    }
}
