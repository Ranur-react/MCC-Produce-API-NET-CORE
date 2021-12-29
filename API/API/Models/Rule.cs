using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Tb_M_Rule")]
    public class Rule
    {
        public int Id { get; set; }
        public String Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<AccountRule> AccountRule { get; set; }

    }
}
