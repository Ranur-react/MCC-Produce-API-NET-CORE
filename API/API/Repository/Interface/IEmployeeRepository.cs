using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interface
{
    interface IEmployeeRepository
    {   
        IEnumerable<Employee> Get();  //Untuk Get All Semua data sma kayak Select*
       // IList<Employee> Get();   //Bisa pakai  IList<> --> (Jika manggil,insert,update list terlebih dahulu,)

        Employee Get(String NIK); //get data with PK --output satu data aja | non void
        int Insert(Employee employee);
        int Update(string NIK,Employee employee);
        int Delete(String NIK);
    }
}
    