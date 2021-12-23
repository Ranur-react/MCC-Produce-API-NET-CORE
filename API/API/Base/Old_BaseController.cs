using API.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class Old_BaseController<Entity,Repository,Key>: ControllerBase
    where Entity:class
    where Repository : IRepository<Entity, Key>
    {
        private readonly Repository repository;

        public Old_BaseController(Repository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public ActionResult<Entity> Get()
        {
            var result = repository.Get();
            return Ok(result);
        }
    }
}
