using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCore.Models;
using ShoppingCore.Repository;

namespace ShoppingCore.Controllers
{
    [Authorize]
    public class ShoppingController : Controller
    {

        private IGenericRepository<Tbl_Product> prod_repository = null;

        public IGenericRepository<Tbl_Cart> Cart_repository = null;

        public IGenericRepository<Tbl_ProductImage> ProdImage_Repository { get; }
        public IHttpContextAccessor HttpContextAccessor { get; }
        public IGenericRepository<Tbl_ShippingDetails> Shippingrepository { get; }

        public ShoppingController(IGenericRepository<Tbl_Product> Prod_repository, IGenericRepository<Tbl_Cart> Cart_repository,
            IGenericRepository<Tbl_ProductImage> ProdImage_repository, IHttpContextAccessor HttpContextAccessor,
            IGenericRepository<Tbl_ShippingDetails> _shippingrepository)
        {
            this.prod_repository = Prod_repository;
            this.Cart_repository = Cart_repository;
            this.ProdImage_Repository = ProdImage_repository;
            this.HttpContextAccessor = HttpContextAccessor;
            Shippingrepository = _shippingrepository;
        }

        public IActionResult Cart()
        {
            return View();
        }

        public JsonResult CartData()
        {
            var memberid = User.FindFirstValue(ClaimTypes.Sid);
            List<Tbl_Product> product = new List<Tbl_Product>();
            IEnumerable<Tbl_Cart> cart = Cart_repository.GetListByParameter(i => i.CartStatusId == 1 && i.MemberId==Convert.ToInt32(memberid));

            foreach (var item in cart)
            {
                int _count = cart.Where(x => x.ProductId == item.ProductId).Count();
                Tbl_Product tbl_Product = new Tbl_Product();
                tbl_Product = prod_repository.GetById(item.ProductId);
                Tbl_ProductImage img = new Tbl_ProductImage();
                img = ProdImage_Repository.GetByParameter(i => i.ProductId == item.ProductId);
                tbl_Product.ProductImage = img.ImageName;
                tbl_Product.TotalProduct = _count;
                if (product.Any(s => s.ProductId == item.ProductId))
                    continue;
                product.Add(tbl_Product);
            }
            ViewBag.TotalPrice = product.Sum(i => i.PriceSale * i.TotalProduct);
            //ViewBag.TotalPrice = product.Sum(i => i.PriceSale);
            return Json(product);
        }

        [AllowAnonymous]
        public IActionResult _Cart()
        {
            ProductDetail tbl_Product = new ProductDetail();
            if (User.Identity.IsAuthenticated)
            {
                var memberid = User.FindFirstValue(ClaimTypes.Sid);
                tbl_Product.count = Cart_repository.GetAllRecordsCountByParameter(i => i.MemberId == Convert.ToInt32(memberid));
                return PartialView("_Cart", tbl_Product);
            }
            else
            {
                tbl_Product.count = 0;
                return PartialView("_Cart", tbl_Product);
            }
        }

        public int AddProductToCart(int itemId)
        {
            var memberid = User.FindFirstValue(ClaimTypes.Sid);
            Tbl_Cart tbl_Cart = new Tbl_Cart();
            tbl_Cart.AddedOn = DateTime.Now;
            tbl_Cart.CartStatusId = 1;
            tbl_Cart.MemberId = Convert.ToInt32(memberid);
            tbl_Cart.ProductId = itemId;
            tbl_Cart.UpdatedOn = DateTime.Now;
            Cart_repository.Insert(tbl_Cart);
            Cart_repository.Save();
            return 1;
        }

        public IActionResult AddProductToCart1(int itemId)
        {
            var memberid = User.FindFirstValue(ClaimTypes.Sid);
            Tbl_Cart tbl_Cart = new Tbl_Cart();
            tbl_Cart.AddedOn = DateTime.Now;
            tbl_Cart.CartStatusId = 1;
            tbl_Cart.MemberId = Convert.ToInt32(memberid);
            tbl_Cart.ProductId = itemId;
            tbl_Cart.UpdatedOn = DateTime.Now;
            Cart_repository.Insert(tbl_Cart);
            Cart_repository.Save();
            //TempData["ProductAddedToCart"] = "Product added to cart successfully";
            return RedirectToAction("Cart");
        }

