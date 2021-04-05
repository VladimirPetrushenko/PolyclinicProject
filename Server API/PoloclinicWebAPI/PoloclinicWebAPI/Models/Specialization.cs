using System;
using System.Collections.Generic;

#nullable disable

namespace PoloclinicWebAPI.Models
{
    public partial class Specialization
    {
        public Specialization()
        {
            Doctors = new HashSet<Doctor>();
        }

        public int Id { get; set; }
        public string Specialization1 { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
