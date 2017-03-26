using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using JapanUsedMachines.Models;
using JapanUsedMachines.Core;
using JapanUsedMachines.Core.interfaces;
using JapanUsedMachines.Infrastructure.Repositories;
using System.Web.Security;
using JapanUsedMachines.Filters;

namespace JapanUsedMachines.Controllers
{
    [Error]
    [Authorize]
    public class AccountController : Controller
    {
        IUserRepository _IUserRepository = new UserRepository();
        private UserModel _UserModel = new UserModel();


        [AllowAnonymous]
        public ActionResult Login()
        {          
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(User user)
        {
            var isUserAuthenticated =_IUserRepository.IsUserAvailable(user);
            if (isUserAuthenticated)
            {
                _UserModel.UserID = user.UserID;
                _UserModel.UserName = user.UserName;
                _UserModel.IsUserAuthenticated = isUserAuthenticated;

                Session["User"] = _UserModel;

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View();
            }
               
            
        }


    }
}