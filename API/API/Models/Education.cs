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
        [Required(ErrorMessage = " it must have a value")]
        public int Id { get; set; }
        [Required(ErrorMessage = " it must have a value")]
        public String Degree { get; set; }
        [Required(ErrorMessage = " it must have a value")]
        public float GPA { get; set; }
        [Required(ErrorMessage = " it must have a value")]
        [ForeignKey("University")]
        public int University_Id { get; set; }
        public University University{ get; set; }
        public ICollection<Profiling> Profiling { get; set; }

    }
}
