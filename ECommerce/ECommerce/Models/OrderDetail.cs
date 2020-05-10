using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetialsID { get; set; }
        [ForeignKey("Product")]
        [DisplayName("Product Name")]

        public int ProID { get; set; }
        [ForeignKey("Customer")]
        [DisplayName("Customer Name")]
        public string CustomerID { get; set; }
        public int UnitPrice { get; set; }
        [DataType(DataType.Date)]
        public DateTime ShoppingDate { get; set; }
        [Required]
        [Range(1,20)]
        public int Quantity { get; set; }
        public double TotalPrice { get { return Quantity * UnitPrice; } }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}