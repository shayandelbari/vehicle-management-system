namespace VehicleManagementSystem.Exceptions;

public class VehicleException : Exception
{
    public static int VehicleErrors { get; private set; } = 0;

    public VehicleException(string? message) : base(message ?? "Invalid vehicle data.") { VehicleErrors++; }
    public static void ResetErrorCount() => VehicleErrors = 0;
}

public class InvalidPriceException(string? message) : VehicleException(message ?? "Invalid price.") { }

public class InvalidSpeedException(string? message) : VehicleException(message ?? "Invalid speed.") { }

public class InvalidCargoCapacityException(string? message) : VehicleException(message ?? "Invalid cargo capacity.") { }

public class InvalidUnitsException(string? message) : VehicleException(message ?? "Invalid units.") { }

public class InvalidAltitudeException(string? message) : VehicleException(message ?? "Invalid altitude.") { }

public class InvalidSeatingCapacityException(string? message) : VehicleException(message ?? "Invalid seating capacity.") { }

public class InvalidHorsepowerException(string? message) : VehicleException(message ?? "Invalid horsepower.") { }