using BlazorShop.Data;
using BlazorShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Service.ServiceImp
{
    public class AccountService : IAccountService
    {
        private ApplicationDbContext _applicationDbContext;

        public AccountService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Account Add(Account account)
        {
            try
            {
                String guid = System.Guid.NewGuid().ToString();
                account.Id = guid;
                _applicationDbContext.Accounts.Add(account);
                _applicationDbContext.SaveChanges();
                return account;
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
                var account = _applicationDbContext.Accounts.FirstOrDefault(x => x.Id == Id);
                _applicationDbContext.Accounts.Remove(account);
                _applicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public List<Account> GetAllAccounts()
        {
            var data = _applicationDbContext.Accounts.ToList();
            return data;
        }

        public Account GetAccountFromId(string id)
        {
            return _applicationDbContext.Accounts.Where(x => x.Id == id).FirstOrDefault();
        }

        public Account Update(Account account)
        {
            try
            {
                _applicationDbContext.Accounts.Update(account);
                _applicationDbContext.SaveChanges();
                return account;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Account Login(string username, string password)
        {
            return _applicationDbContext.Accounts.FirstOrDefault(x => x.Username == username && x.Password == password);
        }

        public void UpdateStatus(string id, int status)
        {
            Account account = GetAccountFromId(id);
            if (account != null)
            {
                account.Status = status;
                _applicationDbContext.SaveChanges();
            }
        }
    }
}
