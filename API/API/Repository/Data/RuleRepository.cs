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
    public class RuleRepository : GeneralRepository<MyContext, Rule, int>
    {
        private readonly MyContext myContext;  //koneksi dengan database
        public RuleRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
