using API.Base;
using API.Models;
using API.Repository.Data;
using Microsoft.AspNetCore.Authorization;
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
    public class RolesController : BaseController<Role, RoleRepository, int>
    {
        private readonly RoleRepository ruleRepository;

        public RolesController(RoleRepository ruleRepository) : base(ruleRepository)
        {
            this.ruleRepository = ruleRepository;
        }

        [Authorize(Roles = "Director")]
        [HttpPut]
        public override ActionResult<Role> Put(Role entity) { 
            return base.Put(entity);
        }
        
    }
}
