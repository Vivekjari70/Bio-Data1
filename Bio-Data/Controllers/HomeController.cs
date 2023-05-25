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
        public IActionResult Privacy()
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
            return RedirectToAction("Login", "Home");
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

        public IActionResult GetBiodata()
        {
            var query = from p in context.personaldetails
                        join fm in context.familydetails on p.Id equals fm.Id into fmJoin
                        from fm in fmJoin.DefaultIfEmpty()
                        join c in context.contactdetails on p.Id equals c.Id into cJoin
                        from c in cJoin.DefaultIfEmpty()
                        select new BiodataViewModel
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Dateoftime = p.Dateoftime,
                            TimeOfBirth = p.TimeOfBirth,
                            PlaceOfBirth = p.PlaceOfBirth,
                            Rasi = p.Rasi,
                            Nakshtra = p.Nakshtra,
                            Complexion = p.Complexion,
                            Height = p.Height,
                           // Education = p.Education,
                           // Cast = p.Cast,
                           // Job = p.Job,
                           // FatherName = fm != null ? fm.FatherName : null,
                           // FatherOccupation = fm != null ? fm.FatherOccupation : null,
                           // MotherName = fm != null ? fm.MotherName : null,
                           // MotherOccupation = fm != null ? fm.MotherOccupation : null,
                           // ElderBrotherName = fm != null ? fm.ElderBrotherName : null,
                           // ElderBrotherOccupation = fm != null ? fm.ElderBrotherOccupation : null,
                           // YoungerBrotherName = fm != null ? fm.YoungerBrotherName : null,
                           // YoungerBrotherOccupation = fm != null ? fm.YoungerBrotherOccupation : null,
                           // ElderSisterName = fm != null ? fm.ElderSisterName : null,
                           // ElderSisterOccupation = fm != null ? fm.ElderSisterOccupation : null,
                           // YoungerSisterName = fm != null ? fm.YoungerSisterName : null,
                           // YoungerSisterOccupation = fm != null ? fm.YoungerSisterOccupation : null,
                           // ContactNo = c != null ? c.ContactNo : null,
                           // Address = c != null ? c.Address : null,
                           //// Path = p.Path
                        };

            var result = query.ToList();
            return View(result);
        }

       
    }
}
