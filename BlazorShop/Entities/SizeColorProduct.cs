using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Entities
{
    public class SizeColorProduct
    {
        [Key]
        public string Id { get; set; }
        public string ColorId { get; set; }

        public string SizeId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
