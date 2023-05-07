using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Entities
{
    public class Account
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Username { get; set; }

        [Required]
        [MaxLength(250)]
        public string Password { get; set; }

        [Required]
        [MaxLength(250)]
        public int Permission { get; set; }

        public int? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public Employee? Employee {get; set;}
        public Customer? Customer {get; set;}

       
    }   
}
