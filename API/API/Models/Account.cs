﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Tb_M_Account")]

    public class Account
    {
        [Key]
        [ForeignKey("Employee")]
        [Required(ErrorMessage = "it must have a value")]
        public virtual String NIK { get; set; }
        [Required(ErrorMessage = "it must have a value")]
      /*  [RegularExpression(@"[0-9][a-z]+[A-Z].{8,15}[!@#$%^&*()_+=\[{\]};:<>|./?,-]", ErrorMessage = "Passwor must Containe one Uppercase,One Lower,number,and one  symbol must more then 8 Case Caracter")]*/
        public virtual String Password { get; set; }
        public virtual Profiling Profiling { get; set; }
        [JsonIgnore]
        public virtual Employee Employee { get; set; }
    }
}
