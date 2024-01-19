using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudOperation_MVC.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }

        public decimal Price{ get; set; }
        public string City{ get; set; }

        public string Remark{ get; set; }
    }
}