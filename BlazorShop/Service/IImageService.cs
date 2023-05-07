using System;
using System.Collections.Generic;
using System.Linq;
using BlazorShop.Entities;
using System.Threading.Tasks;

namespace BlazorShop.Service
{
    public interface IImageService
    {
        List<Image> GetAllImage();

        Image GetImageFromId(string id);
        Image Add(Image image);
        List<Image> AddAll(List<Image> images);
        List<Image> UpdateAll(List<Image> images);
        Image Update(Image image);
        Boolean Delete(string id);
        Boolean DeleteAll(string id);


    }
}
