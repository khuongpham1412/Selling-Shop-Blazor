using BlazorShop.Entities;
using System.Collections.Generic;
using BlazorShop.Data;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.Core.constant;

namespace BlazorShop.Service.ServiceImp
{
    public class VoucherService : IVoucherService
    {
        private ApplicationDbContext _applicationDbContext;
        public VoucherService(ApplicationDbContext appLicationDbContext)
        {
            _applicationDbContext = appLicationDbContext;
        }

        public Voucher Add(Voucher voucher)
        {
            try
            {
                String guid = System.Guid.NewGuid().ToString();
                voucher.Id = guid;
                _applicationDbContext.Vouchers.Add(voucher);
                _applicationDbContext.SaveChanges();
                return voucher;
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
                var voucher = _applicationDbContext.Vouchers.FirstOrDefault(x => x.Id == Id);
                _applicationDbContext.Vouchers.Remove(voucher);
                _applicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public List<Voucher> GetAllVoucher()
        {
            var data = _applicationDbContext.Vouchers.ToList();
            return data;
        }

        public Voucher GetVoucherFromId(string id)
        {
            return _applicationDbContext.Vouchers.FirstOrDefault(x => x.Id == id);
        }

        public Voucher Update(Voucher voucher)
        {
            try
            {
                _applicationDbContext.Vouchers.Update(voucher);
                _applicationDbContext.SaveChanges();
                return voucher;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int? UseVoucher(string code)
        {
            try
            {
                DateTime now = DateTime.Now;
                var voucher = _applicationDbContext.Vouchers.FirstOrDefault(x => x.Code == code);
                if(DateTime.Compare(now, voucher.StartDate) < 0 || DateTime.Compare(now, voucher.EndDate) > 0 )
                {
                    return StatusUseVoucher.OUT_OF_TIME;
                }
                if(voucher.Amount <= 0)
                {
                    return StatusUseVoucher.OUT_OF_STOCK;
                }
                voucher.Amount -= 1;
                _applicationDbContext.Vouchers.Update(voucher);
                _applicationDbContext.SaveChanges();
                return StatusUseVoucher.USED;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
