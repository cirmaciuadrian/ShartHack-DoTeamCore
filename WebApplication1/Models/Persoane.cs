using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public partial class Persoane
    {
        public Persoane()
        {
            Cereri = new HashSet<Cereri>();
        }

        [Required]
        [MaxLength(13)]
        [MinLength(13)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "CNP must be numeric")]
        public string Cnp { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Serie { get; set; }
        public string Numar { get; set; }
        public string Adresa { get; set; }
        public string Oras { get; set; }

        [Column("DataNasterii", TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayName("Data Nasterii")]
        public DateTime DataNasterii { get; set; }

        [DisplayName("Status Politie")]
        public string StatusPolitie { get; set; }
        [DisplayName("Status Medic")]
        public string StatusMedic { get; set; }

        [DisplayName("Status Universitate")]
        public bool? StatusUniversitate { get; set; }

        public virtual ICollection<Cereri> Cereri { get; set; }
    }
}
