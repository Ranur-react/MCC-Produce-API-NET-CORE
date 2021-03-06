using API.Base;
using API.Models;
using API.Models.ViewModel;
using API.Repository.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<Account, AccountRepository, String>
    {
        private readonly AccountRepository accountRepository;
        public IConfiguration _Configuration;
        public AccountsController(AccountRepository accountRepository, IConfiguration configuration) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
            this._Configuration = configuration;

        }


        [Authorize]
        [HttpGet("TestJWT")]
        public ActionResult TestJWT()
        {
            return Ok("testing OK");
        }


        [Authorize(Roles="Employee,Director")]
        [HttpGet("TestJWTEmployeeDanDirectur")]
        public ActionResult TestJWTEmployeeDanDirectur()
        {
            return Ok("testing Employee OK");
        }


        [Authorize(Roles ="Director")]
        [HttpGet("TestJWTDirektur")]
        public ActionResult TestJWTDirektur()
        {
            return Ok("testing Direcutr OK");
        }


        [Authorize(Roles ="Employee")]
        [HttpGet("TestJWTEmployee")]
        public ActionResult TestJWTEmployee()
        {
            return Ok("testing Employee OK");
        }
        [Authorize(Roles = "Employee,Director")]
        [Route("AcountData/{Email}")]
        [HttpGet]
        public ActionResult AcountData(String Email)
        {

            try
            {
                var result = accountRepository.RegisteredData(Email);
             
              
                if (result != null)
                {
                    return Ok(new { status = StatusCodes.Status200OK, result, message = $" Data Berhasil Didapatkan" });
                }
                else
                {
                    return BadRequest(new { status = StatusCodes.Status204NoContent, result, message = $"tidak ada indikasi data ditemukan di [{ControllerContext.ActionDescriptor.ControllerName}]" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errorMessage = e.Message });

            }
        }
        [Route("ChangePassword")]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordForm cForm)
        {
            try
            {
                var result = accountRepository.ChangePassword(cForm);
                if (result > 0)
                {
                    if (result == 2)
                    {
                        return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = "Token Sudah digunakan, Kirim Token ulang" });
                    }
                    else if (result == 3)
                    {
                        return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = "Token Sudah kadaluarsa, Kirim Token ulang" });
                    }
                    else if (result == 4)
                    {
                        return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = "Token Salah , Check kembali atau coba kirim ulang" });
                    }
                    else
                    {
                        //panggil Mail sender disini
                        return Ok(new { status = StatusCodes.Status201Created, result, message = "Token benar, Password sudah berhasil dirubah" });
                    }
                }
                else
                {
                    return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = $" Data gagal diproses Sudah ada di dalam database" });
                }

            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errors = e.Message + "~Controller" });
            }
        }
        [Route("Forgot")]
        [HttpPost]
        public ActionResult Forgot(MailForm mailForm)
        {
            try
            {
                var result = accountRepository.ForgotPassword(mailForm);
                if (result > 0)
                {
                    if (result == 2)
                    {
                        return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = "Akun tidak ditemukan, email / phonsell yang digunakan tidak terdaftar didatabase " });
                    }
                    else if (result == 3)
                    {
                        return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = "OTP Gagal Dikirimkan ke Email mu, ulangi" });
                    }
                    else
                    {
                        return Ok(new { status = StatusCodes.Status201Created, result, message = "OTP Dikirimkan ke Email mu, Periksa Kotak Masuk atau folder SPAM di Email mu" });
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
        [Route("Logins")]
        [HttpPost]
        public ActionResult Logins(LoginForm loginForm)
        {
            try
            {

                var result = accountRepository.Login(loginForm);
                if (result > 0)
                {
                    if (result == 3)
                    {
                        return BadRequest(new RequestLoginsForms { status = StatusCodes.Status400BadRequest, result=result, message = "Akun ditemukan,Password salah" });
                    }
                    else if (result == 2)
                    {
                        return BadRequest(new RequestLoginsForms { status = StatusCodes.Status400BadRequest, result=result, message = "Akun tidak ditemukan, email yang digunakan tidak terdaftar didatabase " });
                    }
                    else
                    {
                        var get = accountRepository.RegisteredData(loginForm.Email).AccountRole;
                        var role = "";
                        int n = 0;
                        foreach (var item in get)
                        {
                            n++;
                            if (n == get.Count)
                            {
                                role += $"{item.Role.Name}";
                            }
                            else
                            {
                                role += $"{item.Role.Name},";

                            }
                        }
                        var data = new LoginForm
                        {
                            Email = loginForm.Email,
                            Role = role
                        };
                        var calaims = new List<Claim> {
                            new Claim("Email",data.Email),
                        };
                        foreach (var item in get)
                        {
                            calaims.Add(new Claim("roles", item.Role.Name));
                        }
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            _Configuration["Jwt:Issuer"],
                            _Configuration["Jwt:Audience"],
                            calaims,
                            expires: DateTime.UtcNow.AddMinutes(10),
                            signingCredentials: signIn

                            );
                        var idToken = new JwtSecurityTokenHandler().WriteToken(token);
                        calaims.Add(new Claim("TokenSecurity", idToken.ToString()));

                        return Ok(new RequestLoginsForms { status = StatusCodes.Status200OK, idToken = idToken, result=result, message = "Login Berhasil" });
                    }
                }
                else
                {

                    return BadRequest(new RequestLoginsForms { status = StatusCodes.Status400BadRequest, result=result, message = $" Data gagal Ditambahkan Sudah ada di dalam database" });
                }

            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errors = e.Message + "~Login Controller" });
            }
        }
        [Route("Login")]
        [HttpPost]
        public ActionResult Login(LoginForm loginForm)
        {
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
                        var get = accountRepository.RegisteredData(loginForm.Email).AccountRole;
                        var role = "";
                        int n = 0;
                        foreach (var item in get)
                        {
                            n++;
                            if (n == get.Count)
                            {
                                role += $"{item.Role.Name}";
                            }
                            else { 
                                role += $"{item.Role.Name},";

                            }
                        }
                        var data = new LoginForm
                        {
                            Email = loginForm.Email,
                            Role = role
                        };
                        var calaims = new List<Claim> {
                            new Claim("Email",data.Email),
                        };
                        foreach (var item in get)
                        {
                            calaims.Add(new Claim("roles", item.Role.Name));
                        }
                            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            _Configuration["Jwt:Issuer"],
                            _Configuration["Jwt:Audience"],
                            calaims,
                            expires: DateTime.UtcNow.AddMinutes(10),
                            signingCredentials: signIn

                            );
                        var idToken = new JwtSecurityTokenHandler().WriteToken(token);
                        calaims.Add(new Claim("TokenSecurity", idToken.ToString()));

                        return Ok(new JWTTokenVM  { Status = HttpStatusCode.OK, IdToken= idToken, Result= result, Message = "Login Berhasil" });
                    }
                }
                else
                {
                    return Ok(new JWTTokenVM { Status = HttpStatusCode.BadRequest,  Result = result, Message = "Login Gagal" });

                    //return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = $" Data gagal Ditambahkan Sudah ada di dalam database" });
                }

            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errors = e.Message + "~Login Controller" });
            }
        }
    }
}
