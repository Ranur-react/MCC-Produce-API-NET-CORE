using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.ViewModel
{
    public class Users
    {
        public String NIK { get; set; }
        public String FirsthName { get; set; }
        [Required(ErrorMessage = "it must have a value")]
        public String LastName { get; set; }
        public Gender Gender { get; set; }
        [Phone(ErrorMessage = "It's must as Phone number , pelease check your value")]
        public String Phone { get; set; }
        public DateTime BirthDate { get; set; }
        [Range(4600000, 50000000, ErrorMessage = "length of value must start from 4.600.000 to 50.000.000")]
        public int Salary { get; set; }
        [EmailAddress(ErrorMessage = "it's must as Email value, please rechek your typing value, use @ symbol for representations domain after mailName")]
        public String Email { get; set; }
        [Required(ErrorMessage = "it must have a value")]
  /*      [RegularExpression(@"[a-z]+[A-Z]+", ErrorMessage = "Passwor must Containe one Uppercase,One Lower,number,and one  symbol must more then 8 Case Caracter")]*/
        public String Password { get; set; }
        public String Degree { get; set; }
        [Required(ErrorMessage = " it must have a value")]
        public float GPA { get; set; }
        [Required(ErrorMessage = " it must have a value")]
        public String UniversityName { get; set; }

    }

}
