using Common.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ComponentsCreators
{
    public class ConsumerCreator
    {
        public Consumer Create(string id, double consumption)
        {
            if (string.IsNullOrEmpty(id))
            {
                Console.WriteLine("Id must not be empty. Please try again.");
                return null;
            }
            if (consumption <= 0)
            {
                Console.WriteLine("Consumption must be greater than 0. Please try again.");
                return null;
            }

            return new Consumer(consumption, id);
        }
    }
}
