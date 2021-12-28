using API.Context;
using API.Models;
using API.Models.HelperModel;
using API.Models.ViewModel;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using MimeKit;
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
        public int  SendMail(MailContent mailContent) {
            try
            {
                MimeMessage message = new MimeMessage();

                MailboxAddress from = new MailboxAddress("noreply",
                "dumy@gunungmas-seluler.com");
                message.From.Add(from);

                MailboxAddress to = new MailboxAddress(mailContent.body,
                mailContent.Email);
                message.To.Add(to); 

                message.Subject = "OTP Lupa Password";
                BodyBuilder bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = $"<h2>OTP : {mailContent.Token}</h2>" +
                    $"<br>" +
                    $"<p align=\"center\">Masukan OTP di halaman ganti password sebelum {mailContent.TimeNow} agar password anda dapat anda ganti</p>";
                message.Body = bodyBuilder.ToMessageBody();
                SmtpClient client = new SmtpClient();
                client.Connect("mail.gunungmas-seluler.com", 465, true);
                client.Authenticate("dumy@gunungmas-seluler.com", "Dumy0@@@");
                client.Send(message);
                client.Disconnect(true);
                client.Dispose();
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }
        }
        public Employee CheckDataEmployee(String param) {
            var respond = myContext.Employees.Where(e => e.Email == param || e.Phone == param || e.NIK == param).FirstOrDefault();
            return respond;
        }
        public Account CheckDataAccount(String param)
        {
            var respond = myContext.Accounts.Find(param);
            return respond;
        }

        public int ForgotPassword(MailForm mailForm) {
            var checkEmail = CheckDataEmployee(mailForm.Email);
            if (checkEmail != null)
            {
                var tokenGenerate = GenerateToken();
                var checkAccount = CheckDataAccount(checkEmail.NIK);
                if (checkAccount != null)
                {
                    myContext.Entry(checkAccount).State = EntityState.Detached;
                }

                checkAccount.OTP= tokenGenerate;
                var timeNow = DateTime.Now.AddMinutes(5);
                checkAccount.ExpiredToken= timeNow;
                checkAccount.IsUsed= true;
                myContext.Entry(checkAccount).State = EntityState.Modified;
                var dbRespond= myContext.SaveChanges();

                var mailContent = new MailContent {
                    Email = checkEmail.Email,
                    TimeNow = timeNow,
                    Token = tokenGenerate,
                    body = $"{checkEmail.LastName},{checkEmail.FirsthName} "
                };
                //panggil Mail sender disini
                var respond =SendMail(mailContent);
                
                switch (respond) {
                    case 1:
                        return dbRespond;
                    default:
                        return 3;
                }
            }
            else { 
                return 2;
            
            }
        }
        public int ChangePassword(ChangePasswordForm cForm)
        {
            try
            {
                var dataAccount = CheckDataAccount(CheckDataEmployee(cForm.Email).NIK);
                if (dataAccount.OTP != cForm.OTP)
                {
                    return 4;
                }
                else
                {
                    if (dataAccount.ExpiredToken < DateTime.Now)
                    {
                        return 3;
                    }
                    else
                    {
                        if (!dataAccount.IsUsed)
                        {
                            return 2;
                        }
                        else
                        {
                            if (dataAccount != null)
                            {
                                myContext.Entry(dataAccount).State = EntityState.Detached;
                            }

                            dataAccount.Password = BCrypt.Net.BCrypt.HashPassword(cForm.Password);
                            dataAccount.IsUsed = false;
                            myContext.Entry(dataAccount).State = EntityState.Modified;
                            return myContext.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }

        }
            public int GenerateToken() {
            int _min = 111111;
            int _max = 999999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        } 
        public int Login(LoginForm loginForm)
        {
            var checkEmail = myContext.Employees.
                Where(e => e.Email == loginForm.Email|| e.Phone == loginForm.Email).FirstOrDefault();
            if (checkEmail != null)
            {
                var getPassword = myContext.Accounts.Where(e => e.NIK == checkEmail.NIK).FirstOrDefault();
                bool checkPassword = BCrypt.Net.BCrypt.Verify(loginForm.Password, getPassword.Password);
                if (checkPassword)
                {
                    return 1;
                }
                else
                {
                    return 3;
                }
            }
            else
            {
                return 2;
            }
        }


    }
}
