using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VetClinic_Gui
{
    public partial class Veterinary_ClinicContext : DbContext
    {
        public Veterinary_ClinicContext()
        {
        }

        public Veterinary_ClinicContext(DbContextOptions<Veterinary_ClinicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<MedicalRecord> MedicalRecord { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<Species> Species { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-QVLTQOJG;Database=Veterinary_Clinic;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.SpecialistId)
                    .HasName("docPK");

                entity.Property(e => e.SpecialistId)
                    .HasColumnName("SpecialistID")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Specialist)
                    .WithOne(p => p.Doctor)
                    .HasForeignKey<Doctor>(d => d.SpecialistId)
                    .HasConstraintName("docFK");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerId)
                    .HasColumnName("ManagerID")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.InverseManager)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("empFK");
            });

            modelBuilder.Entity<MedicalRecord>(entity =>
            {
                entity.HasKey(e => e.AnimalId)
                    .HasName("PK__MedicalR__68745631AE67A9E2");

                entity.Property(e => e.AnimalId)
                    .HasColumnName("animalID")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DateLastVisit)
                    .HasColumnName("dateLastVisit")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.HeartwormShotDate)
                    .HasColumnName("heartwormShotDate")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Medicine)
                    .HasColumnName("medicine")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Neutered)
                    .HasColumnName("neutered")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RabiesShotDate)
                    .HasColumnName("rabiesShotDate")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SpecialistId)
                    .HasColumnName("SpecialistID")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Specialist)
                    .WithMany(p => p.MedicalRecord)
                    .HasForeignKey(d => d.SpecialistId)
                    .HasConstraintName("medFK");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.Property(e => e.OwnerId)
                    .HasColumnName("OwnerID")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AnimalId)
                    .HasColumnName("AnimalID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Patients>(entity =>
            {
                entity.HasKey(e => e.AnimalId)
                    .HasName("patientFK");

                entity.Property(e => e.AnimalId)
                    .HasColumnName("AnimalID")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerId)
                    .HasColumnName("OwnerID")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.SpeciesId)
                    .HasColumnName("speciesID")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("patientOwnFK");

                entity.HasOne(d => d.Species)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.SpeciesId)
                    .HasConstraintName("patientSpecFK");
            });

            modelBuilder.Entity<Species>(entity =>
            {
                entity.Property(e => e.SpeciesId)
                    .HasColumnName("speciesID")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.SpecialistId)
                    .HasColumnName("specialistID")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.SpeciesName)
                    .HasColumnName("speciesName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Specialist)
                    .WithMany(p => p.Species)
                    .HasForeignKey(d => d.SpecialistId)
                    .HasConstraintName("FK__Species__special__5EBF139D");
            });
        }
    }
}
