using BlazorShop.Data;
using BlazorShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Service.ServiceImp
{
    public class ImageService : IImageService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ImageService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Image Add(Image image)
        {
            try
            {
                String guid = System.Guid.NewGuid().ToString();
                image.Id = guid;
                _applicationDbContext.Images.Add(image);
                _applicationDbContext.SaveChanges();
                return image;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Image> AddAll(List<Image> images)
        {
            try
            {
                foreach (Image image in images)
                {
                    String guid = System.Guid.NewGuid().ToString();
                    image.Id = guid;
                    _applicationDbContext.Images.Add(image);
                }
                _applicationDbContext.SaveChanges();
                return images;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Image> UpdateAll(List<Image> images)
        {
            try
            {
                string prodId = images[0].Product.Id;
                Console.WriteLine(prodId);
                List<Image> imagesDel = _applicationDbContext.Images.Where(x => x.Product.Id == prodId).ToList();
                Console.WriteLine(imagesDel[0].Product.Id);
                if (imagesDel.Count > 0)
                {
                    foreach (Image imagedel in imagesDel)
                    {

                        _applicationDbContext.Images.Remove(imagedel);
                    }
                    _applicationDbContext.SaveChanges();
                }
                foreach (Image image in images)
                {
                    String guid = System.Guid.NewGuid().ToString();
                    image.Id = guid;
                    _applicationDbContext.Images.Add(image);
                }
                _applicationDbContext.SaveChanges();

                return images;
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
                var color = _applicationDbContext.Images.FirstOrDefault(x => x.Id == Id);
                _applicationDbContext.Images.Remove(color);
                _applicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }public bool DeleteAll(string Id)
        {
            try
            {
                List<Image> images = _applicationDbContext.Images.Where(x => x.Product.Id == Id).ToList();
                foreach (Image image in images)
                {
                    _applicationDbContext.Images.Remove(image);
                }
                _applicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public List<Image> GetAllImage()
        {
            var data = _applicationDbContext.Images.ToList();
            return data;
        }

        public Image GetImageFromId(string id)
        {
            return _applicationDbContext.Images.FirstOrDefault(x => x.Id == id);
        }

        public Image Update(Image image)
        {
            try
            {
                _applicationDbContext.Images.Update(image);
                _applicationDbContext.SaveChanges();
                return image;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
