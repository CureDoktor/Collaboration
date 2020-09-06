using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataModel
{
    public class Measurement
    {
        [Key]
        public int Id { get; set; }
        public string Component { get; set; }
        public double Value { get; set; }
        public DateTime TimeStamp { get; set; }
        public Measurement()
        {
            
        }

        public Measurement(string component, double value)
        {
            Component = component;
            Value = value;
            TimeStamp = DateTime.Now;
        }
    }
}
