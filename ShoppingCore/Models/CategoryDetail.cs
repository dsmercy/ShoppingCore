using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShoppingCore.Models
{
    public class CategoryDetail
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category name is required")]
        [StringLength(100, ErrorMessage = "Minimum 3 and Maximum 100 characters are allowed", MinimumLength = 3)]
        //[Remote("CheckCategoryExist", "Admin", ErrorMessage = "Category already exist")]
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

    public class ProductDetail
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Minimum 3 and Maximum 100 characters are allowed", MinimumLength = 3)]
        //[Remote("CheckProductExist", "Admin", ErrorMessage = "Product already exist")]
        public string ProductName { get; set; }
        [Required]
        [Range(1, 50)]
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; } = DateTime.Today;
        public Nullable<System.DateTime> ModifiedDate { get; set; } =DateTime.Today;
        [Required]
        public string Description { get; set; }
        [NotMappedAttribute]
        public List<IFormFile> ProductImage { get; set; }
        public string ImageName { get; set; }
        public IEnumerable<Tbl_ProductImage> Images { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "1", "200000", ErrorMessage = "Invalid price")]
        public decimal? Price { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "1", "200000", ErrorMessage = "Invalid price")]
        public decimal? PriceSale { get; set; }

        public bool IsFeatured { get; set; }
        public int count { get; set; }

        public IEnumerable<Tbl_Product> RelatedProducts { get; set; }
    }

    public class ProductList
    {
        public IEnumerable<Tbl_Product> prodData { get; set; }
        //public int totalcount { get; set; }
    }
}