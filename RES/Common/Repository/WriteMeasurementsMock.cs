using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository
{
    public class WriteMeasurementsMock : IWriteMeasurementToDb
    {
        public bool IsWriterCalled { get; set; }
        public WriteMeasurementsMock()
        {
            IsWriterCalled = false;
        }
        public void WriteMeasurement(string id, double value)
        {
            IsWriterCalled = true;
        }
    }
}
