using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PoloclinicWebAPI.Models
{
    [Table("MedicalCard")]
    public partial class MedicalCard
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("idPatient")]
        public int? IdPatient { get; set; }
        [Column("idDoctor")]
        public int? IdDoctor { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateOfVisit { get; set; }
        [StringLength(2000)]
        public string ReaseachProtacol { get; set; }
        [StringLength(2000)]
        public string Conclusion { get; set; }
        [Column("idDiagnosis")]
        public int? IdDiagnosis { get; set; }
        [StringLength(2000)]
        public string Recomendatein { get; set; }

        [ForeignKey(nameof(IdDiagnosis))]
        [InverseProperty(nameof(Diagnosis.MedicalCards))]
        public virtual Diagnosis IdDiagnosisNavigation { get; set; }
        [ForeignKey(nameof(IdDoctor))]
        [InverseProperty(nameof(Doctor.MedicalCards))]
        public virtual Doctor IdDoctorNavigation { get; set; }
        [ForeignKey(nameof(IdPatient))]
        [InverseProperty(nameof(Patient.MedicalCards))]
        public virtual Patient IdPatientNavigation { get; set; }
    }
}
