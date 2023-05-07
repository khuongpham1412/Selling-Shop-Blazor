using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Entities
{
    public class Bill
    {
        [Key]
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Total { get; set; }
        public string CustomerId { get; set; } 
        public Customer Customer { get; set; }

        public string? EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public List<BillDetail> BillDetails { get; set; }

        public int StatusBill { get; set; }
    }
}
