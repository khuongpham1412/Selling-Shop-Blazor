using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Entities
{
    public class Voucher
    {
        [Key]
        public string Id { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public string Name { get; set; }
        public int Percent { get; set; }
        public int Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
