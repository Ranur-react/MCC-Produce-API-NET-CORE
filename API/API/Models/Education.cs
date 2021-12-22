using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Tb_M_Education")]

    public class Education
    {
        [Required(ErrorMessage = "{Id} it must have a value")]
        public int Id { get; set; }
        public String Degree { get; set; }
        public float GPA { get; set; }
        [ForeignKey("University")]
        public int Fk_University { get; set; }
        public University University{ get; set; }
        public ICollection<Profiling> Profiling { get; set; }

    }
}
