﻿using System;

public class Motorcycle : Vehicle
{
    public int EngineCapacity { get; set; }
    public bool HasSidecar { get; set; }
    public int MaxSpeed { get; set; }
    public string Type { get; set; }

    public Motorcycle(string brand, string model, int year, string plateNumber,
                      int engineCapacity, bool hasSidecar, int maxSpeed, string type)
        : base(brand, model, year, plateNumber)
    {
        this.EngineCapacity = engineCapacity;
        this.HasSidecar = hasSidecar;
        this.MaxSpeed = maxSpeed;
        this.Type = type;
    }

    public void ShowMotorcycleInfo()
    {
        Console.WriteLine("----- MOTORCYCLE INFO -----");
        ShowBasicInfo();
        Console.WriteLine($"Engine: {EngineCapacity}cc, Type: {Type}, Sidecar: {HasSidecar}, Max Speed: {MaxSpeed} km/h");
    }

    public double CalculateFuelCost(double distance)
    {
        double cost = (distance / 100) * 4 * 1.50;
        return cost;
    }
}
