using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Tb_M_Profiling")]

    public class Profiling
    {
        [Key]
        [ForeignKey("Account")]
        [Required(ErrorMessage = "it must have a value")]
        public virtual String NIK { get; set; }
        [Required(ErrorMessage = "it must have a value")]
        [ForeignKey("Education")]
        public virtual int Education_Id { get; set; }
        public virtual Education Education { get; set; }
        public virtual Account Account { get;set; } 
    }
}
