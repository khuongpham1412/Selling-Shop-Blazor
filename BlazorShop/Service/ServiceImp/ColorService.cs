using BlazorShop.Data;
using BlazorShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Service.ServiceImp
{
    public class ColorService : IColorService
    {
        private ApplicationDbContext _applicationDbContext;

        public ColorService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public ColorDB Add(ColorDB colorDB)
        {
            try
            {
                String guid = System.Guid.NewGuid().ToString();
                colorDB.Id = guid;
                _applicationDbContext.ColorDBs.Add(colorDB);
                _applicationDbContext.SaveChanges();
                return colorDB;
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
                var color = _applicationDbContext.ColorDBs.FirstOrDefault(x => x.Id == Id);
                _applicationDbContext.ColorDBs.Remove(color);
                _applicationDbContext.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
            
        }


        public List<ColorDB> GetAllColor()
        {
            var data = _applicationDbContext.ColorDBs.ToList();
            return data;
        }

        public ColorDB GetColorFromId(string id)
        {
            return _applicationDbContext.ColorDBs.FirstOrDefault(x => x.Id == id);
        }

        public ColorDB Update(ColorDB colorDB)
        {
            try
            {
                _applicationDbContext.ColorDBs.Update(colorDB);
                _applicationDbContext.SaveChanges();
                return colorDB;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
