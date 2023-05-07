using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Entities
{
    public class Image
    {
        public string Id { get; set; }
        public string Path { get; set; }
        public Product Product { get; set; }
        public Boolean IsDefault { get; set; }
    }
}
