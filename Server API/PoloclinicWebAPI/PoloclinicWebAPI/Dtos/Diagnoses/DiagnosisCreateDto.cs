using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoloclinicWebAPI.Dtos.Diagnoses
{
    public class DiagnosisCreateDto
    {
        [Required]
        [StringLength(5)]
        public string CodeMrb10 { get; set; }
        [Required]
        [StringLength(2000)]
        public string Diagnosis1 { get; set; }
    }
}
