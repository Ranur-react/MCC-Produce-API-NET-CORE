using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.ViewModel
{
    public class EmployeeAccount
    {
        public String FullName { get; set; }
        public String PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int Salary { get; set; }
        public String Email { get; set; }
        public virtual String Degree { get; set; }
        public virtual float GPA { get; set; }
        public virtual String UniversityName { get; set; }
    }
}
