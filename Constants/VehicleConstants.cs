namespace Constants;

public static class VehicleConstants
{
    public static class TaxRates
    {
        public const double CarTaxRate = 0.10;
        public const double AirplaneTaxRate = 0.15;
        public const double BoatTaxRate = 0.05;
        public const double TruckTaxRate = 0.20;
    }

    public static class SpeedThresholds
    {
        public const double FastVehicleThreshold = 200.0;
    }

    public static class CargoLimits
    {
        public const double MinimumCargoCapacity = 0.0;
        public const double MaximumCargoCapacity = 100000.0;
    }

    public enum VehicleTypes
    {
        Car,
        Airplane,
        Boat,
        Truck,
        Train
    }
}