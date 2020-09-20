using Common.ComponentsCreators;
using Common.DataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Creators
{
    [TestClass]
    public class CreatorsTests
    {
        [TestMethod]
        [DataRow("batTest", 123, 423)]
        public void TestBatteryCreatorOK(string id, double capacity, double maxPower)
        {
            BatteryCreator creator = new BatteryCreator();

            Battery result = creator.Create(id, maxPower, capacity);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [DataRow("", 123, 423)]
        [DataRow("batTest", 0, 423)]
        [DataRow("batTest", 123, 0)]
        [DataRow("", 0, 0)]
        [DataRow("asdfasdf", 0, 0)]
        public void TestBatteryCreatorError(string id, double capacity, double maxPower)
        {
            BatteryCreator creator = new BatteryCreator();

            Battery result = creator.Create(id, maxPower, capacity);

            Assert.IsNull(result);
        }


        [TestMethod]
        public void TestSolarPanelCreatorOk()
        {
            SolarPanelCreator creator = new SolarPanelCreator();
            SolarPanel result = creator.Create("asiduf", 2345);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [DataRow("", 123)]
        [DataRow("test", 0)]
        public void TestSolarPanelCreatorError(string id, double maxPower)
        {
            SolarPanelCreator creator = new SolarPanelCreator();
            SolarPanel result = creator.Create(id, maxPower);

            Assert.IsNull(result);
        }


        [TestMethod]
        [DataRow("test", 123)]
        public void TestConsumerCreatorOk(string id, double consumption)
        {
            ConsumerCreator creator = new ConsumerCreator();
            Consumer result = creator.Create(id, consumption);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [DataRow("", 123)]
        [DataRow("test", 0)]
        public void TestConsumerCreatorError(string id, double consumption)
        {
            ConsumerCreator creator = new ConsumerCreator();
            Consumer result = creator.Create(id, consumption);

            Assert.IsNull(result);
        }
    }
}
