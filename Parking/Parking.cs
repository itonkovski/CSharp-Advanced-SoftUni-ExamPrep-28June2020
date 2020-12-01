using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking()
        {
            this.data = new List<Car>();
        }

        public Parking(string type, int capacity)
            :this()
        {
            this.Type = type;
            this.Capacity = capacity;
        }

        public string Type { get; set; }
        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Car car)
        {
            if (this.data.Count + 1 <= this.Capacity)
            {
                this.data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Car currentCar = this.data
                .FirstOrDefault(c => (c.Manufacturer == manufacturer && c.Model == model));

            if (currentCar != null)
            {
                this.data.Remove(currentCar);
                return true;
            }
            return false;
        }

        public Car GetLatestCar()
        {
            if (this.data.Count == 0)
            {
                return null;
            }
            else
            {
                Car latestCar = this.data
                    .OrderByDescending(c => c.Year)
                    .FirstOrDefault();
                return latestCar;
            }
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car currentCar = this.data
                .FirstOrDefault(c => (c.Manufacturer == manufacturer && c.Model == model));

            if (currentCar != null)
            {
                return currentCar;
            }
            return null;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"The cars are parked in {this.Type}:");

            foreach (var car in this.data)
            {
                sb
                    .AppendLine($"{car}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
