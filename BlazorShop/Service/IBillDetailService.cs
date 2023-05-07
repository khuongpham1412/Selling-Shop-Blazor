using BlazorShop.Entities;
using System.Collections.Generic;

namespace BlazorShop.Service
{
    public interface IBillDetailService
    {
        BillDetail Add(BillDetail BillDetail);
        public List<BillDetail> GetBillDetailFromId(string BillId);
        public List<BillDetail> GetListResultFromIdProduct(string IdProduct);
    }
}
