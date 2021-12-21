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
        public String NIK { get; set; }
        /*[Required()]*/  /*its made that props be important and cant't empty in each diall of classs*/
        /*[Required(ErrorMessage = "FirsthName harus ada data")]*/
        [StringLength(30,ErrorMessage ="Maximal 30 Karakter")]
        public String FirsthName { get; set; }
       /* [FileExtensions(Extensions = "txt,doc,docx,pdf", ErrorMessage = "Please upload valid format")]*/
        public String LastName { get; set; }
        [MaxLength(15,ErrorMessage ="Max length 15 Caracter")]
        [Phone(ErrorMessage ="Pastikan jenis karakter phonsel")]
        public String Phone { get; set; }
        public DateTime BirthDate { get; set; }
        [Range(4600000, 50000000, ErrorMessage = "Min 4600000 ~ 50000000")]
        public int Salary { get; set; }
        /*  [RegularExpression(@"[a-z]+[A-Z]", ErrorMessage = "A User Name must consist of lowercase letters")]*/
        [EmailAddress(ErrorMessage ="Perhatikan dalam penginputan email")]
        public String Email{ get; set; }
        
        public Gender Gender { get; set; }
     }


    }
public enum Gender
{ 
    Male,
    Female
}