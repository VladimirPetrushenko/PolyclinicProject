using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PoloclinicWebAPI.Models
{
    [Table("Qualification")]
    public partial class Qualification
    {
        public Qualification()
        {
            Doctors = new HashSet<Doctor>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column("Qualification")]
        [StringLength(20)]
        public string Qualification1 { get; set; }

        [InverseProperty(nameof(Doctor.IdQualificationNavigation))]
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
