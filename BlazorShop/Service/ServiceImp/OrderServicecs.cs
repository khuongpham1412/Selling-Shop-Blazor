using BlazorShop.Data;
using BlazorShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BlazorShop.Service
{
    public class OrderServicecs : IOrderService
    {
        private ApplicationDbContext _appLicationDbContext;
        public OrderServicecs(ApplicationDbContext appLicationDbContext)
        {
            _appLicationDbContext = appLicationDbContext;
        }
        public IEnumerable<Bill> getAllOrders()
        {
            return _appLicationDbContext.Bills.ToList();
        }
    }
}
