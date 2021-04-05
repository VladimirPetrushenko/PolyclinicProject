using System;
using System.Collections.Generic;

#nullable disable

namespace PoloclinicWebAPI.Models
{
    public partial class Qualification
    {
        public Qualification()
        {
            Doctors = new HashSet<Doctor>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
