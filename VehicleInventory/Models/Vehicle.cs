using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using VehicleInventory.Models;

namespace VehicleInventory
{
    public abstract class Vehicle
    {
        protected static Random Random = new Random();
        protected const double HpToFootPoundPerSecond = 550;
        public abstract double GetAcceleration();
        public int VehicleID { get; set; }
        public string Color { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public string FuelType { get; set; }
        public string VehicleType { get; set; }
        public string VIN { get; set; }
        public double Acceleration { get; set; }   
        public int HorsePower { get; set; }
        public int VehicleTypeID { get; set; }


        public Vehicle()
        {

        }

        public Vehicle(string color, string make, string model, int modelYear, string fuelType, string vehicleType, string vIN)
        {
            this.VehicleID = GetVehicleID();
            this.Color = color;
            this.Make = make;
            this.Model = model;
            this.ModelYear = modelYear;
            this.FuelType = fuelType;
            this.VehicleType = vehicleType;
            this.VIN = vIN;
        }

        public int GetVehicleID()
        {
            return VehicleID++;
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
