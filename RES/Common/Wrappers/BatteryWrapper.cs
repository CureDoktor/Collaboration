using Common.DataModel;
using Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Wrappers
{
    public class BatteryWrapper : IObserver
    {
        public Battery Battery { get; set; }
        private IWriteMeasurementToDb writer;
        public double Mode { get; set; }

        private object padlock = new object();
        public BatteryWrapper(Battery battery, IWriteMeasurementToDb writer)
        {
            Battery = battery;
            this.writer = writer;
            Task.Factory.StartNew(() => BatteryTask());
        }

        private async void BatteryTask()
        {
            while(true)
            {
                if(Mode == 0)   //IDLE
                {

                }
                else if(Mode == 1)  //Producing
                {
                    writer.WriteMeasurement(Battery.ID, Battery.MaxPower);
                }
                else if(Mode == -1) //Consuming
                {
                    writer.WriteMeasurement(Battery.ID, -1 * Battery.MaxPower);
                }
                await Task.Delay(1000 * 60);
            }
        }

        public void Notify(double value)
        {
            lock(padlock)
            {
                Mode = value;
            }
        }
    }
}
