using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Tb_M_Employee")]
    public class Employee
    {
        //use lazy loading without proxies- - -
/*        private Account _Account; 
        private ILazyLoader LazyLoader { get; set; }
        public Employee()
        {
        }

        private Employee(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }
        public Account Account
        {
            get => LazyLoader.Load(this, ref _Account);
            set => _Account = value;
        }*/
        //----end lazy



        [Key]
        [Required(ErrorMessage = "it must have a value")]
        public virtual String NIK { get; set; }
        [Required(ErrorMessage = "it must have a value")]
        public virtual String FirsthName { get; set; }
        [Required(ErrorMessage = "it must have a value")]
        public virtual String LastName { get; set; }
        [Phone(ErrorMessage ="It's must as Phone number , pelease check your value")]
        public virtual String Phone { get; set; }
        public virtual DateTime BirthDate { get; set; }
        [Range(4600000, 50000000, ErrorMessage = "length of value must start from 4.600.000 to 50.000.000")]
        public int Salary { get; set; }
        [Required(ErrorMessage = "it must have a value")]
        [EmailAddress(ErrorMessage ="it's must as Email value, please rechek your typing value, use @ symbol for representations domain after mailName")]
        public virtual String Email{ get; set; }
        public Gender Gender { get; set; }
        // [JsonIgnore]
        public virtual Account Account { get; set; }  //one to one with Account
    }


    }
public enum Gender
{ 
    Male,
    Female
}