using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class ReligionRepository : GeneralRepository<MyContext, Religion, String>
    {
        public ReligionRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
