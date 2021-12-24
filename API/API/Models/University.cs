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
        public virtual int Id { get; set; }
        public virtual String UniversityName { get; set; }
        public virtual ICollection<Education> Education { get; set; }
    }
}
