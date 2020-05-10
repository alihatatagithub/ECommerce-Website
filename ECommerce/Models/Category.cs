using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Min Length between 10 and 50")]
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}