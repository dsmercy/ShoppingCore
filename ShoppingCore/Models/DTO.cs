using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShoppingCore.Models
{
    public partial class Tbl_Cart
    {
        [Key]
        public int CartId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> MemberId { get; set; }
        public Nullable<int> CartStatusId { get; set; }
        public Nullable<System.DateTime> AddedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<int> ShippingDetailId { get; set; }

        public virtual Tbl_CartStatus CartStatus { get; set; }
        public virtual Tbl_Product Product { get; set; }
    }


    public partial class Tbl_CartStatus
    {
        [Key]
        public int CartStatusId { get; set; }
        public string CartStatus { get; set; }

        public virtual ICollection<Tbl_Cart> Cart { get; set; }
    }


    public partial class Tbl_Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        public virtual ICollection<Tbl_Product> Product { get; set; }
    }
    public partial class Tbl_SubCategory
    {
        [Key]
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        public virtual ICollection<Tbl_Product> Product { get; set; }
    }


    public partial class Tbl_Roles
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Tbl_Members> Tbl_Members { get; set; }
    }
    public partial class Tbl_Members
    {
        [Key]
        public int MemberId { get; set; }
        public int RoleId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        [Required]
        public string EmailId { get; set; }        
        public string Password { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public virtual Tbl_Roles Tbl_Roles { get; set; }
    }

    public partial class Tbl_Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string Description { get; set; }
        public string ProductImage { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> PriceSale { get; set; }
        public bool IsFeatured { get; set; }
        public int Quantity { get; set; }
        public virtual ICollection<Tbl_Cart> Tbl_Cart { get; set; }
        public virtual Tbl_Category Category { get; set; }
        public virtual Tbl_SubCategory SubCategory { get; set; }
        public virtual ICollection<Tbl_ProductImage> Tbl_ProductImage { get; set; }
        public virtual ICollection<Tbl_ShippingDetails> Tbl_ShippingDetails { get; set; }
        [NotMapped]
        public int TotalProduct { get; set; }
        [NotMapped]
        public int TotalPrice { get; set; }
        
    }

    public partial class Tbl_ProductImage
    {
        [Key]
        public int ImageId { get; set; }
        public int ProductId { get; set; }
        public string ImageName { get; set; } 
        
        public virtual Tbl_Product Product { get; set; }
    }



    public partial class Tbl_ShippingDetails
    {
        [Key]
        public int ShippingDetailId { get; set; }
        public int ?ProductId { get; set; }
        public int Mobile { get; set; }
        public string RecieverName { get; set; }
        public Nullable<int> MemberId { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string OrderId { get; set; }
        public Nullable<decimal> AmountPaid { get; set; }
        public string PaymentType { get; set; }
        public string OrderDate { get; set; }

        public virtual Tbl_Product Product { get; set; }
    }

    public partial class Tbl_PinCodes
    {
        [Key]
        public int PinId { get; set; }
        public int Pincode { get; set; }
        public string City { get; set; }
    }

}