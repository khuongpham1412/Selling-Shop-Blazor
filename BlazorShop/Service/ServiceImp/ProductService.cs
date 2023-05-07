using BlazorShop.Data;
using BlazorShop.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Service
{
    public class ProductService : IProductService
    {
        private ApplicationDbContext _applicationDbContext;
        public ProductService(ApplicationDbContext appLicationDbContext)
        {
            _applicationDbContext = appLicationDbContext;
        }

        public Product Add(Product product)
        {
            try
            {
                String guid = System.Guid.NewGuid().ToString();
                product.Id = guid;
                product.CategoryId = product.Category.Id;
                _applicationDbContext.Products.Add(product);
                _applicationDbContext.SaveChanges();
                return product;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Delete(string idproduct)
        {
            try
            {
                var product = _applicationDbContext.Products.FirstOrDefault(x => x.Id == idproduct);
                _applicationDbContext.Products.Remove(product);
                _applicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Product> GetAllProducts()
        {
            List<Product> data = _applicationDbContext.Products.Include(x => x.Category).Include(x => x.Images.Where(i => i.IsDefault == true)).ToList();
            return data;
        }

        public Product GetProductFromId(string id)
        {
            var data = _applicationDbContext.Products
                .Where(x => x.Id == id)
                .Include(x => x.Sizes)
                .Include(x => x.ColorDBs)
                .Include(x => x.Images)
                .Include(x => x.Category).Single();
            return data;
            
        }

        public Product Update(Product product)
        {
            try
            {
                _applicationDbContext.Products.Update(product);
                _applicationDbContext.SaveChanges();
                return product;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool IncreaseAmount(string idproduct, int amount)
        {
            try
            {
                var product = _applicationDbContext.Products.FirstOrDefault(x => x.Id == idproduct);
                product.Amount += amount;
                _applicationDbContext.Products.Remove(product);
                _applicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DecreaseAmount(string idproduct, int amount)
        {
            try
            {
                var product = _applicationDbContext.Products.FirstOrDefault(x => x.Id == idproduct);
                product.Amount -= amount;
                _applicationDbContext.Products.Remove(product);
                _applicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateStatusProduct(string idproduct, int status)
        {
            try
            {
                var product = _applicationDbContext.Products.FirstOrDefault(x => x.Id == idproduct);
                product.Status = status;
                _applicationDbContext.Products.Remove(product);
                _applicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Product> GetProductFromCategory(string cate)
        {
            List<Product> data = _applicationDbContext.Products.Include(x => x.Category).Include(x => x.Images.Where(i => i.IsDefault == true)).Where(x => x.Category.Name == cate).ToList();
            return data;
        }

        public Product FindSizeFromColor(string IdProduct, string idColor)
        {
            var product = GetProductFromId(IdProduct);
            Product data = null;
            if(product == null)
            {
                for (int i = 0; i < product.ColorDBs.Count();i++)
                {
                    var index = i;
                    if(product.ColorDBs[index].Id == idColor)
                    {
                        data = _applicationDbContext.Products
                            .Include(x => x.Sizes)
                            .Where(x => x.ColorDBs[index].Id == idColor)
                            .AsEnumerable()
                            .FirstOrDefault();

                        break;
                    }
                }
                
            }
            
            return data;
        }

        public List<Product> GetProductLikeValue(string value)
        {
            List<Product> products = _applicationDbContext.Products
                .Where(x => x.Name.Contains(value))
                .Include(x => x.Sizes)
                .Include(x => x.ColorDBs)
                .Include(x => x.Images)
                .Include(x => x.Category).ToList();
            return products;
        }
    }
}
