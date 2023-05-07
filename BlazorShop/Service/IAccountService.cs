using BlazorShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Service
{
    public interface IAccountService
    {
        List<Account> GetAllAccounts();
        Account Add(Account account);
        Account Update(Account account);
        void UpdateStatus(string id, int status);
        Boolean Delete(string id);
        Account GetAccountFromId(string id);
        Account Login(string username, string password);
    }
}
