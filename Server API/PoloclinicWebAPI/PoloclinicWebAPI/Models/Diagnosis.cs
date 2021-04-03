using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PoloclinicWebAPI.Models
{
    [Table("Diagnosis")]
    public partial class Diagnosis
    {
        public Diagnosis()
        {
            MedicalCards = new HashSet<MedicalCard>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column("CodeMRB_10")]
        [StringLength(5)]
        public string CodeMrb10 { get; set; }
        [Required]
        [Column("Diagnosis")]
        [StringLength(2000)]
        public string Diagnosis1 { get; set; }

        [InverseProperty(nameof(MedicalCard.IdDiagnosisNavigation))]
        public virtual ICollection<MedicalCard> MedicalCards { get; set; }
    }
}
