using BlazorShop.Data;
using BlazorShop.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BlazorShop.Service
{
    public class BillDetailService : IBillDetailService
    {
        private ApplicationDbContext _applicationDbContext;
        public BillDetailService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public BillDetail Add(BillDetail BillDetail)
        {
            try
            {
                String guid = System.Guid.NewGuid().ToString();
                BillDetail.Id = guid;
                _applicationDbContext.BillDetails.Add(BillDetail);
                _applicationDbContext.SaveChanges();
                return BillDetail;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        List<BillDetail> IBillDetailService.GetBillDetailFromId(string BillId)
        {
            return _applicationDbContext.BillDetails.Where(x => x.BillId == BillId).ToList();
        }

        List<BillDetail> IBillDetailService.GetListResultFromIdProduct(string IdProduct)
        {
            return _applicationDbContext.BillDetails.Where(x=>x.ProductId== IdProduct).ToList();
        }
    }
}
