using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Product.Model
{
    public class ProductDTO
    {
        [ValidateNever]
        public int ProductID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        
        public string Category { get; set; }


        public decimal Price { get; set; }

        public int StockQuantity { get; set; }


       
    }
}
