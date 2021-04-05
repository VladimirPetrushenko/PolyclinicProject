using System;
using System.Collections.Generic;

#nullable disable

namespace PoloclinicWebAPI.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            MedicalCards = new HashSet<MedicalCard>();
        }

        public int Id { get; set; }
        public int? Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int QualificationId { get; set; }
        public int IdSpecialization { get; set; }

        public virtual Specialization IdSpecializationNavigation { get; set; }
        public virtual Qualification Qualification { get; set; }
        public virtual ICollection<MedicalCard> MedicalCards { get; set; }
    }
}
