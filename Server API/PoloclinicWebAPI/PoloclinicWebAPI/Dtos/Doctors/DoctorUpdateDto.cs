using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoloclinicWebAPI.Dtos.Doctors
{
    public class DoctorUpdateDto
    {
        public int? Age { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
        [Required]
        [StringLength(30)]
        public string Address { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        public int QualificationId { get; set; }
        public int SpecializationId { get; set; }
    }
}
