using Common.Repository;
using Common.SHESControl;
using Common.Wrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tests.ShesTests
{
    [TestClass]
    public class ShesTests
    {
        [TestMethod]
        public void TestCtor()
        {
            IWriteMeasurementToDb mock = new WriteMeasurementsMock();
            SmartHomeEnergySystem shes = new SmartHomeEnergySystem(mock);

            Assert.IsNotNull(shes);
        }

        [TestMethod]
        public void TestSunlightChange()
        {
            IWriteMeasurementToDb mock = new WriteMeasurementsMock();
            SmartHomeEnergySystem shes = new SmartHomeEnergySystem(mock);

            shes.UpdateSunlight(0.80);

            shes.solarPanelObservers.ForEach(x => Assert.IsTrue(((SolarPanelWrapper)x).Sunlight == 0.80));
        }

        [TestMethod]
        public void TestConsumerOn()
        {
            IWriteMeasurementToDb mock = new WriteMeasurementsMock();
            SmartHomeEnergySystem shes = new SmartHomeEnergySystem(mock);

            string id = ((ConsumerWrapper)shes.consumerObservers[0]).Consumer.ID;
            shes.TurnConsumerOnOff(1, id);

            Assert.IsTrue(((ConsumerWrapper)shes.consumerObservers[0]).IsConsumerOn);
        }

        [TestMethod]
        public void TestConsumerOff()
        {
            IWriteMeasurementToDb mock = new WriteMeasurementsMock();
            SmartHomeEnergySystem shes = new SmartHomeEnergySystem(mock);

            string id = ((ConsumerWrapper)shes.consumerObservers[0]).Consumer.ID;
            shes.TurnConsumerOnOff(0, id);

            Assert.IsFalse(((ConsumerWrapper)shes.consumerObservers[0]).IsConsumerOn);
        }

        [TestMethod]
        public void TestBatteryThread()
        {
            IWriteMeasurementToDb mock = new WriteMeasurementsMock();
            SmartHomeEnergySystem shes = new SmartHomeEnergySystem(mock);
            shes.StartBatteryUpdateThread();
            Thread.Sleep(100);
            if (DateTime.Now.Hour >= 3 && DateTime.Now.Hour <= 6)
                shes.batteryObservers.ForEach(x => Assert.IsTrue(((BatteryWrapper)x).Mode == -1));
            else if (DateTime.Now.Hour >= 14 && DateTime.Now.Hour <= 17)
                shes.batteryObservers.ForEach(x => Assert.IsTrue(((BatteryWrapper)x).Mode == 1));
            else
                shes.batteryObservers.ForEach(x => Assert.IsTrue(((BatteryWrapper)x).Mode == 0));
        }
    }
}
