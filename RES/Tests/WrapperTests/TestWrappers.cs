using Common.DataModel;
using Common.Repository;
using Common.Wrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tests.WrapperTests
{
    [TestClass]
    public class TestWrappers
    {
        [TestMethod]
        [DataRow(1)]
        [DataRow(-1)]
        [DataRow(0)]
        public void TestBatteryWrapperNotify(double mode)
        {
            IWriteMeasurementToDb mock = new WriteMeasurementsMock();
            BatteryWrapper batteryWrapper = new BatteryWrapper(new Battery(100, 100, "test"), mock);

            batteryWrapper.Notify(mode);

            Assert.IsTrue(batteryWrapper.Mode == mode);
        }

        [TestMethod]
        public void TestBatteryWrapperTask1()
        {
            IWriteMeasurementToDb mock = new WriteMeasurementsMock();
            BatteryWrapper batteryWrapper = new BatteryWrapper(new Battery(100, 100, "test"), mock);
            batteryWrapper.Mode = 1;
            Thread.Sleep(100);
            Assert.IsTrue(((WriteMeasurementsMock)mock).IsWriterCalled);
        }

        [TestMethod]
        public void TestBatteryWrapperTask_1()
        {
            IWriteMeasurementToDb mock = new WriteMeasurementsMock();
            BatteryWrapper batteryWrapper = new BatteryWrapper(new Battery(100, 100, "test"), mock);
            batteryWrapper.Mode = -1;
            Thread.Sleep(100);
            Assert.IsTrue(((WriteMeasurementsMock)mock).IsWriterCalled);
        }

        [TestMethod]
        public void TestBatteryWrapperTask0()
        {
            IWriteMeasurementToDb mock = new WriteMeasurementsMock();
            BatteryWrapper batteryWrapper = new BatteryWrapper(new Battery(100, 100, "test"), mock);
            batteryWrapper.Mode = 0;
            Thread.Sleep(100);
            Assert.IsFalse(((WriteMeasurementsMock)mock).IsWriterCalled);
        }

        [TestMethod]
        [DataRow(312)]
        [DataRow(0)]
        public void TestConsumerNotify(double value)
        {
            IWriteMeasurementToDb mock = new WriteMeasurementsMock();
            ConsumerWrapper consumerWrapper = new ConsumerWrapper(new Consumer(100, "test"), mock);

            consumerWrapper.Notify(value);

            if(value > 0)
            {
                Assert.IsTrue(consumerWrapper.IsConsumerOn);
            }
            else
            {
                Assert.IsFalse(consumerWrapper.IsConsumerOn);
            }
        }

        [TestMethod]
        public void TestConsumerWrapperTask()
        {
            IWriteMeasurementToDb mock = new WriteMeasurementsMock();
            ConsumerWrapper consumerWrapper = new ConsumerWrapper(new Consumer(100, "test"), mock);
            consumerWrapper.IsConsumerOn = true;
            Thread.Sleep(100);
            Assert.IsTrue(((WriteMeasurementsMock)mock).IsWriterCalled);
        }

        [TestMethod]
        public void TestSolarPanelNotify()
        {
            IWriteMeasurementToDb mock = new WriteMeasurementsMock();
            SolarPanelWrapper panelWrapper = new SolarPanelWrapper(new SolarPanel(100, "test"), mock);

            panelWrapper.Notify(50);

            Assert.IsTrue(panelWrapper.Sunlight == 50);
        }

        [TestMethod]
        public void TestSolarPanelWrapperTask()
        {
            IWriteMeasurementToDb mock = new WriteMeasurementsMock();
            SolarPanelWrapper panelWrapper = new SolarPanelWrapper(new SolarPanel(100, "test"), mock);   
            Thread.Sleep(100);
            Assert.IsTrue(((WriteMeasurementsMock)mock).IsWriterCalled);
        }
    }
}
