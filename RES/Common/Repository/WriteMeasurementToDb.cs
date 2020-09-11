using Common.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository
{
    public class WriteMeasurementToDb : IWriteMeasurementToDb
    {
        public void WriteMeasurement(string componentId, double value)
        {
            Measurement m = new Measurement(componentId, value);

            try
            {
                using (ShesDbContext context = new ShesDbContext())
                {
                    context.Measurements.Add(m);
                    context.SaveChanges();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error while writing measurement to db. " + e.Message);
            }
        }
    }
}
