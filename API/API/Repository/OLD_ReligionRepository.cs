using API.Context;
using API.Models;
using API.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class OLD_ReligionRepository : IReligionRepository
    {
        private readonly MyContext myContext; //connections
        public OLD_ReligionRepository(MyContext myContext) {
            this.myContext = myContext;
        }
        public int Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Religion> Get()
        {
            return myContext.Religions.ToList(); //get data from entity with Context names
        }

        public Religion Get(string id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Religion religion)
        {
            throw new NotImplementedException();
        }

        public int Update(Religion religion)
        {
            throw new NotImplementedException();
        }
    }
}
