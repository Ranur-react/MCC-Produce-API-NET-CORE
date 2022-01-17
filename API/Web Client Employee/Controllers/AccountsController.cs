using API.Models;
using API.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Client_Employee.Base;
using Web_Client_Employee.Models;
using Web_Client_Employee.Repositories.Data;
namespace Web_Client_Employee.Controllers
{
    public class AccountsController : BaseController<Account, AccountRepository, string>
    {
        private readonly AccountRepository accountRepository;

        public AccountsController(AccountRepository repository) : base(repository)
        {
            this.accountRepository = repository;

        }
        
        public IActionResult Index()
        {
            return View();
        }
            
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index","Logins");
        }
        [HttpPost]
        public async Task<IActionResult> Auth(LoginForm login)
        {
            var jwtToken = await accountRepository.Auth(login);
            var token = jwtToken.IdToken;

            if (token == null)
            {
                return RedirectToAction("index","Logins");
            }
            HttpContext.Session.SetString("JWToken", token);

            /*            HttpContext.Session.SetString("JWToken", token);
                        HttpContext.Session.SetString("Name", jwtHandler.GetName(token));
                        HttpContext.Session.SetString("ProfilePicture", "assets/img/theme/user.png");*/

            return RedirectToAction("index", "Dashboard");
        }
        
        public IActionResult Register(string src)
        {
            ViewData["src"] = src;
            ViewData["WelComeTitle"] = src == "admin" ? "Add New Employees" : "Welcomes Candiadtes Let's Join with us " ;
            return View();
        }
        [HttpPost]
        public ActionResult<Object> AuthLogin(LoginForm entity)
        {
            var result = accountRepository.AuthJson(entity);
            try
            {
                if (result.idToken != null) {
                    HttpContext.Session.SetString("JWToken", result.idToken);
                }
                return Json(result);

            }
            catch (Exception e)
            {

                return Json(new { Message = e.Message });
            }
        }

        [HttpPost]
        public  ActionResult<Object> RegisterNew(RegisterForm entity)
        {
            var result =  accountRepository.Register(entity);
            try
            {
                return Json(result);

            }
            catch (Exception e)
            {

                return Json(new { Message = e.Message });
            }
        }
    }
}
