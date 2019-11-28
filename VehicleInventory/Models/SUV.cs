using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleInventory.Models
{
    public class SUV : Vehicle
    {
        public int Weight { get; set; }

        public SUV() : base()
        {
            Weight = GetWeight();
            HorsePower = GetHorsePower();
            Acceleration = GetAcceleration();
        }

        public SUV(int weight, int horsePower)
        {
            this.Weight = weight;
            this.HorsePower = horsePower;
        }

        public static int GetWeight()
        {
            return Random.Next(2000, 4000);
        }

        public override double GetAcceleration()
        {
            return ((HorsePower * HpToFootPoundPerSecond) / Weight);
        }

        public int GetHorsePower()
        {
            return Random.Next(150, 450);
        }

        public override string ToString()
        {
            return base.ToString() + $"\t{Weight}\t\t\t{Acceleration}ft/s²";
        }
    }
}
