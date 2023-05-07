using BlazorShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Service
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product FindSizeFromColor(string IdProduct, string IdColor);
        Product Add(Product product);
        Product Update(Product product);
        Boolean Delete(string idproduct);
        Product GetProductFromId(string id);
        List<Product> GetProductFromCategory(string cate);
        List<Product> GetProductLikeValue(string value);
        Boolean UpdateStatusProduct(string idproduct,int status);
        Boolean IncreaseAmount(string idproduct,int amount);
        Boolean DecreaseAmount(string idproduct,int amount);
    }
}
