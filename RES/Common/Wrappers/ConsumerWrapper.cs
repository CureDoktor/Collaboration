using Common.DataModel;
using Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Wrappers
{
    public class ConsumerWrapper : IObserver
    {
        public Consumer Consumer { get; set; }
        private IWriteMeasurementToDb writer;
        public bool IsConsumerOn { get; set; }
        private object padlock = new object();
        public ConsumerWrapper(Consumer consumer, IWriteMeasurementToDb writer)
        {
            Consumer = consumer;
            this.writer = writer;
            IsConsumerOn = true;
            Task.Factory.StartNew(() => ConsumerTask());
        }

        private async void ConsumerTask()
        {
            while(true)
            {
                if(IsConsumerOn)
                {
                    writer.WriteMeasurement(Consumer.ID, Consumer.Consumption);
                }
                await Task.Delay(1000 * 60);
            }
        }

        public void Notify(double value)
        {
            lock (padlock)
            {
                IsConsumerOn = value > 0;
            }
            
        }
    }
}
