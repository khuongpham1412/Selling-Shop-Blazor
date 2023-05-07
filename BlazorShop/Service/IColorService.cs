using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.Entities;

namespace BlazorShop.Service
{
    public interface IColorService
    {
        List<ColorDB> GetAllColor();
        ColorDB GetColorFromId(string id);
        ColorDB Add(ColorDB colorDB);
        ColorDB Update(ColorDB colorDB);
        Boolean Delete(string colorDB);
    }
}
