using Bio_Data.Data;
using Bio_Data.Models;
using Bio_Data.Models.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bio_Data.Controllers
{
    public class BiodataController : Controller
    {
        private readonly ApplicationContext context;
        private readonly IWebHostEnvironment environment;

        public BiodataController(ApplicationContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult PersonalDetailsCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PersonalDetailsCreate(Personaldetails model)
        {
            if (ModelState.IsValid)
            {
                var personaldetails = new Personaldetails()
                {
                    Name = model.Name,
                    Dateoftime = model.Dateoftime,
                    TimeOfBirth = model.TimeOfBirth,
                    PlaceOfBirth = model.PlaceOfBirth,
                    Rasi = model.Rasi,
                    Nakshtra = model.Nakshtra,
                    Complexion = model.Complexion,
                    Height = model.Height,
                    Education = model.Education,
                    Cast = model.Cast,
                    Job = model.Job
                };
                context.personaldetails.Add(personaldetails);
                context.SaveChanges();
                TempData["error"] = "Record Submit";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["message"] = "Empty field can't Submit";
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public IActionResult FamilyDetailsCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FamilyDetailsCreate(Familydetails model)
        {
            if (ModelState.IsValid)
            {
                var familydetails = new Familydetails()
                {
                    FatherName = model.FatherName,
                    FatherOccupation = model.FatherOccupation,
                    MotherName = model.MotherName,
                    MotherOccupation = model.MotherOccupation,
                    ElderBrotherName = model.ElderBrotherName,
                    ElderBrotherOccupation = model.ElderBrotherOccupation,
                    YoungerBrotherName = model.YoungerBrotherName,
                    YoungerBrotherOccupation = model.YoungerBrotherName,
                    ElderSisterName = model.ElderSisterName,
                    ElderSisterOccupation = model.ElderSisterOccupation,
                    YoungerSisterName = model.YoungerSisterName,
                    YoungerSisterOccupation = model.YoungerSisterOccupation
                };
                  context.familydetails.Add(familydetails);
                 context.SaveChanges();
                TempData["error"] = "Record Submit";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["message"] = "Empty field can't Submit";
                return RedirectToAction("Index", "Home");                           
            }
        }

        [HttpGet]
        public IActionResult ContactDetailsCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactDetailsCreate(Contactdetails model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string uniqueFileName = UploadImage(model);
                    var data = new Contactdetails()
                    {
                        ContactNo = model.ContactNo,
                        Address = model.Address,
                        Path = uniqueFileName
                    };
                    context.contactdetails.Add(data);
                    context.SaveChanges();
                    TempData["Success"] = "Record Successfuly saved!";
                    return RedirectToAction("Index","Home");
                }
                ModelState.AddModelError(string.Empty, "Model is not valid");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View("Index", "Home");
        }
        public string UploadImage(Contactdetails model)
        {
            string uniqueFileName = string.Empty;
            if (model.ImageFile != null)
            {
                string uploadfolder = Path.Combine(environment.WebRootPath, "Content/Image/");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
                string filePath = Path.Combine(uploadfolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        [HttpPost]
        public async Task<IActionResult> SaveAllData(SubmitViewmodel obj , string command)
        {
            //string uniqueFileName = UploadImage(obj);
            if (command == "Next")
                {
                    Personaldetails personaldetails = new Personaldetails()
                    {
                        Name = obj.Name,
                        Dateoftime = obj.Dateoftime,
                        TimeOfBirth = obj.TimeOfBirth,
                        PlaceOfBirth = obj.PlaceOfBirth,
                        Rasi = obj.Rasi,
                        Nakshtra = obj.Nakshtra,
                        Complexion = obj.Complexion,
                        Height = obj.Height,
                        Education = obj.Education,
                        Cast = obj.Cast,
                        Job = obj.Job
                    };

                    context.personaldetails.Add(personaldetails);
                context.SaveChanges();
               // return RedirectToAction("EnterFamilyDetails", new { personalDetailsId = personaldetails.Id });

            } 
                else if (command == "NexT")
                {
                //int personalDetailsId = Convert.ToInt32(Request.Query["personalDetailsId"]);
                //Personaldetails personaldetails = context.personaldetails.FirstOrDefault(p => p.Id == personalDetailsId);
                //if (personaldetails == null)
                //{
                //    return RedirectToAction("_PersonalDetails");
                //}

                Familydetails familydetails = new Familydetails()
                    {
                        FatherName = obj.FatherName,
                        FatherOccupation = obj.FatherOccupation,
                        MotherName = obj.MotherName,
                        MotherOccupation = obj.MotherOccupation,
                        ElderBrotherName = obj.ElderBrotherName,
                        ElderBrotherOccupation = obj.ElderBrotherOccupation,
                        YoungerBrotherName = obj.YoungerBrotherName,
                        YoungerBrotherOccupation = obj.YoungerBrotherName,
                        ElderSisterName = obj.ElderSisterName,
                        ElderSisterOccupation = obj.ElderSisterOccupation,
                        YoungerSisterName = obj.YoungerSisterName,
                        YoungerSisterOccupation = obj.YoungerSisterOccupation
                    };
                    context.familydetails.Add(familydetails);
                    context.SaveChanges();

            }
                else if (command == "SUBMIT")
                {
                
                var data = new Contactdetails()
                {
                    ContactNo = obj.ContactNo,
                    Address = obj.Address,
                   // Path = uniqueFileName
                };
                context.contactdetails.Add(data);
                context.SaveChanges();
            }
          
            return RedirectToAction("Index", "Home");
        }
    }
}
