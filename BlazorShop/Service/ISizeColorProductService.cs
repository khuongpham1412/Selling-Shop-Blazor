using BlazorShop.Entities;
using System.Collections.Generic;

namespace BlazorShop.Service
{
    public interface ISizeColorProductService
    {
        SizeColorProduct Add(SizeColorProduct sizeColorProduct);
        SizeColorProduct GetInfo(string ProductId, string ColorId, string SizeId);
        List<SizeColorProduct> GetResultFromIdProduct(string IdProduct);
        void DeleteFromIdProduct(string idproduct);
    }
}
