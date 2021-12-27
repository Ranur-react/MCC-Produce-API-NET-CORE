using API.Context;
using API.Models;
using API.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, String>
    {
        private readonly MyContext myContext;  //koneksi dengan database

        public AccountRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
        public int Login(LoginForm loginForm) {
            var checkEmail = myContext.Employees.
                Where(e => e.Email == loginForm.Email).FirstOrDefault();
            if (checkEmail != null)
            {
                var getPassword= myContext.Accounts.Where(e => e.NIK ==checkEmail.NIK ).FirstOrDefault();
                bool checkPassword = BCrypt.Net.BCrypt.Verify(loginForm.Password, getPassword.Password);
                if (checkPassword)
                {
                    return 1;
                }
                else { 
                    return 3;
                }
            }
            else { 
            
            return 2;
            
            }
        }


    }
}
