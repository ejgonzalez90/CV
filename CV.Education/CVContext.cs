using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CV.Education
{
    public partial class CVContext : DbContext
    {
        public CVContext()
        {
        }

        public CVContext(DbContextOptions<CVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Education> Education { get; set; }
        public virtual DbSet<PersonCertifications> PersonCertifications { get; set; }
        public virtual DbSet<PersonExams> PersonExams { get; set; }
        public virtual DbSet<PersonSkills> PersonSkills { get; set; }
        public virtual DbSet<PhoneTypes> PhoneTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=CV;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Education>(entity =>
            {
                entity.ToTable("Education", "Education");

                entity.Property(e => e.DateFrom).HasColumnType("date");

                entity.Property(e => e.DateTo).HasColumnType("date");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Enabled)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Institute)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PersonCertifications>(entity =>
            {
                entity.HasKey(e => e.PersonCertificationId);

                entity.ToTable("PersonCertifications", "Education");

                entity.Property(e => e.PersonCertificationId).ValueGeneratedNever();

                entity.Property(e => e.CertificationNumber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DateAchieved).HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PersonExams>(entity =>
            {
                entity.HasKey(e => e.PersonExamId);

                entity.ToTable("PersonExams", "Education");

                entity.Property(e => e.PersonExamId).ValueGeneratedNever();

                entity.Property(e => e.DateAchieved).HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ExamCode)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PersonSkills>(entity =>
            {
                entity.HasKey(e => e.PersonSkillId);

                entity.ToTable("PersonSkills", "Education");

                entity.Property(e => e.PersonSkillId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.Knowledge).HasColumnType("numeric(5, 4)");
            });

            modelBuilder.Entity<PhoneTypes>(entity =>
            {
                entity.HasKey(e => e.PhoneTypeId);

                entity.ToTable("PhoneTypes", "MasterData");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });
        }
    }
}
