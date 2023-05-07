using BlazorShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BlazorShop.Service
{
    public interface IVoucherService
    {
        List<Voucher> GetAllVoucher();

        Voucher GetVoucherFromId(string id);
        Voucher Add(Voucher voucher);
        Voucher Update(Voucher voucher);
        Boolean Delete(string id);
        int? UseVoucher(string code);

    }
}
