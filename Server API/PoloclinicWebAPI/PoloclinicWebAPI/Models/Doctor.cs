using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PoloclinicWebAPI.Models
{
    [Table("Doctor")]
    public partial class Doctor
    {
        public Doctor()
        {
            MedicalCards = new HashSet<MedicalCard>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
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
        [Column("idQualification")]
        public int? IdQualification { get; set; }
        [Column("idSpecialization")]
        public int? IdSpecialization { get; set; }

        [ForeignKey(nameof(IdQualification))]
        [InverseProperty(nameof(Qualification.Doctors))]
        public virtual Qualification IdQualificationNavigation { get; set; }
        [ForeignKey(nameof(IdSpecialization))]
        [InverseProperty(nameof(Specialization.Doctors))]
        public virtual Specialization IdSpecializationNavigation { get; set; }
        [InverseProperty(nameof(MedicalCard.IdDoctorNavigation))]
        public virtual ICollection<MedicalCard> MedicalCards { get; set; }
    }
}
