using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCore.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_CartStatus",
                columns: table => new
                {
                    CartStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_CartStatus", x => x.CartStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_SubCategory",
                columns: table => new
                {
                    SubCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoryName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_SubCategory", x => x.SubCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    EmailId = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Tbl_RolesRoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Members", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Tbl_Members_Tbl_Roles_Tbl_RolesRoleId",
                        column: x => x.Tbl_RolesRoleId,
                        principalTable: "Tbl_Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    SubCategoryId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ProductImage = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    PriceSale = table.Column<decimal>(nullable: true),
                    IsFeatured = table.Column<bool>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Tbl_Product_Tbl_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Tbl_Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Product_Tbl_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "Tbl_SubCategory",
                        principalColumn: "SubCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Cart",
                columns: table => new
                {
                    CartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: true),
                    MemberId = table.Column<int>(nullable: true),
                    CartStatusId = table.Column<int>(nullable: true),
                    AddedOn = table.Column<DateTime>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    ShippingDetailId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Cart", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Tbl_Cart_Tbl_CartStatus_CartStatusId",
                        column: x => x.CartStatusId,
                        principalTable: "Tbl_CartStatus",
                        principalColumn: "CartStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_Cart_Tbl_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Tbl_Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ProductImages",
                columns: table => new
                {
                    ImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    ImageName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ProductImages", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Tbl_ProductImages_Tbl_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Tbl_Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ShippingDetails",
                columns: table => new
                {
                    ShippingDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: true),
                    Mobile = table.Column<int>(nullable: false),
                    RecieverName = table.Column<string>(nullable: true),
                    MemberId = table.Column<int>(nullable: true),
                    AddressLine = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    OrderId = table.Column<string>(nullable: true),
                    AmountPaid = table.Column<decimal>(nullable: true),
                    PaymentType = table.Column<string>(nullable: true),
                    OrderDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ShippingDetails", x => x.ShippingDetailId);
                    table.ForeignKey(
                        name: "FK_Tbl_ShippingDetails_Tbl_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Tbl_Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Cart_CartStatusId",
                table: "Tbl_Cart",
                column: "CartStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Cart_ProductId",
                table: "Tbl_Cart",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Members_Tbl_RolesRoleId",
                table: "Tbl_Members",
                column: "Tbl_RolesRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Product_CategoryId",
                table: "Tbl_Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Product_SubCategoryId",
                table: "Tbl_Product",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ProductImages_ProductId",
                table: "Tbl_ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ShippingDetails_ProductId",
                table: "Tbl_ShippingDetails",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Cart");

            migrationBuilder.DropTable(
                name: "Tbl_Members");

            migrationBuilder.DropTable(
                name: "Tbl_ProductImages");

            migrationBuilder.DropTable(
                name: "Tbl_ShippingDetails");

            migrationBuilder.DropTable(
                name: "Tbl_CartStatus");

            migrationBuilder.DropTable(
                name: "Tbl_Roles");

            migrationBuilder.DropTable(
                name: "Tbl_Product");

            migrationBuilder.DropTable(
                name: "Tbl_Category");

            migrationBuilder.DropTable(
                name: "Tbl_SubCategory");
        }
    }
}
