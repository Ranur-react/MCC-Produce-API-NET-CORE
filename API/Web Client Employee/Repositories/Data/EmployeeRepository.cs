using API.Models;
using API.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web_Client_Employee.Base;
using Web_Client_Employee.Models;

namespace Web_Client_Employee.Repositories.Data
{
    public class EmployeeRepository : GeneralRepository<Employee, string>
    {
        private readonly Address address;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient httpClient;
        public EmployeeRepository(Address address, string request= "Employees/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }
        public async Task<List<RegisterForm>> GetRegistered()
        {
            List<RegisterForm> entities = new List<RegisterForm>();

            using (var response = await httpClient.GetAsync(request+"RegisteredData/0"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<RegisterForm>>(apiResponse);
            }

            return entities;
        }
    }
}
