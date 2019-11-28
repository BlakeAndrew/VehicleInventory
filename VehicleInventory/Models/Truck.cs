using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleInventory.Models
{
    public class Truck : Vehicle
    {


        public int TowingCapacity { get; set; }
        public int TowWeight { get; set; }

        public Truck() : base()
        {
            TowingCapacity = GetTowingCapacity();
            TowWeight = GetTowWeight();
            HorsePower = GetHorsePower();
            Acceleration = GetAcceleration();
        }

        

        public Truck(int towingCapacity, int towWeight, int horsePower) : base()
        {
            this.TowingCapacity = towingCapacity;
            this.TowWeight = towWeight;
            this.HorsePower = horsePower;
        }

        public static int GetTowWeight()
        {
            return Random.Next(4000, 12000);
        }

        public static int GetTowingCapacity()
        {
            return Random.Next(500, 10000);
        }

        public int GetHorsePower()
        {
            return Random.Next(200, 600);
        }

        public override double GetAcceleration()
        {
            return ((HorsePower * HpToFootPoundPerSecond) / TowWeight);
        }

        public override string ToString()
        {
            return base.ToString() + $"\t{TowWeight}\t{TowingCapacity}\t\t{Acceleration}ft/s²";
        }
    }
}
