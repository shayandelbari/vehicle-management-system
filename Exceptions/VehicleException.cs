namespace Exceptions;

public class VehicleException : Exception
{
    public static int VehicleErrors { get; private set; } = 0;

    public VehicleException(string? message) : base(message ?? "Invalid vehicle data.") { VehicleErrors++; }

}
