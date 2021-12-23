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
    public class ProfilingsController : BaseController<Profiling, ProfilingRepository, int>
    {
        private readonly ProfilingRepository profilingRepository;
        public ProfilingsController(ProfilingRepository repository) : base(repository)
        {
            this.profilingRepository = repository;
        }
    }
}
