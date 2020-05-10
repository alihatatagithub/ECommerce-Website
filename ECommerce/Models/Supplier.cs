using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Supplier
    {
        [ForeignKey("ApplicationUser")]
        [Key]
        public string SupplierID { get; set; }
        public string CompanyName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }

}