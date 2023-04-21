using Bio_Data.Data;
using DinkToPdf;
using DinkToPdf.Contracts;
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

        public PdfController1(ApplicationContext context, IConverter converter)
        {
            this.context = context;
            this.converter = converter;
        }
        [HttpGet]
        public async Task<string> CreatePDF()
        {
            var pd = await context.personaldetails.OrderByDescending(e => e.Id).FirstOrDefaultAsync();
            var fd = await context.familydetails.OrderByDescending(e => e.Id).FirstOrDefaultAsync();
            var cd = await context.contactdetails.OrderByDescending(e => e.Id).FirstOrDefaultAsync();
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
        public async Task<IActionResult> CreatePDF1()
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
                HtmlContent = await CreatePDF(),
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

        public IActionResult borderimage()
        {
            return View();
        }
    }
}
    

