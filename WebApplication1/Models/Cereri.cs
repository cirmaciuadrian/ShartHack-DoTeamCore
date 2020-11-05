using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public partial class Cereri
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        [DisplayName("Tip Cerere")]
        public string TipCerere { get; set; }

        [DisplayName("Id Institutie")]
        public int InstitutieId { get; set; }
        public string Status { get; set; }
        public DateTime Data { get; set; }

        public virtual Institutii Institutie { get; set; }
        public virtual Persoane User { get; set; }
    }
}
