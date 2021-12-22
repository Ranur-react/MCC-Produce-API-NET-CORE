using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Tb_M_Account")]

    public class Account
    {
        [Key]
        [ForeignKey("Employee")]
        [Required(ErrorMessage = "it must have a value")]
        public String NIK { get; set; }
        [Required(ErrorMessage = "it must have a value")]
        [RegularExpression(@"[a-z]+[A-Z]", ErrorMessage = "A User Name must consist of lowercase letters")]
        public String Password { get; set; }
        public Profiling Profiling { get; set; }
        public Employee Employee { get; set; }
    }
}
