using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAppPatients.Models
{
    public partial class PersonsDbContext : DbContext
    {
        public PersonsDbContext()
        {
        }

        public PersonsDbContext(DbContextOptions<PersonsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Doctors> Doctors { get; set; }
        public virtual DbSet<Medicaments> Medicaments { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<PrescriptionMedicament> PrescriptionMedicament { get; set; }
        public virtual DbSet<Prescriptions> Prescriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctors>(entity =>
            {
                entity.HasKey(x => x.IdDoctor);

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();
            });

            modelBuilder.Entity<Medicaments>(entity =>
            {
                entity.HasKey(x => x.IdMedicament);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Type).IsRequired();
            });

            modelBuilder.Entity<Patients>(entity =>
            {
                entity.HasKey(x => x.IdPatient);

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();
            });

            modelBuilder.Entity<PrescriptionMedicament>(entity =>
            {
                entity.HasKey(x => new { x.IdMedicament, x.IdPrescription });

                entity.HasIndex(x => x.IdPrescription);

                entity.Property(e => e.Details).IsRequired();

                entity.HasOne(d => d.IdMedicamentNavigation)
                    .WithMany(p => p.PrescriptionMedicament)
                    .HasForeignKey(x => x.IdMedicament);

                entity.HasOne(d => d.IdPrescriptionNavigation)
                    .WithMany(p => p.PrescriptionMedicament)
                    .HasForeignKey(x => x.IdPrescription);
            });

            modelBuilder.Entity<Prescriptions>(entity =>
            {
                entity.HasKey(x => x.IdPrescription);

                entity.HasIndex(x => x.IdDoctor);

                entity.HasIndex(x => x.IdPatient);

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(x => x.IdDoctor);

                entity.HasOne(d => d.IdPatientNavigation)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(x => x.IdPatient);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
