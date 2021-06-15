using Microsoft.EntityFrameworkCore;
using ContactListApp.Models;

#nullable disable

namespace ContactListApp.Data
{
    public partial class ContactAppDBContext : DbContext
    {

        public ContactAppDBContext()
        {
        }

        public ContactAppDBContext(DbContextOptions<ContactAppDBContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<ContactEmail> ContactEmails { get; set; }
        public virtual DbSet<ContactInfo> ContactInfos { get; set; }
        public virtual DbSet<ContactPhone> ContactPhones { get; set; }
        public virtual DbSet<ContactTag> ContactTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Croatian_CI_AS");

            modelBuilder.Entity<ContactEmail>(entity =>
            {
                entity.HasKey(e => e.EmailId)
                    .HasName("PK__ContactE__7ED91AEF757A6078");

                entity.ToTable("ContactEmail");

                entity.Property(e => e.EmailId).HasColumnName("EmailID");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.Email)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.ContactEmails)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ContactEmail_ContactInfo");
            });

            modelBuilder.Entity<ContactInfo>(entity =>
            {
                entity.HasKey(e => e.ContactId)
                    .HasName("PK__ContactI__5C6625BB38B7B168");

                entity.ToTable("ContactInfo");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.ContactAdress)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ContactFirstName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ContactLastName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ContactWorkInfo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ContactDateOfBirth)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ContactPhone>(entity =>
            {
                entity.HasKey(e => e.PhoneId);

                entity.ToTable("ContactPhone");

                entity.Property(e => e.PhoneId).HasColumnName("PhoneID");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.ContactPhones)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ContactPhone_ContactInfo");
            });

            modelBuilder.Entity<ContactTag>(entity =>
            {
                entity.HasKey(e => e.TagId);

                entity.Property(e => e.TagId).HasColumnName("TagID");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.Tag).HasMaxLength(50);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.ContactTags)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ContactTags_ContactInfo");
            });

            modelBuilder.Entity<ContactInfo>().HasData(
                new ContactInfo
                {
                    ContactId = 1,
                    ContactFirstName = "William",
                    ContactLastName = "Shakespeare",
                    ContactAdress = "Henley St, Stratford-upon-Avon CV37 6QW",
                    ContactWorkInfo = "Writer",
                    ContactDateOfBirth = "26/04/1564"
                }
            );
            modelBuilder.Entity<ContactEmail>().HasData(
                new ContactEmail { EmailId = 1, Email = "william.shakespear@gmail.com", ContactId = 1 }
            );

            modelBuilder.Entity<ContactPhone>().HasData(
                new ContactPhone { PhoneId = 1, Phone = "+44 1632 960035", ContactId = 1 }
            );

            modelBuilder.Entity<ContactTag>().HasData(
                new ContactTag { TagId = 1, Tag = "Celebrity", ContactId = 1 }
            );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
