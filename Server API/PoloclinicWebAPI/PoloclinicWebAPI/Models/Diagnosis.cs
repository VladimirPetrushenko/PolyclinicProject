using System;
using System.Collections.Generic;

#nullable disable

namespace PoloclinicWebAPI.Models
{
    public partial class Diagnosis
    {
        public Diagnosis()
        {
            MedicalCards = new HashSet<MedicalCard>();
        }

        public int Id { get; set; }
        public string CodeMrb10 { get; set; }
        public string Diagnosis1 { get; set; }

        public virtual ICollection<MedicalCard> MedicalCards { get; set; }
    }
}
