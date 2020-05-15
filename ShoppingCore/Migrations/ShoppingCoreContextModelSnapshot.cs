﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ShoppingCore.Migrations
{
    [DbContext(typeof(ShoppingCoreEntities))]
    partial class ShoppingCoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShoppingCore.Models.Tbl_Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CartStatusId")
                        .HasColumnType("int");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("ShippingDetailId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("CartId");

                    b.HasIndex("CartStatusId");

                    b.HasIndex("ProductId");

                    b.ToTable("Tbl_Cart");
                });

            modelBuilder.Entity("ShoppingCore.Models.Tbl_CartStatus", b =>
                {
                    b.Property<int>("CartStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CartStatus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CartStatusId");

                    b.ToTable("Tbl_CartStatus");
                });

            modelBuilder.Entity("ShoppingCore.Models.Tbl_Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.HasKey("CategoryId");

                    b.ToTable("Tbl_Category");
                });

            modelBuilder.Entity("ShoppingCore.Models.Tbl_Members", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("Tbl_RolesRoleId")
                        .HasColumnType("int");

                    b.HasKey("MemberId");

                    b.HasIndex("Tbl_RolesRoleId");

                    b.ToTable("Tbl_Members");
                });

            modelBuilder.Entity("ShoppingCore.Models.Tbl_Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFeatured")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PriceSale")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Tbl_Product");
                });

            modelBuilder.Entity("ShoppingCore.Models.Tbl_ProductImage", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("ImageId");

                    b.HasIndex("ProductId");

                    b.ToTable("Tbl_ProductImages");
                });

            modelBuilder.Entity("ShoppingCore.Models.Tbl_Roles", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Tbl_Roles");
                });

            modelBuilder.Entity("ShoppingCore.Models.Tbl_ShippingDetails", b =>
                {
                    b.Property<int>("ShippingDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("AmountPaid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("Mobile")
                        .HasColumnType("int");

                    b.Property<string>("OrderDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("RecieverName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShippingDetailId");

                    b.HasIndex("ProductId");

                    b.ToTable("Tbl_ShippingDetails");
                });

            modelBuilder.Entity("ShoppingCore.Models.Tbl_SubCategory", b =>
                {
                    b.Property<int>("SubCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("SubCategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubCategoryId");

                    b.ToTable("Tbl_SubCategory");
                });

            modelBuilder.Entity("ShoppingCore.Models.Tbl_Cart", b =>
                {
                    b.HasOne("ShoppingCore.Models.Tbl_CartStatus", "CartStatus")
                        .WithMany("Cart")
                        .HasForeignKey("CartStatusId");

                    b.HasOne("ShoppingCore.Models.Tbl_Product", "Product")
                        .WithMany("Tbl_Cart")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("ShoppingCore.Models.Tbl_Members", b =>
                {
                    b.HasOne("ShoppingCore.Models.Tbl_Roles", "Tbl_Roles")
                        .WithMany("Tbl_Members")
                        .HasForeignKey("Tbl_RolesRoleId");
                });

            modelBuilder.Entity("ShoppingCore.Models.Tbl_Product", b =>
                {
                    b.HasOne("ShoppingCore.Models.Tbl_Category", "Category")
                        .WithMany("Product")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoppingCore.Models.Tbl_SubCategory", "SubCategory")
                        .WithMany("Product")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShoppingCore.Models.Tbl_ProductImage", b =>
                {
                    b.HasOne("ShoppingCore.Models.Tbl_Product", "Product")
                        .WithMany("Tbl_ProductImage")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShoppingCore.Models.Tbl_ShippingDetails", b =>
                {
                    b.HasOne("ShoppingCore.Models.Tbl_Product", "Product")
                        .WithMany("Tbl_ShippingDetails")
                        .HasForeignKey("ProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
