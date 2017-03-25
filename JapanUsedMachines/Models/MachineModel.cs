using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JapanUsedMachines.Models
{
    public class MachineModel
    {
        public int ID { get; set; }
        public string MachineId { get; set; }

        public List<SelectListItem> MachineTypes { get; set; }
        public string MachineType { get; set; }

        public List<SelectListItem> Manufacturers { get; set; }
        public string Manufacturer { get; set; }
        public string Price { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string RPM { get; set; }
        public string Table { get; set; }
        public string Description { get; set; }
        public string MachinePic1 { get; set; }
        public string MachinePic2 { get; set; }
        public string MachinePic3 { get; set; }
        public string MachinePic4 { get; set; }

        public HttpPostedFileBase[] files { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Sold { get; set; }

        public string hiddenMachineText { get; set; }
        public string hiddenManufacturerText { get; set; }
    }


}