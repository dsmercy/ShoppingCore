using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingCore.Models;

    public class ShoppingCoreEntities : DbContext
    {
        public ShoppingCoreEntities (DbContextOptions<ShoppingCoreEntities> options)
            : base(options)
        {
        }

    public virtual DbSet<Tbl_Cart> Tbl_Cart { get; set; }
    public virtual DbSet<Tbl_CartStatus> Tbl_CartStatus { get; set; }
    public virtual DbSet<Tbl_Category> Tbl_Category { get; set; }
    public virtual DbSet<Tbl_SubCategory> Tbl_SubCategory { get; set; }
    public virtual DbSet<Tbl_Members> Tbl_Members { get; set; }
    public virtual DbSet<Tbl_Product> Tbl_Product { get; set; }
    public virtual DbSet<Tbl_Roles> Tbl_Roles { get; set; }
    public virtual DbSet<Tbl_ShippingDetails> Tbl_ShippingDetails { get; set; }
    public virtual DbSet<Tbl_ProductImage> Tbl_ProductImages { get; set; }
}
