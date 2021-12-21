using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Tb_M_Employee")]
    public class Employee
    {
        [Key]
        public String NIK{ get; set; }
        /*[Required()]*/  /*its made that props be important and cant't empty in each diall of classs*/
        [Required(ErrorMessage = "FirsthName Tidak boleh kosong")]
        public String  FirsthName { get; set; }
        public String  LastName { get; set; }
        public String Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public int Salary { get; set; }
        public String Email{ get; set; }
        public Gender Gender { get; set; }
     }


    }
public enum Gender
{ 
    Male,
    Female
}