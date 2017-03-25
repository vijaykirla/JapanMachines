using JapanUsedMachines.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JapanUsedMachines.Infrastructure
{
    public class JapanUsedMachinesDBContext : DbContext
    {
        public JapanUsedMachinesDBContext()
            : base("name=JapanUsedMachinesDB")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Machine> Machines { get; set; }
    }
}