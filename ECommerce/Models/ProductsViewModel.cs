using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class ProductsViewModel
    {
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }
        public IEnumerable<OrderDetail> Items { get; set; }
    }
}