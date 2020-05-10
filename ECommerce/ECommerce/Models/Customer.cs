using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Customer
    {
        [ForeignKey("ApplicationUser")]
        [Key]
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}