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
    public class ReligionsController : ControllerBase
    {
        private readonly ReligionRepository religionRepository;
        public ReligionsController(ReligionRepository religionRepository) {
            this.religionRepository = religionRepository;
        }
        [HttpGet]
        public ActionResult Get() {
            return Ok(religionRepository.Get());
        }
    }
}
