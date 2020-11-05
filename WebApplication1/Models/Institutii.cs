using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public partial class Institutii
    {
        public Institutii()
        {
            Cereri = new HashSet<Cereri>();
        }

        [Key]
        public int Id { get; set; }

        [DisplayName("Nume Institutie")]
        public string NumeInstitutie { get; set; }

        public virtual ICollection<Cereri> Cereri { get; set; }
    }
}
