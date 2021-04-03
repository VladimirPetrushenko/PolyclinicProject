using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoloclinicWebAPI.Dtos.MedicalCards
{
    public class MedicalCardReadDto
    {
        public int Id { get; set; }
        public int? IdPatient { get; set; }
        public int? IdDoctor { get; set; }
        public DateTime DateOfVisit { get; set; }
        public string ReaseachProtacol { get; set; }
        public string Conclusion { get; set; }
        public int? IdDiagnosis { get; set; }
        public string Recomendatein { get; set; }
    }
}
