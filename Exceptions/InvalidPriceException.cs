namespace Exceptions;

public class InvalidPriceException(string? message) : VehicleException(message ?? "Invalid price.") { }