using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interface
{
    interface IReligionRepository
    {
        IEnumerable<Religion> Get();
        Religion Get(String id);
        int Insert(Religion religion);
        int Update(Religion religion);
        int Delete(String id);
    }
}
