using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PoloclinicWebAPI.Models
{
    [Table("Specialization")]
    public partial class Specialization
    {
        public Specialization()
        {
            Doctors = new HashSet<Doctor>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("Specialization")]
        [StringLength(30)]
        public string Specialization1 { get; set; }

        [InverseProperty(nameof(Doctor.IdSpecializationNavigation))]
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
