using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PoloclinicWebAPI.Models.DBContext
{
    public partial class PoliclinicContext : DbContext
    {
        public PoliclinicContext()
        {
        }

        public PoliclinicContext(DbContextOptions<PoliclinicContext> options)
            : base(options)
        {
            //создаёт базу данных если она отсутствует на компьютере
        //    Database.EnsureCreated();

            Diagnoses.ToList();
            Doctors.ToList();
            MedicalCards.ToList();
            Patients.ToList();
            Qualifications.ToList();
            Specializations.ToList();
        }

        public virtual DbSet<Diagnosis> Diagnoses { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<MedicalCard> MedicalCards { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Qualification> Qualifications { get; set; }
        public virtual DbSet<Specialization> Specializations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Policlinic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Qualification>(entity =>
            {
                entity.ToTable("Qualification");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Diagnosis>(entity =>
            {
                entity.ToTable("Diagnosis");

                entity.Property(e => e.CodeMrb10)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("CodeMRB_10");

                entity.Property(e => e.Diagnosis1)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .HasColumnName("Diagnosis");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("Doctor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Age).HasDefaultValueSql("((18))");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.SpecializationId).HasColumnName("SpecializationId");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.HasOne(d => d.Specialization)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.SpecializationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Doctor__idSpecia__3A81B327");

                entity.HasOne(d => d.Qualification)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.QualificationId);
            });

            modelBuilder.Entity<MedicalCard>(entity =>
            {
                entity.ToTable("MedicalCard");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Conclusion).HasMaxLength(2000);

                entity.Property(e => e.DateOfVisit).HasColumnType("datetime");

                entity.Property(e => e.IdDiagnosis).HasColumnName("idDiagnosis");

                entity.Property(e => e.IdDoctor).HasColumnName("idDoctor");

                entity.Property(e => e.IdPatient).HasColumnName("idPatient");

                entity.Property(e => e.ReaseachProtacol).HasMaxLength(2000);

                entity.Property(e => e.Recomendatein).HasMaxLength(2000);

                entity.HasOne(d => d.IdDiagnosisNavigation)
                    .WithMany(p => p.MedicalCards)
                    .HasForeignKey(d => d.IdDiagnosis)
                    .HasConstraintName("FK__MedicalCa__idDia__5EBF139D");

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.MedicalCards)
                    .HasForeignKey(d => d.IdDoctor)
                    .HasConstraintName("FK__MedicalCa__idDoc__5DCAEF64");

                entity.HasOne(d => d.IdPatientNavigation)
                    .WithMany(p => p.MedicalCards)
                    .HasForeignKey(d => d.IdPatient)
                    .HasConstraintName("FK__MedicalCa__idPat__5CD6CB2B");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('unknown')");

                entity.Property(e => e.Age).HasDefaultValueSql("((18))");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('unknown')");

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('unknown')");

                entity.Property(e => e.Passport)
                    .HasMaxLength(9)
                    .HasDefaultValueSql("('unknown')");

                entity.Property(e => e.Phone)
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('unknown')");
            });

            modelBuilder.Entity<Specialization>(entity =>
            {
                entity.ToTable("Specialization");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Specialization1)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("Specialization")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
