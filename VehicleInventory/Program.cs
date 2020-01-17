using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VehicleInventory.Models;

namespace VehicleInventory
{
    class Program
    {
        static void Main(string[] args)
        {
            var vehicleList = LoadVehicles();

            while (true)
            {
                Console.WriteLine("Search for the type of Vehicle you are looking for using 'List' for the full list or 'Types' to view the different types of vehicles.  You can then type 'List -Car' or another vehicle type to narrow the list." +
                    "\nType Exit if you wish to close the program");
                var userInput = Console.ReadLine();

                if (userInput.Contains("-"))
                {
                    var splitter = userInput.Split("-");
                    var typeValue = splitter[1];
                    var vehiclesByType = GetVehicleType(typeValue, vehicleList);
                    ShowVehicles(vehiclesByType);
                }
                else if (userInput.ToUpper() == "LIST")
                {
                    ShowVehicles(vehicleList);
                }
                else if (userInput.ToUpper() == "EXIT")
                {
                    break;
                }
                else if (userInput.ToUpper() == "TYPES")
                {
                    var typesOfVehicles = vehicleList.Select(d => d.VehicleType).Distinct().ToList();
                    ShowVehicleTypes(typesOfVehicles);

                }
                else
                {
                    Console.WriteLine("Please enter in a search in the correct format.");
                }
            }

        }

        private static List<Vehicle> LoadVehicles() 
        {
            var vehicleList = new List<Vehicle>();

            using (var reader = new StreamReader(@"Files\Vehicles.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var columns = line.Split(',');

                    var color = columns[0];
                    var make = columns[1];
                    var model = columns[2];
                    var modelYear = int.Parse(columns[3]);
                    var fuelType = columns[4];
                    var vehicleType = columns[5];
                    var vIN = columns[6];

                    switch (vehicleType)
                    {
                        case "Truck":
                            vehicleList.Add(new Truck() { Color = color, Make = make, Model = model, ModelYear = modelYear, FuelType = fuelType, VehicleType = vehicleType, VIN = vIN });
                            break;
                        case "SUV":
                            vehicleList.Add(new SUV() { Color = color, Make = make, Model = model, ModelYear = modelYear, FuelType = fuelType, VehicleType = vehicleType, VIN = vIN });
                            break;
                        case "Car":
                            vehicleList.Add(new Car() { Color = color, Make = make, Model = model, ModelYear = modelYear, FuelType = fuelType, VehicleType = vehicleType, VIN = vIN });
                            break;
                        default:
                            break;
                    }

                }

            }

            return vehicleList;
        }

        private static List<Vehicle> GetVehicleType(string vehicleType, List<Vehicle> vehicles)
        {
            return vehicles.Where(s => s.VehicleType.Equals(vehicleType, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        private static void ShowVehicles(List<Vehicle> vehicles)
        {
            Console.WriteLine($"Color\tMake\tModel\tYear\tFuel\tType\tVIN\t\t\tWeight\tTowCapacity\tAcceleration" +
                            $"\n************************************************************************************************************************\n");
            foreach (var item in vehicles)
            {
                Console.WriteLine(item);
            }
        }

        private static void ShowVehicleTypes(List<string> vehicles)
        {
            Console.WriteLine($"Vehicle Types\n");
            foreach (var item in vehicles)
            {
                Console.WriteLine(item);
            }
        }
    }
}
