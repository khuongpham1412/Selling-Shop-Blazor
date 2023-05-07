using BlazorShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Service
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
        Customer Add(Customer customer);
        Customer Update(Customer customer);
        Boolean Delete(string id);
        Customer GetCustomerFromId(string id);
        Customer GetCustomerFromIdAccount(string id);
    }
}
