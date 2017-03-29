using JapanUsedMachines.Core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JapanUsedMachines.Core;
using System.Collections;

namespace JapanUsedMachines.Infrastructure.Repositories
{
    public class MachineRepository : IMachineRepository
    {
        JapanUsedMachinesDBContext context = new JapanUsedMachinesDBContext();
        public void Delete(int Id)
        {
            Machine machine = context.Machines.Find(Id);
            context.Machines.Remove(machine);
            context.SaveChanges();
        }

        public void Edit(Machine machine)
        {  
            context.Entry(machine).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public Machine FindById(int Id)
        {
            var result = (from r in context.Machines where r.ID == Id select r).FirstOrDefault();
            return result;
        }

        public List<Machine> GetAll()
        {
            return context.Machines.ToList();
        }

        public void Save(Machine machine)
        {
            context.Machines.Add(machine);
            context.SaveChanges();
        }
    }
}