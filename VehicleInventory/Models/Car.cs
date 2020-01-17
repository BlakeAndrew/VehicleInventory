using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleInventory.Models
{
    public class Car : Vehicle
    {
        public int CarID { get; set; }
        public int Weight { get; set; }
        public Car() : base()
        {
            Weight = GetWeight();
            HorsePower = GetHorsePower();
            Acceleration = GetAcceleration();
        }

        public Car(int weight, int horsePower) : base()
        {
            this.Weight = weight;
            this.HorsePower = horsePower;
        }

        public static int GetWeight()
        {
            return Random.Next(800, 2000);
        }

        public int GetHorsePower()
        {
            return Random.Next(150, 750);
        }

        public override double GetAcceleration()
        {
            return ((HorsePower * HpToFootPoundPerSecond) / Weight);
        }

        public override string ToString()
        {
            return base.ToString() + $"\t{Weight}\t\t\t{Acceleration}ft/s²";
        }
    }
}
