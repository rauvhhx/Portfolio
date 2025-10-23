using System;

public class Truck : Vehicle
{
    public double CargoCapacity { get; set; }
    public int AxleCount { get; set; }
    public double CurrentLoad { get; set; }
    public int MaxSpeed { get; set; }

    public Truck(string brand, string model, int year, string plateNumber,
                 double cargoCapacity, int axleCount, double currentLoad, int maxSpeed)
        : base(brand, model, year, plateNumber)
    {
        this.CargoCapacity = cargoCapacity;
        this.AxleCount = axleCount;
        this.CurrentLoad = currentLoad;
        this.MaxSpeed = maxSpeed;
    }

    public void ShowTruckInfo()
    {
        Console.WriteLine("----- TRUCK INFO -----");
        ShowBasicInfo();
        Console.WriteLine($"Capacity: {CargoCapacity} ton, Axles: {AxleCount}, Current Load: {CurrentLoad} ton, Max Speed: {MaxSpeed} km/h");
    }

    public void LoadCargo(double weight)
    {
        if (CurrentLoad + weight <= CargoCapacity)
        {
            CurrentLoad += weight;
            Console.WriteLine($"{weight} ton yük əlavə edildi. Yeni yük: {CurrentLoad} ton");
        }
        else
        {
            Console.WriteLine("⚠️ Yük tutumu aşılır!");
        }
    }

    public double CalculateFuelCost(double distance)
    {
        double cost = (distance / 100) * (25 + CurrentLoad * 2) * 1.80;
        return cost;
    }
}
