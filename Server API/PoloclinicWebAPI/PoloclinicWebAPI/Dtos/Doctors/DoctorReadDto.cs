using PoloclinicWebAPI.Dtos.Qualifications;
using PoloclinicWebAPI.Dtos.Specializations;
using PoloclinicWebAPI.Models;
using PoloclinicWebAPI.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoloclinicWebAPI.Dtos.Doctors
{
    public class DoctorReadDto
    {
        public int Id { get; set; }
        public int? Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int QualificationId { get; set; }
        public int SpecializationId { get; set; }
        public virtual SpecializationReadDto Specialization { get; set; }
        public virtual QualificationReadDto Qualification { get; set; }
    }
}
