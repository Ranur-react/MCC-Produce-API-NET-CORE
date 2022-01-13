using API.Base;
using API.Models;
using API.Models.ViewModel;
using API.Repository.Data;
using Castle.Core.Configuration;
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
        [Route("TestCors")]
        [HttpGet]
        public ActionResult TestCors() {
            return Ok("test Cors berhasil guys");
        }
        [Route("RegisteredData/{frontend}")]
        [HttpGet]
        public ActionResult RegisteredData(String frontend)
        {

            try
            {
                var result = employeeRepository.RegisteredData();
                if (result.Count() > 0)
                {
                    if (frontend == "1")
                    {
                        return Ok(new ApiRespondForm  { Status = StatusCodes.Status200OK, Results=result, Message= $" {result.Count()} Data Berhasil Didapatkan {frontend}" });
                    }
                    else { 
                        return Ok(result);
                    
                    }
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
        }
       
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
                        return BadRequest(new { status = StatusCodes.Status406NotAcceptable, result, message = "Pastikan Nomor Handphone Milikmu atau Belum Pernah Digunakan " });
                    }
                    else if (result == 2)
                    {
                        return BadRequest(new { status = StatusCodes.Status406NotAcceptable, result, message = "Pastikan  Email Belum Pernah Digunakan" });
                    }
                    else
                    {
                        return Ok(new { status = StatusCodes.Status201Created, result, message = "Data Berhasil Didaftarkan" });
                    }
                }
                else
                {
                    return BadRequest(new { status = StatusCodes.Status406NotAcceptable, result, message = $" Data gagal Ditambahkan Sudah ada di dalam database" });
                }

            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errors = e.Message });
            }

        }
    }
}
