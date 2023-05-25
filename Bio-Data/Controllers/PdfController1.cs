using Bio_Data.Data;
using Bio_Data.Models;
using Bio_Data.Models.ViewModel;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bio_Data.Controllers
{
    public class PdfController1 : Controller
    {
        private readonly ApplicationContext context;
        private readonly IConverter converter;
        private readonly IWebHostEnvironment environment;

        public PdfController1(ApplicationContext context, IConverter converter, IWebHostEnvironment environment)
        {
            this.context = context;
            this.converter = converter;
            this.environment = environment;
        }
        [HttpGet]
        public async Task<string> CreatePDF(int id)
        {
            //var pd = await context.personaldetails.OrderByDescending(e => e.Id).FirstOrDefaultAsync();
            //var fd = await context.familydetails.OrderByDescending(e => e.Id).FirstOrDefaultAsync();
            //var cd = await context.contactdetails.OrderByDescending(e => e.Id).FirstOrDefaultAsync();
            var pd = await context.personaldetails.FindAsync(id);
            var fd = await context.familydetails.FindAsync(id);
            var cd = await context.contactdetails.FindAsync(id);
            var profileImageString = "Content/Image/" + cd.Path; 
            var profileImageUrl = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host.Value + "/" + profileImageString;
            var sb = new StringBuilder();
            sb.Append(@"
                <html>
                    <head>
                 <style>
                    .image { width: 80px;
                        height: 80px; }
        }
                 </style>
                    </head>
                    <body>
                            <div class='borderimg2' >
                              <div style='position: absolute; top: 75; right: 25;border: 2px solid black'>
                             <img src='" + profileImageUrl + @"' width='250' height='250'  >
                              </div>
                        
                        <div class='header'>
                            <img src='https://createmybiodata.com/r12.png' class='image' />
                            <h1>Bio-Data</h1>
                        </div>
                        <div class='header1'><h1>Personal Details</h1></div>
                        <table align='center'>
                            <tr>
                                <th>Name:</th>
                                <td>" + pd.Name + @"</td>
                            </tr>
                                <tr>
                                <th>Date of time:</th>
                                <td>" + pd.Dateoftime + @"</td>
                            </tr>
                                <tr>
                                <th>Time Of Birth:</th>
                                <td>" + pd.TimeOfBirth + @"</td>
                            </tr>
                                <tr>
                                <th>Place Of Birth:</th>
                                <td>" + pd.PlaceOfBirth + @"</td>
                            </tr>
                                 <tr>
                                <th>Rashi:</th>
                                <td>" + pd.Rasi + @"</td>
                            </tr>
                                 <tr>
                                <th>Nakshtra:</th>
                                <td>" + pd.Nakshtra + @"</td>
                            </tr>
                                <tr>
                                <th>Complexion:</th>
                                <td>" + pd.Complexion + @"</td>
                            </tr>
                                 <tr>
                                <th>Height:</th>
                                <td>" + pd.Height + @"</td>
                            </tr>
                            <tr>
                                <th>Education:</th>
                                <td>" + pd.Education + @"</td>
                            </tr>
                            <tr>
                                <th>Cast:</th>
                                <td>" + pd.Cast + @"</td>
                            </tr>
                                <tr>
                                <th>Job:</th>
                                <td>" + pd.Job + @"</td>
                            </tr>
                        </table>
                         <div class='header1'><h1>Family Details</h1></div>
                        <table align='center'>
                            <tr>
                                <th>Father Name:</th>
                                <td>" + fd.FatherName + @"</td>
                            </tr>
                                <tr>
                                <th>Father Occupation:</th>
                                <td>" + fd.FatherOccupation + @"</td>
                            </tr>
                                <tr>
                                <th>Mother Name:</th>
                                <td>" + fd.MotherName + @"</td>
                            </tr>
                                <tr>
                                <th>Mother Occupation:</th>
                                <td>" + fd.MotherOccupation + @"</td>
                            </tr>
                                 <tr>
                                <th>Elder Brother Name:</th>
                                <td>" + fd.ElderBrotherName + @"</td>
                            </tr>
                                 <tr>
                                <th>Elder Brother Occupation:</th>
                                <td>" + fd.ElderBrotherOccupation + @"</td>
                            </tr>
                                <tr>
                                <th>Younger Brother Name:</th>
                                <td>" + fd.YoungerBrotherName + @"</td>
                            </tr>
                                 <tr>
                                <th>Younger Brother Occupation:</th>
                                <td>" + fd.YoungerBrotherOccupation + @"</td>
                            </tr>
                            <tr>
                                <th>Elder Sister Name:</th>
                                <td>" + fd.ElderSisterName + @"</td>
                            </tr>
                            <tr>
                                <th>Elder Sister Occupation:</th>
                                <td>" + fd.ElderSisterOccupation + @"</td>
                            </tr>
                                <tr>
                                <th>Younger Sister Name:</th>
                                <td>" + fd.YoungerSisterName + @"</td>
                            </tr>
                                 <tr>
                                <th>Younger Sister Occupation:</th>
                                <td>" + fd.YoungerSisterOccupation + @"</td>
                            </tr>
                        </table>
                            <div class='header1'><h1>Contact Details</h1></div>
                        <table align='center' class='table1'>
                            <tr>
                                <th>Contact No:</th>
                                <td>" + cd.ContactNo + @"</td>
                            </tr>
                                <tr>
                                <th>Address:</th>
                                <td>" + cd.Address + @"</td>
                            </tr>
                        </table>
                        </div>
                    </body>
                </html>");

            return sb.ToString();
        }

        [HttpGet]
        public async Task<IActionResult> CreatePDF1(int id)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color, 
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = await CreatePDF(id),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "StyleSheet.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, /*Right = "Page [page] of [toPage]"*/ Line = false },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = false}
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            var file = converter.Convert(pdf);
            return File(file, "application/pdf", "Biodata.pdf");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteBiodata(int id)
        {
            var biodata = await context.personaldetails.FindAsync(id);
            var familydata = await context.familydetails.FindAsync(id);
            var contactdata = await context.contactdetails.FindAsync(id);

            if (biodata != null || familydata != null || contactdata != null)
            {
                context.personaldetails.Remove(biodata);
                context.familydetails.Remove(familydata);
                context.contactdetails.Remove(contactdata);
                await context.SaveChangesAsync();
            }
            else if (biodata == null || familydata == null || contactdata == null)
            {
                context.personaldetails.Remove(biodata);
                context.familydetails.Remove(familydata);
                context.contactdetails.Remove(contactdata);
                await context.SaveChangesAsync();
            }
           
            
            return RedirectToAction("GetBiodata","Home");
        }

        [HttpGet]
        public IActionResult Edit(int id, IFormFile file)
        {
            // Retrieve the biodata entry with the given id from the database
            var biodata = context.personaldetails.Find(id);
            var biodata1 = context.familydetails.Find(id);
            var biodata2 = context.contactdetails.Find(id);

            if (biodata != null || biodata1 != null || biodata2 !=null)
            {

                
                // Create a new instance of Personaldetails
                var personalDetails = new BiodataViewModel();

                // Map the properties from the biodata entry to the personalDetails object
                personalDetails.Id = biodata.Id;
                personalDetails.Name = biodata.Name;
                personalDetails.Dateoftime = biodata.Dateoftime;
                personalDetails.TimeOfBirth = biodata.TimeOfBirth;
                personalDetails.PlaceOfBirth = biodata.PlaceOfBirth;
                personalDetails.Rasi = biodata.Rasi;
                personalDetails.Nakshtra = biodata.Nakshtra;
                personalDetails.Complexion = biodata.Complexion;
                personalDetails.Height = biodata.Height;
                personalDetails.Cast = biodata.Cast;
                personalDetails.Education = biodata.Education;
                personalDetails.Job = biodata.Job;
                personalDetails.FatherName = biodata1.FatherName;
                personalDetails.FatherOccupation = biodata1.FatherOccupation;
                personalDetails.MotherName = biodata1.MotherName;
                personalDetails.MotherOccupation = biodata1.MotherOccupation;
                personalDetails.ElderBrotherName = biodata1.ElderBrotherName;
                personalDetails.ElderBrotherOccupation = biodata1.ElderBrotherOccupation;
                personalDetails.YoungerBrotherName = biodata1.YoungerBrotherName;
                personalDetails.YoungerBrotherOccupation = biodata1.YoungerBrotherOccupation;
                personalDetails.ElderSisterName = biodata1.ElderSisterName;
                personalDetails.ElderSisterOccupation = biodata1.ElderSisterOccupation;
                personalDetails.YoungerSisterName = biodata1.YoungerSisterName;
                personalDetails.YoungerSisterOccupation = biodata1.YoungerSisterOccupation;
                personalDetails.ContactNo = biodata2.ContactNo;
                personalDetails.Address = biodata2.Address;

                if (file != null)
                {
                    string filename = System.Guid.NewGuid().ToString() + ".jpg";
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Content", "Image", filename);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    personalDetails.Path = filename;
                }
                else
                {
                    personalDetails.Path = biodata2.Path;
                }
                personalDetails.ImageFile = biodata2.ImageFile;

                // Populate other properties as needed
                return View(personalDetails);
            }

            return RedirectToAction("GetBiodata", "Home");
        }

        [HttpPost]
        public IActionResult Edit(int id,BiodataViewModel model)
        {
                // Retrieve the biodata entry with the given id from the database
                var biodata = context.personaldetails.Find(model.Id);
                var biodata1 = context.familydetails.Find(model.Id);
                var biodata2 = context.contactdetails.Find(model.Id);

                if (biodata != null)
                {
                    // Update the properties of the biodata entry with the submitted form data
                    biodata.Name = model.Name;
                    biodata.Dateoftime = model.Dateoftime;
                    biodata.TimeOfBirth = model.TimeOfBirth;
                    biodata.PlaceOfBirth = model.PlaceOfBirth;
                    biodata.Rasi = model.Rasi;
                    biodata.Nakshtra = model.Nakshtra;
                    biodata.Complexion = model.Complexion;
                    biodata.Height = model.Height;
                    biodata.Cast = model.Cast;
                    biodata.Education = model.Education;
                    biodata.Job = model.Job;
                    biodata1.FatherName = model.FatherName;
                    biodata1.FatherOccupation = model.FatherOccupation;
                    biodata1.MotherName = model.MotherName;
                    biodata1.MotherOccupation = model.MotherOccupation;
                    biodata1.ElderBrotherName = model.ElderBrotherName;
                    biodata1.ElderBrotherOccupation = model.ElderBrotherOccupation;
                    biodata1.YoungerBrotherName = model.YoungerBrotherName;
                    biodata1.YoungerBrotherOccupation = model.YoungerBrotherOccupation;
                    biodata1.ElderSisterName = model.ElderSisterName;
                    biodata1.ElderSisterOccupation = model.ElderSisterOccupation;
                    biodata1.YoungerSisterName = model.YoungerSisterName;
                    biodata1.YoungerSisterOccupation = model.YoungerSisterOccupation;
                    biodata2.ContactNo = model.ContactNo;
                    biodata2.Address = model.Address;

                    if (model.ImageFile != null)
                    {
                        string uploadfolder = Path.Combine(environment.WebRootPath, "Content/Image/");
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
                        string filePath = Path.Combine(uploadfolder, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            model.ImageFile.CopyTo(fileStream);
                        }
                        biodata2.ImageFile = model.ImageFile;
                        biodata2.Path = uniqueFileName;

                    if (!string.IsNullOrEmpty(biodata2.Path) && !string.IsNullOrEmpty(model.Path) && biodata2.Path != model.Path)
                    {
                        string existingFilePath = Path.Combine(environment.WebRootPath, model.Path);
                        if (System.IO.File.Exists(existingFilePath))
                        {
                            System.IO.File.Delete(existingFilePath);
                        }
                    }
                }


                // Update other properties as needed

                context.SaveChanges();

                    return RedirectToAction("GetBiodata", "Home");
                }
            

            // If the model is not valid or the biodata entry is not found, return the edit view with validation errors
            return View(model);
        }
    }
}
    

