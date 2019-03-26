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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=CV;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.JobTitle).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.MiddleName).IsUnicode(false);

                entity.Property(e => e.WebSite).IsUnicode(false);
            });

            modelBuilder.Entity<PersonEmails>(entity =>
            {
                entity.Property(e => e.EmailAddress).IsUnicode(false);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonEmails)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonEmails_People");
            });

            modelBuilder.Entity<PersonHobbies>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonHobbies)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonHobbies_People");
            });

            modelBuilder.Entity<PersonPhones>(entity =>
            {
                entity.Property(e => e.PhoneNumber).IsUnicode(false);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonPhones)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonPhones_People");
            });
        }
    }
}
