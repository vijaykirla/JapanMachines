using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JapanUsedMachines.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public bool IsUserAuthenticated { get; set; }
    }
}