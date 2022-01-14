using API.Models;
using API.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Client_Employee.Base;
using Web_Client_Employee.Models;
using Web_Client_Employee.Repositories.Data;

namespace Web_Client_Employee.Controllers
{
    [Authorize]
    public class EmployeesController : BaseController<Employee, EmployeeRepository, string>
    {
        private readonly EmployeeRepository employeeRepository;
        public EmployeesController(EmployeeRepository repository) : base(repository)
        {
            this.employeeRepository = repository;

        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Chart()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetRegistered()
        {
            var result = await employeeRepository.GetRegistered();
            return Json(result);
        }
    }
}
