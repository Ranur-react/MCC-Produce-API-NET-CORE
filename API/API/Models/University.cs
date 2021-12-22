using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Tb_M_University")]

    public class University
    {
        [Required(ErrorMessage = "{Id} it must have a value")]
        public int Id{ get; set; }
        public String UniversityName { get; set; }
        public ICollection<Education> Education { get; set; }
    }
}
