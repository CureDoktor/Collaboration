using Common.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ComponentsCreators
{
    public class SolarPanelCreator
    {
        public SolarPanel Create(string id, double maxPower)
        {
            if(string.IsNullOrEmpty(id))
            {
                Console.WriteLine("Id must not be empty. Please try again.");
                return null;
            }
            if(maxPower <= 0)
            {
                Console.WriteLine("Max power must be greater than 0. Please try again.");
                return null;
            }

            return new SolarPanel(maxPower, id);
        }
    }
}
