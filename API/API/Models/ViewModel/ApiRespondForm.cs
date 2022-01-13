using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.ViewModel
{
    public class ApiRespondForm
    {
        public virtual int Status { get; set; }
        public virtual IEnumerable<Object> Results { get; set; }
        public virtual String Message { get; set; }


    }
}
