using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoloclinicWebAPI.Dtos.Patients
{
    public class PatientCreateDto
    {
        public int? Age { get; set; }
        [StringLength(30)]
        public string FirstName { get; set; }
        [StringLength(30)]
        public string LastName { get; set; }
        [StringLength(30)]
        public string Address { get; set; }
        [StringLength(30)]
        public string Phone { get; set; }
        [StringLength(9)]
        public string Passport { get; set; }
    }
}
