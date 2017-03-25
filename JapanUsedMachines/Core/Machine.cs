using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JapanUsedMachines.Core
{
    public class Machine
    {
        public int ID { get; set; }
        public string MachineId { get; set; }

        public string MachineType { get; set; }
        public string Manufacturer { get; set; }
        public string Price { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string RPM { get; set; }
        public string TableName { get; set; }
        public string Description { get; set; }
        public string MachinePic1 { get; set; }
        public string MachinePic2 { get; set; }
        public string MachinePic3 { get; set; }
        public string MachinePic4 { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Sold { get; set; }

    }
}