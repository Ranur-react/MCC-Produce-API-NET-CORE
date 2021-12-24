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
        public virtual int Id { get; set; }
        [Required(ErrorMessage = " it must have a value")]
        public virtual String Degree { get; set; }
        [Required(ErrorMessage = " it must have a value")]
        public virtual float GPA { get; set; }
        [Required(ErrorMessage = " it must have a value")]
        [ForeignKey("University")]
        public virtual int University_Id { get; set; }
        public virtual University University{ get; set; }
        public virtual ICollection<Profiling> Profiling { get; set; }

    }
}
