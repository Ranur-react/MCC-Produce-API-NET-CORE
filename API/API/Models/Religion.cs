using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Tb_M_Religion")]

    public class Religion
    {
        public virtual String Id { get; set; }
        public virtual String Name { get; set; }
    }
}
