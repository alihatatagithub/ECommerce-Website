using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(30,MinimumLength =3,ErrorMessage ="Length Must between 3 and 30 character")]
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }
        [FileExtensions(ErrorMessage ="Choose Only Pic",Extensions =".PNG,.JPG,TIF,GIF,jpeg")]
        public string ProductImage { get; set; }
        [Required(ErrorMessage ="*")]
        [Range(11,3000000,ErrorMessage ="The Price Must From 11 to 3000000")]
        public int UnitPrice { get; set; }
        [DisplayName("Company Name")]
        public string SupplierID { get; set; }
        [DisplayName("Category Type")]
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}