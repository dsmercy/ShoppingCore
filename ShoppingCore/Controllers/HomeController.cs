using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCore.Models;
using ShoppingCore.Repository;

namespace ShoppingCore.Controllers
{

    public class HomeController : Controller
    {
        private IGenericRepository<Tbl_Product> prod_repository = null;
        private IGenericRepository<Tbl_Category> cat_repository = null;
        private IGenericRepository<Tbl_Cart> cart_repository;
        private IGenericRepository<Tbl_ProductImage> prodImage_repository;
        private ISession session;

        public IGenericRepository<Tbl_SubCategory> SubCat_Repository { get; }
        public ShoppingCoreEntities Context { get; }
        public IHttpContextAccessor HttpContextAccessor { get; }

        public HomeController(IGenericRepository<Tbl_Product> Prod_repository, IGenericRepository<Tbl_Cart> Cart_repository,
            IGenericRepository<Tbl_Category> Cat_repository, IHttpContextAccessor httpContextAccessor,
            IGenericRepository<Tbl_SubCategory> SubCat_repository, ShoppingCoreEntities Context,
            IGenericRepository<Tbl_ProductImage> ProdImage_repository, IHttpContextAccessor HttpContextAccessor)
        {
            this.prod_repository = Prod_repository;
            this.cat_repository = Cat_repository;
            SubCat_Repository = SubCat_repository;
            this.Context = Context;
            this.cart_repository = Cart_repository;
            this.prodImage_repository = ProdImage_repository;
            this.session = httpContextAccessor.HttpContext.Session;
            this.HttpContextAccessor = HttpContextAccessor;
        }

        public IActionResult Index()
        {
            var model = prod_repository.GetAll();
            List<Tbl_Product> products = new List<Tbl_Product>();
            foreach (var item in model)
            {
                Tbl_Product tbl_Product = new Tbl_Product();
                tbl_Product.Category = item.Category;
                tbl_Product.Description = item.Description;
                tbl_Product.PriceSale = item.PriceSale;
                tbl_Product.Price = item.Price;
                tbl_Product.ProductName = item.ProductName;
                tbl_Product.ProductId = item.ProductId;
                Tbl_ProductImage img = new Tbl_ProductImage();
                img = prodImage_repository.GetByParameter(i => i.ProductId == item.ProductId);
                tbl_Product.ProductImage = img.ImageName;
                products.Add(tbl_Product);
            }
            if (User.Identity.IsAuthenticated)
            {
                int? memberid = HttpContextAccessor.HttpContext.Session.GetInt32("memberid");
                int count = cart_repository.GetAllRecordsCountByParameter(i => i.MemberId == memberid);
                this.session.SetInt32("Cartcount", count);
            }

            return View(products);
        }

        public IActionResult ProductDetails(int id)
        {
            if (TempData["id"] != null)
            {
                id = (int)TempData["id"];
            }
            Tbl_Product pd = prod_repository.GetByParameter(i => i.ProductId == id);
            ProductDetail product = new ProductDetail();
            product.CategoryId = pd.CategoryId;
            product.CreatedDate = pd.CreatedDate;
            product.Description = pd.Description;
            //product.IsActive = pd.IsActive;
            ////product.IsDelete = pd.IsDelete;
            //product.IsFeatured = pd.IsFeatured;
            product.ModifiedDate = pd.ModifiedDate;
            product.Price = pd.Price;
            product.PriceSale = pd.PriceSale;
            product.ProductId = pd.ProductId;
            product.Images = prodImage_repository.GetListByParameter(i => i.ProductId == pd.ProductId);
            product.ProductName = pd.ProductName;
            product.count = pd.Quantity;
            product.RelatedProducts = prod_repository.GetListByParameter(i => i.SubCategoryId == pd.SubCategoryId);

            List<Tbl_Product> products = new List<Tbl_Product>();
            foreach (var item in product.RelatedProducts)
            {
                Tbl_Product tbl_Product = new Tbl_Product();
                tbl_Product.Category = item.Category;
                tbl_Product.Description = item.Description;
                tbl_Product.PriceSale = item.PriceSale;
                tbl_Product.Price = item.Price;
                tbl_Product.ProductName = item.ProductName;
                tbl_Product.ProductId = item.ProductId;
                Tbl_ProductImage img = new Tbl_ProductImage();
                img = prodImage_repository.GetByParameter(i => i.ProductId == item.ProductId);
                tbl_Product.ProductImage = img.ImageName;
                products.Add(tbl_Product);
            }
            product.RelatedProducts = products;
            return View(product);
        }

        public IActionResult About()
        {
            return View();
        }


        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult Features()
        {
            return View();
        }

        public IActionResult BestSellers(int id)
        {
            return View();
        }
        public IActionResult Featured()
        {
            return View();
        }
        public IActionResult FaqSupport()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Search()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var names = prod_repository.GetListByParameter(i => i.ProductName.Contains(term));
                List<string> name = new List<string>();

                foreach (var item in names)
                {
                    name.Add(item.ProductName);
                }
                return Ok(name);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Search(string productName)
        {
            try
            {
                var product = prod_repository.GetByParameter(i => i.ProductName.Contains(productName));
                TempData["id"] = product.ProductId;
                return RedirectToAction("ProductDetails");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IActionResult Catalog(int id)
        {
            return View();
        }


        [HttpGet]
        public JsonResult getLazyProducts(int page,int catid)
        {
            ProductList productList = new ProductList();
            productList = Lazy_data(12, page,catid);
            return Json(productList);
        }

        //public JsonResult getCategories()
        //{
        //    IEnumerable<Tbl_Category> categories = null;
        //    categories = cat_repository.GetAll();
        //    return Json(categories);
        //}

        public ProductList Lazy_data(int pagesize, int pageindex,int catid)
        {
            IEnumerable<Tbl_Product> products = null;

            if (catid == 0)
            {
                products = Context.Tbl_Product.Skip(pageindex * pagesize).Take(pagesize);
            }
            else
            {
                products = Context.Tbl_Product.Where(i=>i.CategoryId==catid).Skip(pageindex * pagesize).Take(pagesize);
            }          
            
            ProductList productList = new ProductList();
            productList.prodData = products;;
            return productList;
        }
        public IActionResult GetProduct(int id)
        {
            Tbl_Product pd = prod_repository.GetByParameter(i => i.ProductId == id);
            pd.ProductImage = prodImage_repository.GetByParameter(i => i.ProductId == pd.ProductId).ImageName;
            return PartialView("_quickView", pd);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
