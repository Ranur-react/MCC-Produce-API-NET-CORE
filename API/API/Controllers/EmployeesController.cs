﻿using API.Context;
using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeRepository employeeRepository;
        private readonly MyContext myContext;
        public EmployeesController(EmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var result = employeeRepository.Get();
                if (result != null)
                {
                    return Ok(new { status = StatusCodes.Status200OK, result, message = "Data Berhasil Didapatkan" });
                }
                else
                {
                    return BadRequest(new { status = StatusCodes.Status204NoContent, result, message = "tidak ada indikasi data ditemukan" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errorMessage = e.Message });

            }
        }
        [HttpGet("{NIK}")]
        public ActionResult Get(String NIK)
        {

            try
            {
                /* // - --  -- -carar ribet satu
                 var status = 0;
                 var result = employeeRepository.Get(NIK);
                 var message = "";

                 if (result != null)
                 {
                     status = StatusCodes.Status200OK;
                     message = "Data Ditemukan";
                 }
                 else {
                     status = StatusCodes.Status204NoContent;
                     message= "Data Tidak Ditemukan";
                 }
                 var json = new 
                 {
                     status,
                     result,
                     message
                 };
                 string jsonString = JsonConvert.SerializeObject(json);
                 return Ok(json);*/

                //--------------cara simple 
                var result = employeeRepository.Get(NIK);
                if (result != null)
                {
                    return Ok(new { status = StatusCodes.Status200OK, result, message = "Data Ditemukan" });
                }
                else
                {
                    return BadRequest(new { status = StatusCodes.Status204NoContent, result, message = "tidak ada indikasi data ditemukan" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errorMessage = e.Message });

            }

        }
        [HttpPost]
        public ActionResult Post(Employee employee)
        {
            try
            {

                var result = employeeRepository.Insert(employee);
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
                        return Ok(new { status = StatusCodes.Status201Created, result, message = "Data Berhasil Tersimpan" });
                    }
                }
                else
                {
                    return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = $" Data NIK : {employee.NIK} gagal Ditambahkan Sudah ada di dalam database" });
                }

            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errorMessage = e.Message });
            }

        }
        [HttpPut("{NIK}")]
        public ActionResult Put(string NIK, Employee employee)
        {
            try
            {
                var result = employeeRepository.Update(NIK, employee);
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
                        return Ok(new { status = StatusCodes.Status200OK, result, message = "Data Berhasil Diubah" });
                    }


                }
                else
                {
                    return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = $" Data NIK {NIK} Tidak ditemukan  atau sudah dihapus" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errorMessage = NIK+"----"+e.Message });
            }
        }

        [HttpDelete("{NIK}")]
        public ActionResult Delete(string NIK)
        {
            try
            {
                var result = employeeRepository.Delete(NIK);
                if (result > 0)
                {
                    return Ok(new { status = StatusCodes.Status200OK, result, message = "Data Berhasil Dihapus" });
                }
                else
                {
                    return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = $" Data NIK {NIK} Tidak ditemukan  atau sudah dihapus" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errorMessage = e.Message });
            }
        }
    }


}