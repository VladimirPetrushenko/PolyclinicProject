using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoloclinicWebAPI.Dtos.Qualifications
{
    public class QualificationCreateDto
    {
        [Required]
        [StringLength(20)]
        public string Qualification1 { get; set; }
    }
}
