using JapanUsedMachines.Core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JapanUsedMachines.Core;

namespace JapanUsedMachines.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        JapanUsedMachinesDBContext context = new JapanUsedMachinesDBContext();
       
        public bool IsUserAvailable(User user)
        {
            var result = (from r in context.Users where (r.UserName == user.UserName && r.Password==user.Password) select r).FirstOrDefault();
            if (result != null)
                return true;
            else
                return false;
        }
    }
}