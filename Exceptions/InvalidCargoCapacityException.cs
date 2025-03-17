namespace Exceptions;

public class InvalidCargoCapacityException(string? message) : VehicleException(message ?? "Invalid cargo capacity.") { }