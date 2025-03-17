namespace Exceptions;

public class InvalidSpeedException(string? message) : VehicleException(message ?? "Invalid speed.") { }
