using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Entities
{
    public class BillDetail
    {
        [Key]
        public string Id { get; set; }
        public string ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int Amount { get; set; }
        public string BillId { get; set; }
        [ForeignKey("BillId")]
        public Bill Bill { get; set; }
    }
}
