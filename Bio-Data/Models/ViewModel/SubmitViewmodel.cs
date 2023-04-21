using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bio_Data.Models.ViewModel
{
    public class SubmitViewmodel
    {
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "* Dateoftime can't be blank.")]
        public DateTime Dateoftime { get; set; }
        [Required(ErrorMessage = "* TimeOfBirth can't be blank.")]
        [DataType(DataType.Time)]
        public DateTime TimeOfBirth { get; set; }
        [Required(ErrorMessage = "* PlaceOfBirth can't be blank.")]
        public string PlaceOfBirth { get; set; }
        [Required(ErrorMessage = "* Rasi can't be blank.")]
        public string Rasi { get; set; }
        [Required(ErrorMessage = "* Nakshtra can't be blank.")]
        public string Nakshtra { get; set; }
        [Required(ErrorMessage = "* Complexion can't be blank.")]
        public string Complexion { get; set; }
        [Required(ErrorMessage = "* Height can't be blank.")]
        public decimal Height { get; set; }
        [Required(ErrorMessage = "* Education can't be blank.")]
        public string Education { get; set; }
        [Required(ErrorMessage = "* Cast can't be blank.")]
        public string Cast { get; set; }
        [Required(ErrorMessage = "* Job can't be blank.")]
        public string Job { get; set; }

        [Required]
        public string FatherName { get; set; }
        [Required]
        public string FatherOccupation { get; set; }
        [Required]
        public string MotherName { get; set; }
        [Required]
        public string MotherOccupation { get; set; }
        [Required]
        public string ElderBrotherName { get; set; }
        [Required]
        public string ElderBrotherOccupation { get; set; }
        [Required]
        public string YoungerBrotherName { get; set; }
        [Required]
        public string YoungerBrotherOccupation { get; set; }
        [Required]
        public string ElderSisterName { get; set; }
        [Required]
        public string ElderSisterOccupation { get; set; }
        [Required]
        public string YoungerSisterName { get; set; }
        [Required]
        public string YoungerSisterOccupation { get; set; }

        public int ContactNo { get; set; }
        [Required]
        public string Address { get; set; }
        public string Path { get; set; }
        [NotMapped]
        [Required]
        public IFormFile ImageFile { get; set; }
    }
}
