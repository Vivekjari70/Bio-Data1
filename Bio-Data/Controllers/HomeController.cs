using Bio_Data.Data;
using Bio_Data.Models;
using Bio_Data.Models.Account;
using Bio_Data.Models.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bio_Data.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext context;

        public HomeController(ILogger<HomeController> logger,ApplicationContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginSignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var data = context.Users1.Where(e => e.Email == model.Email).SingleOrDefault();
                if (data != null)
                {
                    bool isvalid = (data.Email == model.Email && data.Password == model.Password);
                    if (isvalid)
                    {
                        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.Email) },
                            CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        HttpContext.Session.SetString("Email", model.Email);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        
                        TempData["errorpassword"] = "Invalid password! ";
                        return View(model);
                    }
                }
                else
                {
                    var newuser = new User1()
                    { 
                        Email = model.Email,
                        Password = model.Password,
                    };
                    context.Users1.Add(newuser);
                    context.SaveChanges();
                    var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.Email) },
                            CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    HttpContext.Session.SetString("Email", model.Email);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                TempData["message"] = "Empty field can't Submit";
                return View(model);
            }
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var storedCookies = Request.Cookies.Keys;
            foreach (var cookies in storedCookies)
            {
                Response.Cookies.Delete(cookies);
            }
            return RedirectToAction("Index", "Home");
        }

        [AcceptVerbs("Post", "Get")]
        public IActionResult EmailIsExist(string Email)
        {
            var data = context.Users1.Where(e => e.Email == Email).SingleOrDefault();
            if (data != null)
            {
                return Json($"Email Already in use!");
            }
            else
            {
                return Json(true);
            }
        }

        
    }
}
