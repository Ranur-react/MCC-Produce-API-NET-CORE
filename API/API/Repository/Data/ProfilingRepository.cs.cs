using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class ProfilingRepository : GeneralRepository<MyContext, Profiling, int>
    {
        public ProfilingRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
