using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VehicleInventory
{
    class Program
    {
        static void Main(string[] args)
        {
            var vehicleList = LoadVehicles();

            while (true)
            {
                Console.WriteLine("Search for the type of Vehicle you are looking for using 'List' for the full list or 'List -car' or type Exit to close the program: ");
                var userInput = Console.ReadLine();

                if (userInput.Contains("-"))
                {
                    var splitter = userInput.Split("-");
                    var typeValue = splitter[1];
                    var vehiclesByType = GetVehicleType(typeValue, vehicleList);
                    ShowVehicles(vehiclesByType);
                }
                else if (userInput.ToUpper() == "EXIT")
                {
                    break;
                }
                else
                {
                    ShowVehicles(vehicleList);
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

                    vehicleList.Add(new Vehicle(line));
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
            Console.WriteLine($"Color\tMake\tModel\tYear\tFuel\tType\tVIN" +
                            $"\n******************************************************************");
            foreach (var item in vehicles)
            {
                Console.WriteLine(item);
            }
        }
    }
}
