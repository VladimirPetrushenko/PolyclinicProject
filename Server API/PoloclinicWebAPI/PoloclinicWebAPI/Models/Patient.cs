using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PoloclinicWebAPI.Models
{
    [Table("Patient")]
    public partial class Patient
    {
        public Patient()
        {
            MedicalCards = new HashSet<MedicalCard>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
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

        [InverseProperty(nameof(MedicalCard.IdPatientNavigation))]
        public virtual ICollection<MedicalCard> MedicalCards { get; set; }
    }
}
