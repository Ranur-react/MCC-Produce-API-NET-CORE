
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
        public IEnumerable<Employee> Search(Employee employee)
        {

            /*            return myContext.Employees.Find(Name);*/
            return myContext.Employees.ToList().Where(e => e.FirsthName == employee.FirsthName || e.NIK==employee.NIK || e.LastName == employee.LastName);
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
           
            if (checkData.Email == employee.Email) //apakah email diri sendiri
            {//jika ya
                if (checkData.Phone == employee.Phone) //apakah phonsel diri sendiri
                {
                    //maka langsung Update disini
                    return ExecUpdate(NIK, employee); 
                }
                else
                {
                    //check ponsel saja dulu
                    var p = CheckPhone(employee);
                    if (p != 1) //apakah ponsel ada yang make?
                    {//jika ya=eror
                        return p;
                    }
                    //jika tidak update aja
                    else {
                          return ExecUpdate(NIK, employee);
                    }
                }
            }
            else {
                if (checkData.Phone == employee.Phone)  //apakah ponsel sendiri?
                {
                    var e = CheckEmail(employee); //apakah email sudah dipake orang lain atau tidak?
                    if (e != 1)
                    {
                        return e;
                    }
                    else
                    {
                        return ExecUpdate(NIK, employee);
                    }
                }
                else
                {
                    var checkEmailPhone = CheckEmailAndPhone(employee);
                    if (checkEmailPhone != 1)  //apakah email dan ponsel ada yang makai?
                    {
                        return checkEmailPhone;
                    }
                    else {
                        return ExecUpdate(NIK, employee);
                    }
                }

            }
        }
        public int ExecUpdate(String NIK,Employee employee) {
            employee.NIK = NIK;
            myContext.Entry(employee).State = EntityState.Modified;
            return myContext.SaveChanges();
        }
        //
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
        public int CheckPhone(Employee employee)
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
        public int CheckEmail(Employee employee)
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
