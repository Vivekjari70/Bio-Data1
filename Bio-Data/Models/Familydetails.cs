using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bio_Data.Models
{
    public class Familydetails
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = " Father Name can't be blank.")]
        public string FatherName { get; set; }
        [Required(ErrorMessage = " Father Occupation can't be blank.")]

        public string FatherOccupation { get; set; }
        [Required(ErrorMessage = " Mother Name can't be blank.")]
        public string MotherName { get; set; }
        [Required(ErrorMessage = " Mother Occupation can't be blank.")]

        public string MotherOccupation { get; set; }
        
        public string ElderBrotherName{ get; set; }
        
        public string ElderBrotherOccupation { get; set; }
        
        public string YoungerBrotherName { get; set; }
        
        public string YoungerBrotherOccupation { get; set; }
        
        public string ElderSisterName { get; set; }
       
        public string ElderSisterOccupation { get; set; }
        
        public string YoungerSisterName { get; set; }
       
        public string YoungerSisterOccupation { get; set; }
    }
}
