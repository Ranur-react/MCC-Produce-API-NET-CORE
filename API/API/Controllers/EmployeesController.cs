using API.Base;
using API.Models;
using API.Models.ViewModel;
using API.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController<Employee, EmployeeRepository, String>
    {
        private readonly EmployeeRepository employeeRepository;
        public EmployeesController(EmployeeRepository employeeRepository) : base(employeeRepository)
        {
            this.employeeRepository= employeeRepository;
        }
      /*  [Route("Users")]
        [HttpGet]
        public ActionResult Users()
        {

            try
            {
                var result = employeeRepository.GetAccount();
                if (result.Count() > 0)
                {
                    return Ok(new { status = StatusCodes.Status200OK, result, message = $" {result.Count()} Data Berhasil Didapatkan" });
                }
                else
                {
                    return BadRequest(new { status = StatusCodes.Status204NoContent, result, message = $"tidak ada indikasi data ditemukan di [{ControllerContext.ActionDescriptor.ControllerName}] silahkan tambah data" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errorMessage = e.Message });

            }
        }*/
        [Route("Register")]
        [HttpPost]
        public ActionResult Register(RegisterForm register)
        {
            try
            {
                var result = employeeRepository.Register(register);
                if (result > 0)
                {
                    if (result == 3)
                    {
                        return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = "Pastikan Nomor Handphone Milikmu atau Belum Pernah Digunakan " });
                    }
                    else if (result == 2)
                    {
                        return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = "Pastikan  Email Belum Pernah Digunakan" });
                    }
                    else
                    {
                        return Ok(new { status = StatusCodes.Status201Created, result, message = "Data Berhasil Didaftarkan" });
                    }
                }
                else
                {
                    return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = $" Data gagal Ditambahkan Sudah ada di dalam database" });
                }

            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errors = e.Message });
            }

        }
    }
}
