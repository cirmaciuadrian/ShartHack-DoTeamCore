using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public partial class PersoaneMedic
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }

        [Required]
        [MaxLength(13)]
        [MinLength(13)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "CNP must be numeric")]
        public string Cnp { get; set; }
        [DisplayName("Boli Cronice")]
        public bool BoliCronice { get; set; }
    }
}
