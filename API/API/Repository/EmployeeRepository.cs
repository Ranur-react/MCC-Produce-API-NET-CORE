
using API.Context;
using API.Models;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MyContext myContext;  //koneksi dengan database
        public EmployeeRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Delete(string NIK)
        {
            var Entity = myContext.Employees.Find(NIK);
            myContext.Remove(Entity);
            var respond = myContext.SaveChanges();
            return respond;
        }

        public IEnumerable<Employee> Get()
        {
            return myContext.Employees.ToList(); //Get data from Employee Entity
        }

        public Employee Get(string NIK)
        {

            return myContext.Employees.Find(NIK);
            /*return myContext.Employees.Where(e => e.NIK == NIK).FirstOrDefault();*/
        }
        public Employee Search(string Name)
        {

            return myContext.Employees.Find(Name);
            /*return myContext.Employees.Where(e => e.NIK == NIK).FirstOrDefault();*/
        }

        public int Insert(Employee employee) //use postman  to test
        {
            var checkData = myContext.Employees.Find(employee.NIK);
            if (checkData == null)
            {
                var checkEmailPhone = CheckEmailAndPhone(employee);
                if (checkEmailPhone != 1)
                {
                    return checkEmailPhone;
                }
                else
                {
                    myContext.Employees.Add(employee);
                    return myContext.SaveChanges();
                }
            }
            else
            {
                return 0;
            }
        }

        public int Update(string NIK, Employee employee)
        {
            var checkData = myContext.Employees.Find(NIK);
            if (checkData != null)
            {
                myContext.Entry(checkData).State = EntityState.Detached;
            }
            employee.NIK = NIK;
            myContext.Entry(employee).State = EntityState.Modified;
            return myContext.SaveChanges();

        }
        public int CheckEmailAndPhone(Employee employee)
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
    }
}
