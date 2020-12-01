﻿using System;
using System.Text;

namespace Parking
{
    public class Car
    {
        public Car(string manufacturer, string model, int year)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Year = year;
        }

        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"{this.Manufacturer} {this.Model} ({this.Year})");

            return sb.ToString().TrimEnd();
        }
    }
}
