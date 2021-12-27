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
    public class AccountsController : BaseController<Account, AccountRepository, String>
    {
        private readonly AccountRepository accountRepository;
        public AccountsController(AccountRepository accountRepository):base(accountRepository) {
            this.accountRepository = accountRepository;
        }
        [Route("Login")]
        [HttpPost]
        public ActionResult Login(LoginForm loginForm) {
            try
            {
                var result = accountRepository.Login(loginForm);
                if (result > 0)
                {
                    if (result == 3)
                    {
                        return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = "Akun ditemukan,Password salah" });
                    }
                    else if (result == 2)
                    {
                        return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = "Akun tidak ditemukan, email yang digunakan tidak terdaftar didatabase " });
                    }
                    else
                    {
                        return Ok(new { status = StatusCodes.Status201Created, result, message = "Login Berhasil" });
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
