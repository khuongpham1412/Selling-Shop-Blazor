using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace BlazorShop.Entities
{
    public class Product
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? CategoryId { get; set; }
        [Required]
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        [Required]

        public int PriceImport { get; set; }
        [Required]
        public int Price { get; set; }
        public int? PriceSale { get; set; }
        [Required]
        public List<Image> Images { get; set; }
        public List<Size>? Sizes { get; set; }
        public List<ColorDB>? ColorDBs { get; set; }
        public int? Status { get; set; }
        [Required]

        public int Amount { get; set; }

    }
}
