using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class AccountRuleRepository : GeneralRepository<MyContext, AccountRule, int>
    {
        private readonly MyContext myContext;  //koneksi dengan database

        public AccountRuleRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
