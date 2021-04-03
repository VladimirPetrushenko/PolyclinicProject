using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoloclinicWebAPI.Dtos.Specializations
{
    public class SpecializationUpdateDto
    {
        [Required]
        [StringLength(30)]
        public string Specialization1 { get; set; }
    }
}
