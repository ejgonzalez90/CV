using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CV.People
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

        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<PersonEmails> PersonEmails { get; set; }
        public virtual DbSet<PersonHobbies> PersonHobbies { get; set; }
        public virtual DbSet<PersonPhones> PersonPhones { get; set; }
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
            modelBuilder.Entity<People>(entity =>
            {
                entity.HasKey(e => e.PersonId);

                entity.ToTable("People", "People");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.WebSite)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PersonEmails>(entity =>
            {
                entity.HasKey(e => e.PersonEmailId);

                entity.ToTable("PersonEmails", "People");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonEmails)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonEmails_People");
            });

            modelBuilder.Entity<PersonHobbies>(entity =>
            {
                entity.HasKey(e => e.PersonHobbieId);

                entity.ToTable("PersonHobbies", "People");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonHobbies)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonHobbies_People");
            });

            modelBuilder.Entity<PersonPhones>(entity =>
            {
                entity.HasKey(e => e.PersonPhoneId);

                entity.ToTable("PersonPhones", "People");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonPhones)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonPhones_People");

                entity.HasOne(d => d.PhoneType)
                    .WithMany(p => p.PersonPhones)
                    .HasForeignKey(d => d.PhoneTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonPhones_PhoneTypes");
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
