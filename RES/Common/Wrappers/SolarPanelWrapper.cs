using Common.DataModel;
using Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Wrappers
{
    public class SolarPanelWrapper : IObserver
    {
        private IWriteMeasurementToDb writer;
        private object padlock = new object();
        public SolarPanel SolarPanel { get; set; }
        public double Sunlight { get; set; }

        public SolarPanelWrapper(SolarPanel solarPanel, IWriteMeasurementToDb writer)
        {
            SolarPanel = solarPanel;
            this.writer = writer;
            Task.Factory.StartNew(() => SolarPanelTask());
        }

        public void Notify(double value)
        {
            lock(padlock)
            {
                Sunlight = value;
            }
        }

        private async void SolarPanelTask()
        {
            while (true)
            {
                double value = SolarPanel.MaxPower * (Sunlight / 100);
                writer.WriteMeasurement(SolarPanel.ID, value);
                await Task.Delay(1000 * 60);
            }
        }
    }
}
