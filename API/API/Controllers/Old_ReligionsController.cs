using API.Repository;
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
    public class Old_ReligionsController : ControllerBase
    {
        private readonly OLD_ReligionRepository religionRepository;
        public Old_ReligionsController(OLD_ReligionRepository religionRepository) {
            this.religionRepository = religionRepository;
        }
        [HttpGet]
        public ActionResult Get() {
            return Ok(religionRepository.Get());
        }
    }
}
