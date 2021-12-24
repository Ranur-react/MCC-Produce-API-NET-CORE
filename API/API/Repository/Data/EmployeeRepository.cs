using API.Context;
using API.Models;
using API.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<MyContext, Employee, String>
    {
        private readonly MyContext myContext;  //koneksi dengan database
        public EmployeeRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
        public IEnumerable<Employee> GetEmployee()
        {
            return myContext.Employees.ToList(); //Get data from Employee Entity
        }

        public IEnumerable<Object> RegisteredData() { 
        
            var qry= from emp in myContext.Employees
                     join act in myContext.Accounts
                        on emp.NIK equals act.NIK
                     join prof in myContext.Profilings
                        on act.NIK equals prof.NIK 
                     join edu in myContext.Educations
                       on prof.Education_Id equals edu.Id
                     join uni in myContext.Universities
                        on edu.University_Id equals uni.Id
                     select new EmployeeAccount
                     {  FullName = emp.FirsthName + emp.LastName,
                        PhoneNumber=emp.Phone,
                        Email=emp.Email,
                        BirthDate=emp.BirthDate,
                        Salary=emp.Salary,
                        GPA=edu.GPA,
                        Degree=edu.Degree,
                        UniversityName=uni.UniversityName
                     };
            return qry;

        }
        public IEnumerable<Education> GetEducation()
        {
            return myContext.Educations.ToList(); //Get data from Employee Entity
        }
        public int Register(RegisterForm registerForm) //use postman  to test
        {
            var empCount = this.GetEmployee().Count() + 1;
            var Year = DateTime.Now.Year;
            var NIK = $"{Year}0{empCount.ToString()}";
            var checkEmailPhone = CheckEmailAndPhone(registerForm);
            if (checkEmailPhone != 1)
            {
                return checkEmailPhone;
            }
            else
            {
                var emp = new Employee
                {
                    NIK = NIK,
                    FirsthName = registerForm.FirsthName,
                    LastName = registerForm.LastName,
                    Phone = registerForm.Phone,
                    BirthDate = registerForm.BirthDate,
                    Salary = 5000000,
                    Email = registerForm.Email,
                    Gender = registerForm.Gender
                };
                myContext.Employees.Add(emp);
                myContext.SaveChanges();
                var act = new Account
                {
                    NIK = emp.NIK,
                    Password = BCrypt.Net.BCrypt.HashPassword(registerForm.Password)
                };
                myContext.Accounts.Add(act);
                myContext.SaveChanges();
                var edu = new Education
                {
                    Degree = registerForm.Degree,
                    GPA = registerForm.GPA,
                    University_Id = registerForm.University_Id
                };
                myContext.Educations.Add(edu);
                myContext.SaveChanges();

                var prof = new Profiling
                {
                    NIK = act.NIK,
                    Education_Id = edu.Id
                };
                myContext.Profilings.Add(prof);
                myContext.SaveChanges();
                return 1;
            }

        }
        public int CheckEmailAndPhone(RegisterForm employee)
        {
            var checkEmail = myContext.Employees.Where(e => e.Email == employee.Email).FirstOrDefault();
            if (checkEmail != null)
            {
                return 2;
            }
            else
            {
                var checkPhone = myContext.Employees.Where(e => e.Phone == employee.Phone).FirstOrDefault();
                if (checkPhone != null)
                {
                    return 3;
                }
                else
                {
                    return 1;
                }
            }
        }
        public int CheckPhone(RegisterForm employee)
        {
            var checkPhone = myContext.Employees.Where(e => e.Phone == employee.Phone).FirstOrDefault();
            if (checkPhone != null)
            {
                return 3;
            }
            else
            {
                return 1;
            }
        }
        public int CheckEmail(RegisterForm employee)
        {
            var checkEmail = myContext.Employees.Where(e => e.Email == employee.Email).FirstOrDefault();
            if (checkEmail != null)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

    }
}
