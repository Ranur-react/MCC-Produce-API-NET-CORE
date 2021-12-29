using System;
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
        public virtual String Password { get; set; }
        public int OTP { get; set; }
        public DateTime ExpiredToken { get; set; }
        public Boolean IsUsed { get; set; }
        public virtual Profiling Profiling { get; set; }
        [JsonIgnore]
        public virtual Employee Employee { get; set; }
        public virtual ICollection<AccountRole> AccountRole { get; set; }

    }
}