        public int RemoveCart(int itemId)
        {
            Cart_repository.RemovebyWhereClause(i => i.ProductId == itemId);
            Cart_repository.Save();
            return 1;
        }

        public IActionResult Checkout()
        {
            List<Tbl_Product> product = new List<Tbl_Product>();
            var memberid = User.FindFirstValue(ClaimTypes.Sid);
            IEnumerable<Tbl_Cart> cart = Cart_repository.GetListByParameter(i => i.MemberId == Convert.ToInt32(memberid));
            foreach (var item in cart)
            {
                Tbl_Product tbl_Product = new Tbl_Product();
                tbl_Product = prod_repository.GetById(item.ProductId);
                product.Add(tbl_Product);
            }
            Shippingdetail shippingdetail = new Shippingdetail();
            shippingdetail.AmountPaid = product.Sum(i => i.PriceSale);
            return View(shippingdetail);
        }
        public ActionResult PaymentSuccess(Shippingdetail shippingDetails)
        {
            int memberid = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));
            IEnumerable<Tbl_Cart> carts = null;
            carts = Cart_repository.GetListByParameter(j => j.MemberId == memberid);
            foreach (var item in carts)
            {
                Tbl_ShippingDetails sd = new Tbl_ShippingDetails();
                sd.ProductId = item.ProductId;
                sd.AmountPaid = prod_repository.GetByParameter(i => i.ProductId == item.ProductId).PriceSale;
                sd.MemberId = item.MemberId;
                sd.RecieverName = shippingDetails.RecieverName;
                sd.Mobile = shippingDetails.Mobile;
                sd.AddressLine = shippingDetails.Adress;
                sd.City = shippingDetails.City;
                sd.State = shippingDetails.State;
                sd.Country = shippingDetails.Country;
                sd.ZipCode = shippingDetails.ZipCode;
                sd.OrderId = Guid.NewGuid().ToString();
                sd.PaymentType = shippingDetails.PaymentType;
                sd.OrderDate = shippingDetails.OrderDate;
                Shippingrepository.Insert(sd);
                Cart_repository.RemovebyWhereClause(i => i.MemberId == memberid && i.ProductId == item.ProductId);
                //prod_repository.UpdateByWhereClause(i => i.ProductId==item.ProductId, (j => j. = 3));

            }
            return RedirectToAction("Orders");
        }

        public ActionResult Orders()
        {
            int memberid = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));
            IEnumerable<Tbl_ShippingDetails> _ShippingDetails = null;
            List<Shippingdetail> shippingdetails = new List<Shippingdetail>();
            _ShippingDetails = Shippingrepository.GetListByParameter(i => i.MemberId == memberid);
            foreach (var item in _ShippingDetails)
            {
                Shippingdetail SD = new Shippingdetail();
                SD.AmountPaid = item.AmountPaid;
                SD.RecieverName = item.RecieverName;
                SD.ProductName = prod_repository.GetByParameter(i => i.ProductId == item.ProductId).ProductName;
                SD.Image = ProdImage_Repository.GetByParameter(i => i.ProductId == item.ProductId).ImageName;
                SD.Adress = item.AddressLine;
                SD.City = item.City;
                SD.Country = item.Country;
                SD.MemberId = item.MemberId;
                SD.Mobile = item.Mobile;
                SD.OrderId = item.OrderId;
                SD.PaymentType = item.PaymentType;
                SD.ProductId = item.ProductId;
                SD.State = item.State;
                SD.ZipCode = item.ZipCode;
                SD.OrderDate = item.OrderDate;
                shippingdetails.Add(SD);
            }
            return View(shippingdetails);
        }
    }
}