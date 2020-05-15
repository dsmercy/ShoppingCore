using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCore.Models;
using ShoppingCore.Repository;
using System.Drawing;
using Newtonsoft.Json;


namespace ShoppingCore.Controllers
{
    public class AdminController : Controller
    {

        private IGenericRepository<Tbl_Product> prod_repository = null;
        private IGenericRepository<Tbl_Category> cat_repository = null;
        private IGenericRepository<Tbl_SubCategory> subcat_repository = null;
        private IGenericRepository<Tbl_ProductImage> _Prodimg_repository;
        private IHostingEnvironment _hostingEnvironment;

        public AdminController(IGenericRepository<Tbl_Product> Prod_repository, IGenericRepository<Tbl_ProductImage> Prodimg_repository,
            IGenericRepository<Tbl_Category> Cat_repository, IGenericRepository<Tbl_SubCategory> SubCat_repository, IHostingEnvironment hostingEnvironment)
        {
            this.prod_repository = Prod_repository;
            this.cat_repository = Cat_repository;
            subcat_repository = SubCat_repository;
            _Prodimg_repository = Prodimg_repository;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllProducts()
        {
            var model = prod_repository.GetAll();
            List<ProductDetail> products = new List<ProductDetail>();
            foreach (var item in model)
            {
                ProductDetail tbl_Product = new ProductDetail();
                Tbl_Category category = new Tbl_Category();
                category = cat_repository.GetById(item.CategoryId);
                tbl_Product.CategoryName = category.CategoryName;
                tbl_Product.Description = item.Description;
                tbl_Product.PriceSale = item.PriceSale;
                tbl_Product.Price = item.Price;
                tbl_Product.ProductName = item.ProductName;
                tbl_Product.ProductId = item.ProductId;
                tbl_Product.Images = _Prodimg_repository.GetListByParameter(i => i.ProductId == item.ProductId);
                products.Add(tbl_Product);
            }

            return View(products);

        }
        public IActionResult ProductDetails()
        {
            Tbl_Product model = prod_repository.GetById(1);
            return View(model);
        }
        public ActionResult AllCategories()
        {
            var model = cat_repository.GetAll();
            return View(model);
        }
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCategory(CategoryDetail model)
        {
            if (ModelState.IsValid)
            {
                Tbl_Category category = new Tbl_Category();
                category.CategoryName = model.CategoryName;
                category.IsActive = model.IsActive;
                category.IsDelete = model.IsDelete;
                cat_repository.Insert(category);
                return RedirectToAction("AllCategories");
            }
            return View(model);
        }

        public IActionResult CreateProduct(int id)
        {
            IEnumerable<Tbl_Category> categories = null;
            Tbl_Product product = new Tbl_Product();
            if (id == 0)
            {
                categories = cat_repository.GetAll();
                ViewBag.categories = categories;
                IEnumerable<Tbl_SubCategory> subcategories = null;
                subcategories = subcat_repository.GetAll();
                ViewBag.subcategories = subcategories;
            }
            else
            {
                categories = cat_repository.GetAll();
                ViewBag.categories = categories;
                IEnumerable<Tbl_SubCategory> subcategories = null;
                subcategories = subcat_repository.GetAll();
                ViewBag.subcategories = subcategories;
                ProductDetail productDetail = new ProductDetail();
                product = prod_repository.GetById(id);
                productDetail.ProductId = product.ProductId;
                productDetail.CategoryId = product.CategoryId;
                productDetail.SubCategoryId = product.SubCategoryId;
                productDetail.ProductName = product.ProductName;
                productDetail.Price = product.Price;
                productDetail.PriceSale = product.PriceSale;
                productDetail.Description = product.Description;
                productDetail.IsActive = product.IsActive;
                productDetail.IsFeatured = product.IsFeatured;
                return View(productDetail);
            }
            
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult CreateProduct(ProductDetail model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string uniqueFileName = null;
                    Tbl_Product product = new Tbl_Product();
                    ///Insert Product Data  
                    product.CategoryId = model.CategoryId;
                    product.SubCategoryId = model.SubCategoryId;
                    product.CreatedDate = model.CreatedDate;
                    product.Description = model.Description;
                    product.IsActive = model.IsActive;
                    product.IsDelete = model.IsDelete;
                    product.IsFeatured = model.IsFeatured;
                    product.ModifiedDate = model.ModifiedDate;
                    product.Price = model.Price;
                    product.PriceSale = model.PriceSale;
                    product.ProductId = model.ProductId;
                    product.ProductName = model.ProductName;
                    //product.ProductImage = uniqueFileName;
                    prod_repository.Insert(product);
                    int lastProductId = product.ProductId;

                    

                    // If the Photo property on the incoming model object is not null, then the user
                    // has selected an image to upload.
                    if (model.ProductImage != null && model.ProductImage.Count > 0)
                    {
                        foreach (IFormFile image in model.ProductImage)
                        {   
                            // The image must be uploaded to the images folder in wwwroot
                            // To get the path of the wwwroot folder we are using the inject
                            // HostingEnvironment service provided by ASP.NET Core
                            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "ProductImage");
                            // To make sure the file name is unique we are appending a new
                            // GUID value and and an underscore to the file name
                            uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                            // Use CopyTo() method provided by IFormFile interface to
                            // copy the file to wwwroot/images folder
                            image.CopyTo(new FileStream(filePath, FileMode.Create));
                            Tbl_ProductImage productImage = new Tbl_ProductImage();
                            productImage.ProductId = lastProductId;
                            productImage.ImageName = uniqueFileName;

                            // Load image.
                            Image img = Image.FromStream(image.OpenReadStream(), true, true);

                            // Compute thumbnail size.
                            Size thumbnailSize = GetThumbnailSize(img);

                            // Get thumbnail.
                            Image thumbnail = img.GetThumbnailImage(thumbnailSize.Width,
                                thumbnailSize.Height, null, IntPtr.Zero);

                            string uploadsFolder2 = Path.Combine(_hostingEnvironment.WebRootPath, "Thumbnails");
                            string filePath2 = Path.Combine(uploadsFolder2, uniqueFileName);

                            // Save thumbnail.
                            thumbnail.Save(filePath2);
                            _Prodimg_repository.Insert(productImage);
                        }
                    }

                    return RedirectToAction("AllProducts");
                }
                return View(model);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        

        public Size GetThumbnailSize(Image original)
        {
            // Maximum size of any dimension.
            const int maxPixels = 60;

            // Width and height.
            int originalWidth = original.Width;
            int originalHeight = original.Height;

            // Compute best factor to scale entire image based on larger dimension.
            double factor;
            if (originalWidth > originalHeight)
            {
                factor = (double)maxPixels / originalWidth;
            }
            else
            {
                factor = (double)maxPixels / originalHeight;
            }

            // Return thumbnail size.
            return new Size((int)(originalWidth * factor), (int)(originalHeight * factor));
        }


    }
}