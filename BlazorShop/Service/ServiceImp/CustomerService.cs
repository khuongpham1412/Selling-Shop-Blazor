using BlazorShop.Data;
using BlazorShop.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Service.ServiceImp
{
    public class CustomerService : ICustomerService
    {
        private ApplicationDbContext _applicationDbContext;

        public CustomerService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Customer Add(Customer customer)
        {
            try
            {
                String guid = System.Guid.NewGuid().ToString();
                customer.Id = guid;
                _applicationDbContext.Customers.Add(customer);
                _applicationDbContext.SaveChanges();
                return customer;
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
                var customer = _applicationDbContext.Customers.FirstOrDefault(x => x.Id == Id);
                _applicationDbContext.Customers.Remove(customer);
                _applicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public List<Customer> GetAllCustomers()
        {
            var data = _applicationDbContext.Customers.ToList();
            return data;
        }

        public Customer GetCustomerFromId(string id)
        {
            return _applicationDbContext.Customers.FirstOrDefault(x => x.Id == id);
        }

        public Customer GetCustomerFromIdAccount(string id)
        {
            return _applicationDbContext.Customers.FirstOrDefault(x => x.AccountId == id);
        }

        public Customer Update(Customer customer)
        {
            try
            {
                _applicationDbContext.Customers.Update(customer);
                _applicationDbContext.SaveChanges();
                return customer;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
