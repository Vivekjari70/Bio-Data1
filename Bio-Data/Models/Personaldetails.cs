using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bio_Data.Models
{
    public class Personaldetails
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = " Name can't be blank.")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = " Date of time can't be blank.")]
        public DateTime  Dateoftime { get; set; }
        [Required(ErrorMessage = " Time Of Birth can't be blank.")]
        [DataType(DataType.Time)]
        public DateTime TimeOfBirth { get; set; }
        [Required(ErrorMessage = " Place Of Birth can't be blank.")]
        public string PlaceOfBirth { get; set; }
        [Required(ErrorMessage = " Rasi can't be blank.")]
        public string Rasi { get; set; }
        [Required(ErrorMessage = " Nakshtra can't be blank.")]
        public string Nakshtra { get; set; }
        [Required(ErrorMessage = " Complexion can't be blank.")]
        public string Complexion { get; set; }
        [Required(ErrorMessage = " Height can't be blank.")]
        public decimal Height { get; set; }
        [Required(ErrorMessage = " Education can't be blank.")]
        public string Education { get; set; }
        [Required(ErrorMessage = " Cast can't be blank.")]
        public string Cast { get; set; }
        [Required(ErrorMessage = " Job can't be blank.")]
        public string Job { get; set; }



    }
}
