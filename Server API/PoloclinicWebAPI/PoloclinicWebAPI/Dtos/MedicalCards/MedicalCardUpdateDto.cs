using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoloclinicWebAPI.Dtos.MedicalCards
{
    public class MedicalCardUpdateDto
    {
        public int? IdPatient { get; set; }
        public int? IdDoctor { get; set; }
        public DateTime DateOfVisit { get; set; }
        [StringLength(2000)]
        public string ReaseachProtacol { get; set; }
        [StringLength(2000)]
        public string Conclusion { get; set; }
        public int? IdDiagnosis { get; set; }
        [StringLength(2000)]
        public string Recomendatein { get; set; }
    }
}
