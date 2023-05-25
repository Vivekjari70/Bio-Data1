using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bio_Data.Models
{
    public class Contactdetails
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Contact No can't be blank.")]
        public int ContactNo { get; set; }
        [Required(ErrorMessage = " Address can't be blank.")]
        public string Address { get; set; }
        public string Path { get; set; }
        [NotMapped]
        [Required(ErrorMessage = " Profile Picture can't be blank.")]
        public IFormFile ImageFile { get; set; }
    }
}
