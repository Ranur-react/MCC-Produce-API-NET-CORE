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
        public String NIK { get; set; }
        [ForeignKey("Education")]
        public int Fk_Education { get; set; }
        public Education Education { get; set; }
        public Account Account { get;set; }
    }
}
