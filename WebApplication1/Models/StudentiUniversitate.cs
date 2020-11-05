using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public partial class StudentiUniversitate
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }


        [Required]
        [MaxLength(13)]
        [MinLength(13)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "CNP must be numeric")]
        public string Cnp { get; set; }
        public string Facultate { get; set; }
        public string Specializare { get; set; }
        public string Stadiu { get; set; }
        public string An { get; set; }
    }
}
