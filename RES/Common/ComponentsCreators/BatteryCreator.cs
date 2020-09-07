using Common.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ComponentsCreators
{
    public class BatteryCreator
    {
        public Battery Create(string id, double maxPower, double capacity)
        {
            if (string.IsNullOrEmpty(id))
            {
                Console.WriteLine("Id must not be empty. Please try again.");
                return null;
            }
            if (maxPower <= 0)
            {
                Console.WriteLine("Max power must be greater than 0. Please try again.");
                return null;
            }
            if (capacity <= 0)
            {
                Console.WriteLine("Capacity must be greater than 0. Please try again.");
                return null;
            }

            return new Battery(maxPower, capacity, id);
        }
    }
}
