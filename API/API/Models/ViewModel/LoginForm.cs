using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.ViewModel
{
    public class LoginForm
    {
        [Required(ErrorMessage = "it must have a value")]
        public String Email { get; set; }
        [Required(ErrorMessage = "it must have a value")]
        public String Password { get; set; }

        public String Rule { get; set; }
    }
}
