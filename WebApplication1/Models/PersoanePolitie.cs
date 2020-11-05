using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public partial class PersoanePolitie
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        [Required]
        [MaxLength(13)]
        [MinLength(13)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "CNP must be numeric")]
        public string Cnp { get; set; }
        public bool Permis { get; set; }
        public bool Cazier { get; set; }
    }
}
