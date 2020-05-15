using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using ShoppingCore.Utility;
using ShoppingCore.Models;
using ShoppingCore.Repository;
using Microsoft.AspNetCore.Http;

namespace ShoppingCore.Controllers
{
    public class AccountController : Controller
    {
        public IGenericRepository<Tbl_Members> Mem_Repository { get; }
        public DataProtectionPurposeStrings DataProtectionPurposeStrings { get; }
        private readonly IDataProtector protector;
        private readonly ISession session;

        public IHttpContextAccessor HttpContextAccessor { get; }

        public AccountController(IDataProtectionProvider dataProtectionProvider, IGenericRepository<Tbl_Members> mem_repository,
                              IHttpContextAccessor httpContextAccessor, DataProtectionPurposeStrings dataProtectionPurposeStrings
                              , IHttpContextAccessor HttpContextAccessor)
        {
            Mem_Repository = mem_repository;
            DataProtectionPurposeStrings = dataProtectionPurposeStrings;
            this.protector = dataProtectionProvider.CreateProtector(
               dataProtectionPurposeStrings.EmployeeIdRouteValue);
            this.session = httpContextAccessor.HttpContext.Session;
            this.HttpContextAccessor = HttpContextAccessor;
        }


        #region Member Login ...
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = Mem_Repository.GetByParameter(i => i.EmailId == model.UserEmailId);

                if (user != null)
                {
                    string DecryptedPassword = protector.Unprotect(user.Password);
                    if (DecryptedPassword == model.Password)
                    {
                        //Check the user name and password
                        //Here can be implemented checking logic from the database
                        ClaimsIdentity identity = null;
                        bool isAuthenticated = false;

                        if (user.RoleId == 1)
                        {

                            //Create the identity for the Admin
                            identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.FirstName),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Sid, Convert.ToString(user.MemberId)),
                        }, CookieAuthenticationDefaults.AuthenticationScheme);
                            this.session.SetInt32("memberid", user.MemberId);
                            isAuthenticated = true;
                        }

                        if (user.RoleId == 2)
                        {

                            //Create the identity for the User
                            identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.FirstName),
                    new Claim(ClaimTypes.Role, "User"),
                    new Claim(ClaimTypes.Sid, Convert.ToString(user.MemberId)),
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                            this.session.SetInt32("memberid", user.MemberId);
                            isAuthenticated = true;
                        }

                        if (isAuthenticated)
                        {
                            var principal = new ClaimsPrincipal(identity);

                            var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                            if (!string.IsNullOrEmpty(returnUrl))
                            {
                                return Redirect(returnUrl);
                            }
                            else
                            {
                                return RedirectToAction("Index", "Home");
                            }
                        }
                        else
                        {
                            if (user != null && user.IsActive == false) ModelState.AddModelError("Password", "Your account in not verified");
                            else ModelState.AddModelError("Password", "Invalid username or password");
                        }
                    }

                }
                else
                {
                    if (user != null && user.IsActive == false) ModelState.AddModelError("Password", "Your account in not verified");
                    else ModelState.AddModelError("Password", "Invalid username or password");
                }
            }
            return View(model);
        }



        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            this.session.Clear();
            return RedirectToAction("Login");
        }
        #endregion


        #region Member Registration ...         
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [Authorize]
        public ActionResult MyAccount()
        {
            int memberid = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));
            Tbl_Members register = new Tbl_Members();
            register = Mem_Repository.GetByParameter(i=>i.MemberId==memberid);
            return View(register);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Adding Member                 
                Tbl_Members mem = new Tbl_Members();
                mem.FirstName = model.FirstName;
                mem.LastName = model.LastName;
                mem.EmailId = model.UserEmailId;
                mem.CreatedOn = DateTime.Now;
                mem.ModifiedOn = DateTime.Now;
                mem.Password = protector.Protect(model.Password);
                mem.IsActive = true;
                mem.IsDelete = false;
                mem.RoleId = 2;
                Mem_Repository.Insert(mem);
                TempData["VerificationLinlMsg"] = "You are registered successfully.";

                return RedirectToAction("Index", "Home");
            }
            return View("Register", model);
        }

        public JsonResult CheckEmailExist(string UserEmailId)
        {
            int? LoginMemberId = HttpContextAccessor.HttpContext.Session.GetInt32("memberid");
            var EmailExist = Mem_Repository.GetByParameter(i => i.MemberId != LoginMemberId && i.EmailId == UserEmailId && i.IsDelete == false);
            return Json(EmailExist);
        }
        #endregion    
    }
}