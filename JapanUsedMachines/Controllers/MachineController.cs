using JapanUsedMachines.Core.interfaces;
using JapanUsedMachines.Infrastructure.Repositories;
using JapanUsedMachines.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JapanUsedMachines.Controllers
{
    public class MachineController : Controller
    {
        private IMachineRepository _IMachineRepository = new MachineRepository();
        public ActionResult ListOfMachines()
        {
            ViewBag.LoadManchineTypes = LoadManchineTypes();
            ViewBag.LoadManufacturers = LoadManufacturers();
            List<Core.Machine> machineList = _IMachineRepository.GetAll();            
            return View(machineList);
        }
      
        public ActionResult AddNewMachine()
        {
            ViewBag.Machine = "Add New Machine";
            MachineModel machineModel = new MachineModel();
            machineModel.MachineTypes = LoadManchineTypes();
            machineModel.Manufacturers = LoadManufacturers();

            return View(machineModel);
        }
     
        [HttpPost]
        public ActionResult AddNewMachine(MachineModel machineModel)
        {
            //saving images
            if (machineModel.files.Count() > 0)
            {
                foreach (var file in machineModel.files)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        string filePath = Path.Combine(Server.MapPath("~/MachineImages"), machineModel.MachineId + "-"+ file.FileName);
                        
                        file.SaveAs(filePath);
                    }
                }
            }
            var Machine = new JapanUsedMachines.Core.Machine();
            Machine.MachineId = machineModel.MachineId;
            Machine.MachineType = machineModel.MachineType;
            Machine.Manufacturer = machineModel.Manufacturer;
            Machine.Price = machineModel.Price;
            Machine.Model = machineModel.Model;
            Machine.Year = machineModel.Year;
            Machine.RPM = machineModel.RPM;
            Machine.TableName = machineModel.Table;
            Machine.Description = machineModel.Description;
            Machine.MachinePic1 = machineModel.MachineId + "-" + machineModel.files[0].FileName;
            Machine.MachinePic2 = machineModel.MachineId + "-" + machineModel.files[1].FileName;
            Machine.MachinePic3 = machineModel.MachineId + "-" + machineModel.files[2].FileName;
            Machine.MachinePic4 = machineModel.MachineId + "-" + machineModel.files[3].FileName;
            Machine.CreatedDate = DateTime.Now;
            Machine.ModifiedDate = DateTime.Now;
            Machine.Sold = machineModel.Sold;

            _IMachineRepository.Save(Machine);


            return RedirectToAction("ListOfMachines");
        }


        public ActionResult MachineDetails(int Id)
        {
            ViewBag.LoadManchineTypes = LoadManchineTypes();
            ViewBag.LoadManufacturers = LoadManufacturers();
            Core.Machine machine= _IMachineRepository.FindById(Id);
            return View(machine);
        }
      
        public ActionResult EditMachine(int Id)
        {
            ViewBag.Machine = "Update Machine";
            Core.Machine machine = _IMachineRepository.FindById(Id);
            MachineModel machineModel = new MachineModel();

            machineModel.MachineId = machine.MachineId;
            machineModel.MachineType = machine.MachineType;
            machineModel.Manufacturer = machine.Manufacturer;
            machineModel.Price = machine.Price;
            machineModel.Model = machine.Model;
            machineModel.Year = machine.Year;
            machineModel.RPM = machine.RPM;
            machineModel.Table = machine.TableName;
            machineModel.Description = machine.Description;
            machineModel.Sold = machine.Sold;

            machineModel.MachineTypes = LoadManchineTypes();
            machineModel.Manufacturers = LoadManufacturers();

            return View("AddNewMachine", machineModel);
        }
      
        [HttpPost]
        public ActionResult EditMachine(MachineModel machineModel)
        {
            var Machine = new JapanUsedMachines.Core.Machine();
            Machine.MachineId = machineModel.MachineId;
            Machine.MachineType = machineModel.MachineType;
            Machine.Manufacturer = machineModel.Manufacturer;
            Machine.Price = machineModel.Price;
            Machine.Model = machineModel.Model;
            Machine.Year = machineModel.Year;
            Machine.RPM = machineModel.RPM;
            Machine.TableName = machineModel.Table;
            Machine.Description = machineModel.Description;
            Machine.CreatedDate = DateTime.Now;
            Machine.ModifiedDate = DateTime.Now;
            Machine.Sold = machineModel.Sold;

            _IMachineRepository.Edit(Machine);
            return RedirectToAction("ListOfMachines");

        }


        public ActionResult DeleteMachine(int Id,string MachineId)
        {
            //delete images from image MachineImages folder
            DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(Server.MapPath("~/MachineImages"));
            FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles("*" + MachineId + "*.*");

            foreach (FileInfo foundFile in filesInDir)
            {                
                System.IO.File.Delete(foundFile.FullName);
            }

            //delete from database
            _IMachineRepository.Delete(Id);

            return RedirectToAction("ListOfMachines");


        }

        public ActionResult GetMachineTypes(string listType,string OperationName)
        {
            ViewBag.LoadManchineTypes = LoadManchineTypes();
            ViewBag.LoadManufacturers = LoadManufacturers();
            List<Core.Machine> machineList = new List<Core.Machine>();
            var lstMachines = _IMachineRepository.GetAll();
            if (OperationName == "MachineType")
            {
                machineList = lstMachines.Where(p => p.MachineType == listType).ToList();
            }
            else if (OperationName == "Manufacturer")
            {
                machineList = lstMachines.Where(p => p.Manufacturer == listType).ToList();
            }
            else if (OperationName == "MachineIdSearch")
            {
                machineList = lstMachines.Where(p => p.MachineId == listType).ToList();
            }
            
            return PartialView("_MachinesList", machineList);
        }

        private List<SelectListItem> LoadManufacturers()
        {
            return new List<SelectListItem>()
            {                
                 new SelectListItem {Text="Mori Seiki",Value="1" },
                  new SelectListItem {Text="Taiyo",Value="2" },
                   new SelectListItem {Text="Kitagawa",Value="3" },
                    new SelectListItem {Text="Yamazaki",Value="4" },
                     new SelectListItem {Text="Toshiba",Value="5" },
                      new SelectListItem {Text="Dainichi CNC LATHE",Value="6" },
                       new SelectListItem {Text="Dainichi",Value="7" },
                   new SelectListItem {Text="OKK",Value="8" },
                   new SelectListItem {Text="CNC-500",Value="9" },
                   new SelectListItem {Text="Sodick",Value="10" },
                  new SelectListItem {Text="NTC(Nippei Toyama Corp)",Value="11" },
                   new SelectListItem {Text="Yasuda CNC JIG Boring",Value="12" },
                      new SelectListItem {Text="Mitsui Seiki",Value="13" },
                       new SelectListItem {Text="Kuraki",Value="14" },
                   new SelectListItem {Text="Komatsu",Value="15" },
                   new SelectListItem {Text="Toyoda Stat Bearing",Value="16" },
                   new SelectListItem {Text="Seibu Hitec",Value="17" },
                  new SelectListItem {Text="Okuma",Value="18" },
                   new SelectListItem {Text="Societe Genevoise (SIP)",Value="19" },

            };
        }

        private List<SelectListItem> LoadManchineTypes()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem {Text="Name of the Machines",Value="0" },
                new SelectListItem {Text="Lathe",Value="1" },
                new SelectListItem {Text="Jig Builder",Value="2" },
                new SelectListItem {Text="CNC",Value="3" },
                new SelectListItem {Text="Miling",Value="4" },
            };
        }
    }
}