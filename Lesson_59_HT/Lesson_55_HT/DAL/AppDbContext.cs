using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lesson_55_HT.DAL;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<PhoneNumber> PhoneNumbers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Database=Contacts;Integrated Security=false;User ID=sa; Password=CodeWithArjun123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK__Contact__5C6625BB4D8B7A42");

            entity.ToTable("Contact");

            entity.HasIndex(e => e.Email, "UQ__Contact__A9D1053402D4223E").IsUnique();

            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Surname).HasMaxLength(100);

            entity.HasOne(d => d.Location).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK__Contact__Locatio__3A81B327");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA47759292A88");

            entity.ToTable("Location");

            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.LocationName).HasMaxLength(100);
        });

        modelBuilder.Entity<PhoneNumber>(entity =>
        {
            entity.HasKey(e => e.PhoneNumberId).HasName("PK__PhoneNum__D2D34FB12E3FBB9B");

            entity.ToTable("PhoneNumber");

            entity.Property(e => e.PhoneNumberId).HasColumnName("PhoneNumberID");
            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.PhoneNumber1)
                .HasMaxLength(15)
                .HasColumnName("PhoneNumber");

            entity.HasOne(d => d.Contact).WithMany(p => p.PhoneNumbers)
                .HasForeignKey(d => d.ContactId)
                .HasConstraintName("FK__PhoneNumb__Conta__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
