using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace VehicleInventory
{
    public class Vehicle
    {
        public string Color { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public string FuelType { get; set; }
        public string VehicleType { get; set; }
        public string VIN { get; set; }

        public Vehicle(string color, string make, string model, int modelYear, string fuelType, string vehicleType, string vIN)
        {
            this.Color = color;
            this.Make = make;
            this.Model = model;
            this.ModelYear = modelYear;
            this.FuelType = fuelType;
            this.VehicleType = vehicleType;
            this.VIN = vIN;
        }

        public Vehicle(string line)
        {
            var columns = line.Split(',');

            this.Color = columns[0];
            this.Make = columns[1];
            this.Model = columns[2];
            this.ModelYear = int.Parse(columns[3]);
            this.FuelType = columns[4];
            this.VehicleType = columns[5];
            this.VIN = columns[6];
        }

        public override string ToString()
        {
            return $"{Color}\t{Make}\t{Model}\t{ModelYear}\t{FuelType}\t{VehicleType}\t{VIN}";
        }

    }
}
