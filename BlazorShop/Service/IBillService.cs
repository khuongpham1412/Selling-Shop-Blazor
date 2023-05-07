using BlazorShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BlazorShop.Service
{
    public interface IBillService
    {
        Bill Add(Bill Bill);
        List<Bill> getAllBills();
        Bill GetBillFromId(string id);
        void UpdateStatus(string IdBill,int Status, string EmployeeId);

        void UpdateIDStaff(string IdBill, string EmployeeId);
    }
}
