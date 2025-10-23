using System;

public class Car : Vehicle
{
    public int DoorsCount { get; set; }
    public int TrunkCapacity { get; set; }
    public bool IsAutomatic { get; set; }
    public int MaxSpeed { get; set; }

    public Car(string brand, string model, int year, string plateNumber,
               int doorsCount, int trunkCapacity, bool isAutomatic, int maxSpeed)
        : base(brand, model, year, plateNumber)
    {
        this.DoorsCount = doorsCount;
        this.TrunkCapacity = trunkCapacity;
        this.IsAutomatic = isAutomatic;
        this.MaxSpeed = maxSpeed;
    }

    public void ShowCarInfo()
    {
        Console.WriteLine("----- CAR INFO -----");
        ShowBasicInfo();
        Console.WriteLine($"Doors: {DoorsCount}, Trunk: {TrunkCapacity}L, Automatic: {IsAutomatic}, Max Speed: {MaxSpeed} km/h");
    }

    public double CalculateFuelCost(double distance)
    {
        double cost = (distance / 100) * 8 * 1.50;
        return cost;
    }
}
