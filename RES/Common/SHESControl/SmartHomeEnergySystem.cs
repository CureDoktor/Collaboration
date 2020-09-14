using Common.DataModel;
using Common.Repository;
using Common.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Common.SHESControl
{
    public class SmartHomeEnergySystem
    {
        public List<IObserver> batteryObservers { get; set; }
        public List<IObserver> consumerObservers { get; set; }
        public List<IObserver> solarPanelObservers { get; set; }

        public SmartHomeEnergySystem(IWriteMeasurementToDb writer)
        {
            batteryObservers = new List<IObserver>();
            consumerObservers = new List<IObserver>();
            solarPanelObservers = new List<IObserver>();
            using (ShesDbContext context = new ShesDbContext())
            {
                foreach(Battery b in context.Batteries)
                    batteryObservers.Add(new BatteryWrapper(b, writer));

                foreach (Consumer c in context.Consumers)
                    consumerObservers.Add(new ConsumerWrapper(c, writer));

                foreach(SolarPanel sp in context.SolarPanels)
                    solarPanelObservers.Add(new SolarPanelWrapper(sp, writer));
            }
        }

        public void StartBatteryUpdateThread()
        {
            Task.Factory.StartNew(() => BatteryUpdateThread());
        }

        private async void BatteryUpdateThread()
        {
            while(true)
            {
                if (DateTime.Now.Hour >= 3 && DateTime.Now.Hour <= 6)
                {
                    batteryObservers.ForEach(x => x.Notify(-1));
                }
                else if(DateTime.Now.Hour >= 14 && DateTime.Now.Hour <= 17)
                {
                    batteryObservers.ForEach(x => x.Notify(1));
                }
                else
                {
                    batteryObservers.ForEach(x => x.Notify(0));
                }

                await Task.Delay(60000);
            }
        }

        public void UpdateSunlight(double newValue)
        {
            solarPanelObservers.ForEach(x => x.Notify(newValue));
        }

        public void TurnConsumerOnOff(double mode, string id)
        {
            var c = consumerObservers.FirstOrDefault(x => ((ConsumerWrapper)x).Consumer.ID == id);
            if(c != null)
            {
                c.Notify(mode);
            }
        }
    }
}
