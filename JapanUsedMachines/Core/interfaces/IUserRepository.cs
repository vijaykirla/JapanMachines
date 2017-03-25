using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JapanUsedMachines.Core.interfaces
{
    public interface IUserRepository
    {
        bool IsUserAvailable(User user);
    }
}