using BlazorShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Service
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        Employee Add(Employee employee);
        Employee Update(Employee employee);
        Boolean Delete(string id);
        Employee GetEmployeeFromId(string id);
        Employee GetEmployeeFromAccountId(string id);
    }
}
