using System;
using System.Collections.Generic;

#nullable disable

namespace PoloclinicWebAPI.Models
{
    public partial class Patient
    {
        public Patient()
        {
            MedicalCards = new HashSet<MedicalCard>();
        }

        public int Id { get; set; }
        public int? Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Passport { get; set; }

        public virtual ICollection<MedicalCard> MedicalCards { get; set; }
    }
}
