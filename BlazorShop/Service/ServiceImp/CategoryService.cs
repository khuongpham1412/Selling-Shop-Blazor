using BlazorShop.Data;
using BlazorShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Service.ServiceImp
{
    public class CategoryService : ICategoryService
    {
        private ApplicationDbContext _applicationDbContext;

        public CategoryService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Category Add(Category category)
        {
            try
            {
                String guid = System.Guid.NewGuid().ToString();
                category.Id = guid;
                _applicationDbContext.Categories.Add(category);
                _applicationDbContext.SaveChanges();
                return category;
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
                var category = _applicationDbContext.Categories.FirstOrDefault(x => x.Id == Id);
                _applicationDbContext.Categories.Remove(category);
                _applicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public List<Category> GetAllCategories()
        {
            var data = _applicationDbContext.Categories.ToList();
            return data;
        }

        public Category GetCategoryFromId(string id)
        {
            return _applicationDbContext.Categories.FirstOrDefault(x => x.Id == id);
        }

        public Category Update(Category category)
        {
            try
            {
                _applicationDbContext.Categories.Update(category);
                _applicationDbContext.SaveChanges();
                return category;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
