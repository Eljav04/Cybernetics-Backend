﻿// <auto-generated />
using Lesson_60_HT.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lesson_60_HT.Migrations
{
    [DbContext(typeof(StudentDBContext))]
    [Migration("20250120145409_FKStudDetails3")]
    partial class FKStudDetails3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lesson_60_HT.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasMaxLength(50)
                        .HasColumnType("INT")
                        .HasColumnName("StudentAge");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("StudentName");

                    b.Property<int>("StudentDetailsID")
                        .HasColumnType("int");

                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("StudentSurname");

                    b.HasKey("Id");

                    b.HasIndex("StudentDetailsID");

                    b.HasIndex("SubjectID");

                    b.ToTable("StudentsList", null, t =>
                        {
                            t.HasCheckConstraint("CK_Studetns_Name_Minimum", "LEN(StudentName) >= 2");
                        });
                });

            modelBuilder.Entity("Lesson_60_HT.Models.StudentDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Payment")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("StudentDetails");
                });

            modelBuilder.Entity("Lesson_60_HT.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("SubjectsList", (string)null);
                });

            modelBuilder.Entity("Lesson_60_HT.Models.Student", b =>
                {
                    b.HasOne("Lesson_60_HT.Models.StudentDetails", "StudentDetails")
                        .WithMany()
                        .HasForeignKey("StudentDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lesson_60_HT.Models.Subject", "StudentSubject")
                        .WithMany("Students")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudentDetails");

                    b.Navigation("StudentSubject");
                });

            modelBuilder.Entity("Lesson_60_HT.Models.Subject", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
