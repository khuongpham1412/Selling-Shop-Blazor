using BlazorShop.Data;
using BlazorShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Service.ServiceImp
{
    public class SizeService : ISizeService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public SizeService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Size Add(Size size)
        {
            try
            {
                String guid = System.Guid.NewGuid().ToString();
                size.Id = guid;
                _applicationDbContext.Sizes.Add(size);
                _applicationDbContext.SaveChanges();
                return size;
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
                var color = _applicationDbContext.Sizes.FirstOrDefault(x => x.Id == Id);
                _applicationDbContext.Sizes.Remove(color);
                _applicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public List<Size> FindSizeFromColor(int index, string id)
        {
            var data = _applicationDbContext.Products.Where(x => x.ColorDBs[index].Id == id);
            return null;
        }

        public List<Size> GetAllSize()
        {
            var data = _applicationDbContext.Sizes.ToList();
            return data;
        }

        public Size GetSizeFromId(string id)
        {
            return _applicationDbContext.Sizes.FirstOrDefault(x => x.Id == id);
        }

        public Size Update(Size size)
        {
            try
            {
                _applicationDbContext.Sizes.Update(size);
                _applicationDbContext.SaveChanges();
                return size;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
