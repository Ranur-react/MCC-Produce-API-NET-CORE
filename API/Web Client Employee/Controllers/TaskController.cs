using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Client_Employee.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Pokemon()
        {
            return View();
        }
        public IActionResult DataTable()
        {
            return View();
        }

    }
}
