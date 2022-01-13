using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Web_Client_Employee.Models
{
    public class EmployeeC
    {
        [Required(ErrorMessage = "it must have a value")]
        public virtual String NIK { get; set; }
        [Required(ErrorMessage = "it must have a value")]
        public virtual String FirsthName { get; set; }
        [Required(ErrorMessage = "it must have a value")]
        public virtual String LastName { get; set; }
        [Phone(ErrorMessage = "It's must as Phone number , pelease check your value")]
        public virtual String Phone { get; set; }
        public virtual DateTime BirthDate { get; set; }
        [Range(4600000, 50000000, ErrorMessage = "length of value must start from 4.600.000 to 50.000.000")]
        public int Salary { get; set; }
        [EmailAddress(ErrorMessage = "it's must as Email value, please rechek your typing value, use @ symbol for representations domain after mailName")]
        public virtual String Email { get; set; }
        public Gender Gender { get; set; }
    }
    public enum Gender
    {
        Male,
        Female
    }

}
