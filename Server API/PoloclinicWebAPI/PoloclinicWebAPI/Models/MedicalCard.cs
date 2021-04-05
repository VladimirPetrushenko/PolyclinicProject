using System;
using System.Collections.Generic;

#nullable disable

namespace PoloclinicWebAPI.Models
{
    public partial class MedicalCard
    {
        public int Id { get; set; }
        public int? IdPatient { get; set; }
        public int? IdDoctor { get; set; }
        public DateTime DateOfVisit { get; set; }
        public string ReaseachProtacol { get; set; }
        public string Conclusion { get; set; }
        public int? IdDiagnosis { get; set; }
        public string Recomendatein { get; set; }

        public virtual Diagnosis IdDiagnosisNavigation { get; set; }
        public virtual Doctor IdDoctorNavigation { get; set; }
        public virtual Patient IdPatientNavigation { get; set; }
    }
}
