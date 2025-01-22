using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;
using Lesson_60_HT.Services;
using Lesson_60_HT.Models;

namespace Lesson_60_HT.DAL
{
	public class StudentDBContext : DbContext
	{
        public DbSet<Student> StudentsList { get; set; }
        public DbSet<Subject> SubjectsList { get; set; }
        public DbSet<StudentDetails> StudentDetails { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DbService.Bulid();
            optionsBuilder.UseSqlServer(DbService.Configuration.GetConnectionString("SqlCon"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Students part
            modelBuilder.Entity<Student>().ToTable("StudentsList")
                .HasKey(s => s.Id);

            modelBuilder.Entity<Student>().HasOne(s => s.StudentSubject)
                .WithMany(sbj => sbj.Students)
                .HasForeignKey(st => st.SubjectID)
                .HasPrincipalKey(sbjc => sbjc.Id);



            modelBuilder.Entity<Student>()
                .Property(s => s.Name).IsRequired()
                .HasColumnName("StudentName")
                .HasColumnType("VARCHAR")
                .HasMaxLength(30);

            modelBuilder.Entity<Student>().ToTable(
                t => t.HasCheckConstraint(
                "CK_Studetns_Name_Minimum", "LEN(StudentName) >= 2"));


            modelBuilder.Entity<Student>()
                .Property(s => s.Surname).IsRequired()
                .HasColumnName("StudentSurname")
                .HasColumnType("VARCHAR").HasMaxLength(50);

            modelBuilder.Entity<Student>()
                .Property(s => s.Age).IsRequired()
                .HasColumnName("StudentAge")
                .HasColumnType("INT").HasMaxLength(50);


            // Subject part
            modelBuilder.Entity<Subject>().ToTable("SubjectsList")
                .HasKey(s => s.Id);

            modelBuilder.Entity<Subject>()
                .Property(s => s.Name).IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);




        }


    }
}

