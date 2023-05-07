using BlazorShop.Data;
using BlazorShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Service.ServiceImp
{
    public class EmployeeService : IEmployeeService
    {
        private ApplicationDbContext _applicationDbContext;

        public EmployeeService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Employee Add(Employee employee)
        {
            try
            {
                String guid = System.Guid.NewGuid().ToString();
                employee.Id = guid;
                _applicationDbContext.Employees.Add(employee);
                _applicationDbContext.SaveChanges();
                return employee;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Delete(string Id)
        {
            try
            {
                var employee = _applicationDbContext.Employees.FirstOrDefault(x => x.Id == Id);
                _applicationDbContext.Employees.Remove(employee);
                _applicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public List<Employee> GetAllEmployees()
        {
            var data = _applicationDbContext.Employees?.ToList();
            return data;
        }

        public Employee GetEmployeeFromAccountId(string id)
        {
            return _applicationDbContext.Employees.FirstOrDefault(x => x.AccountId == id);
        }

        public Employee GetEmployeeFromId(string id)
        {
            return _applicationDbContext.Employees.FirstOrDefault(x => x.Id == id);
        }

        public Employee Update(Employee employee)
        {
            try
            {
                _applicationDbContext.Employees.Update(employee);
                _applicationDbContext.SaveChanges();
                return employee;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
