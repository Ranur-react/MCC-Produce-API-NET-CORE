using API.Base;
using API.Models;
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
    public class AccountRulesController : BaseController<AccountRule, AccountRuleRepository, int>
    {
        private readonly AccountRuleRepository accountRuleRepository1;

        public AccountRulesController(AccountRuleRepository accountRuleRepository) : base(accountRuleRepository)
        {
            this.accountRuleRepository1 = accountRuleRepository;
        }
    }
}
