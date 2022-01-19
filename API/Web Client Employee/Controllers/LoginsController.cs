using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Client_Employee.Controllers
{
    public class LoginsController : Controller
    {

        public IActionResult Index(string returnUrl)
        {
            ViewData["returnUrl"] = returnUrl;
            ViewData["WelComeTitle"] = returnUrl == null ? "Login" : "Relogin" ;

            return View();
        }
    }
}
