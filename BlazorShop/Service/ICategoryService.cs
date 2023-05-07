using BlazorShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Service
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
        Category Add(Category category);
        Category Update(Category category);
        Boolean Delete(string id);
        Category GetCategoryFromId(string id);
    }
}
