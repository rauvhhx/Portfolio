using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;

public class Program
{
    public static void Main()
    {
        
        var car1 = new Car("Mercedes", "E200", 2023, "10-AA-001", 4, 500, true, 220);
        var car2 = new Car("BMW", "320i", 2022, "10-BB-002", 4, 480, true, 235);
        var car3 = new Car("Toyota", "Camry", 2021, "10-CC-003", 4, 524, true, 210);

      
        var moto1 = new Motorcycle("Yamaha", "R1", 2023, "99-MC-001", 998, false, 299, "Sport");
        var moto2 = new Motorcycle("Harley-Davidson", "Road King", 2022, "99-MC-002", 1868, true, 180, "Cruiser");

      
        var truck1 = new Truck("MAN", "TGX", 2020, "77-TR-001", 18, 3, 12, 120);
        var truck2 = new Truck("Volvo", "FH16", 2021, "77-TR-002", 25, 4, 18, 110);

        
        List<Vehicle> vehicles = new List<Vehicle>() { car1, car2, car3, moto1, moto2, truck1, truck2 };

        Console.WriteLine("\n========== VEHICLE INFO ==========\n");

        
        car1.ShowCarInfo();
        Console.WriteLine($"Fuel cost for 500 km: {car1.CalculateFuelCost(500):0.00} AZN\n");

        car2.ShowCarInfo();
        Console.WriteLine($"Fuel cost for 500 km: {car2.CalculateFuelCost(500):0.00} AZN\n");

        car3.ShowCarInfo();
        Console.WriteLine($"Fuel cost for 500 km: {car3.CalculateFuelCost(500):0.00} AZN\n");

     
        moto1.ShowMotorcycleInfo();
        Console.WriteLine($"Fuel cost for 300 km: {moto1.CalculateFuelCost(300):0.00} AZN\n");

        moto2.ShowMotorcycleInfo();
        Console.WriteLine($"Fuel cost for 300 km: {moto2.CalculateFuelCost(300):0.00} AZN\n");

    
        truck1.ShowTruckInfo();
        double cost1 = truck1.CalculateFuelCost(800);
        Console.WriteLine($"Fuel cost for 800 km: {cost1:0.00} AZN\n");

        truck2.ShowTruckInfo();
        double cost2 = truck2.CalculateFuelCost(800);
        Console.WriteLine($"Fuel cost for 800 km: {cost2:0.00} AZN\n");

      
        Console.WriteLine("\n========== ADDING LOAD ==========");
        truck1.LoadCargo(5);
        double newCost = truck1.CalculateFuelCost(800);
        Console.WriteLine($"New fuel cost for 800 km: {newCost:0.00} AZN\n");

      
        Console.WriteLine("\n========== STATISTICS ==========");
        Console.WriteLine($"Total vehicles: {vehicles.Count}");

        double avgSpeed = (
            car1.MaxSpeed + car2.MaxSpeed + car3.MaxSpeed +
            moto1.MaxSpeed + moto2.MaxSpeed +
            truck1.MaxSpeed + truck2.MaxSpeed
        ) / 7.0;

        Console.WriteLine($"Average Max Speed: {avgSpeed:0.00} km/h");

        var fuelCosts = new List<(string Name, double Cost)>
        {
            ($"{car1.Brand} {car1.Model}", car1.CalculateFuelCost(500)),
            ($"{car2.Brand} {car2.Model}", car2.CalculateFuelCost(500)),
            ($"{car3.Brand} {car3.Model}", car3.CalculateFuelCost(500)),
            ($"{moto1.Brand} {moto1.Model}", moto1.CalculateFuelCost(300)),
            ($"{moto2.Brand} {moto2.Model}", moto2.CalculateFuelCost(300)),
            ($"{truck1.Brand} {truck1.Model}", truck1.CalculateFuelCost(800)),
            ($"{truck2.Brand} {truck2.Model}", truck2.CalculateFuelCost(800))
        };

        var mostExpensive = fuelCosts.OrderByDescending(x => x.Cost).First();
        Console.WriteLine($"Most expensive fuel cost: {mostExpensive.Name} - {mostExpensive.Cost:0.00} AZN");
    }
}
