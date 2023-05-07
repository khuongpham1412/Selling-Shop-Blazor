using BlazorShop.Data;
using BlazorShop.Entities;
using System.Collections.Generic;
using System.Linq;
namespace BlazorShop.Service.ServiceImp
{
    public class SizeColorProductService : ISizeColorProductService
    {
        private ApplicationDbContext _applicationDbContext;
        public SizeColorProductService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public SizeColorProduct Add(SizeColorProduct sizeColorProduct)
        {
            try
            {
                String guid = System.Guid.NewGuid().ToString();
                sizeColorProduct.Id = guid;
                _applicationDbContext.SizeColorProducts.Add(sizeColorProduct);
                _applicationDbContext.SaveChanges();
                //_applicationDbContext.SizeColorProducts.Where(a => 
                 //   a.ProductId == sizeColorProduct.ProductId &&
                //    a.SizeId == sizeColorProduct.SizeId &&
                //    a.ColorId == sizeColorProduct.ColorId
                //).ToList().ForEach(a => _applicationDbContext.SizeColorProducts.Add(a));
                return sizeColorProduct;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void DeleteFromIdProduct(string idproduct)
        {
            List<SizeColorProduct> _sizecolorproduct = GetResultFromIdProduct(idproduct);
            int length = _sizecolorproduct.Count();
            foreach (SizeColorProduct item in _sizecolorproduct)
            {
                _applicationDbContext.SizeColorProducts.Remove(item);
            }
            _applicationDbContext.SaveChanges();
        }

        public SizeColorProduct GetInfo(string ProductId, string ColorId, string SizeId)
        {
            return _applicationDbContext.SizeColorProducts.Where(x => x.ProductId == ProductId && x.ColorId == ColorId && x.SizeId == SizeId).FirstOrDefault();
        }

        public List<SizeColorProduct> GetResultFromIdProduct(string IdProduct)
        {
            return _applicationDbContext.SizeColorProducts.Where(x => x.ProductId == IdProduct).ToList();
        }
    }
}
