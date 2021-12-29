using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Tb_M_AccountRule")]

    public class AccountRule
    {
        public int Id { get; set; }
        [ForeignKey("Rule")]
        public int Id_Rule { get; set; }
        [ForeignKey("Account")]
        public String Id_Account { get; set; }
        [JsonIgnore]
        public virtual Account Account { get; set; }
        public virtual Rule Rule { get; set; }

    }
}
