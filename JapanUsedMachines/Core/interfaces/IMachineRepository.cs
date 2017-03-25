using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapanUsedMachines.Core.interfaces
{
    public interface IMachineRepository
    {
        void Save(Machine machine);
        void Edit(Machine machine);
        Machine FindById(int Id);
        List<Machine> GetAll();
        void Delete(int Id);
    }
}
