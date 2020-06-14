﻿// <auto-generated />
using System;
using EnrollmentSystem.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EnrollmentSystem.Migrations
{
    [DbContext(typeof(EnrollmentContext))]
    [Migration("20200614130228_datetimeoffset")]
    partial class datetimeoffset
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EnrollmentSystem.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            FirstName = "Claudius",
                            LastName = "Lovart",
                            MiddleName = "Cowthard"
                        });
                });

            modelBuilder.Entity("EnrollmentSystem.Entities.SchoolYear", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Year")
                        .HasColumnType("int")
                        .HasMaxLength(11);

                    b.HasKey("StudentId");

                    b.ToTable("SchoolYears");

                    b.HasData(
                        new
                        {
                            StudentId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            Year = 2020
                        });
                });

            modelBuilder.Entity("EnrollmentSystem.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("BirthPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTimeOffset>("Birthday")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("StudentPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            Address = "42 Meadow Ridge Court",
                            BirthPlace = "6 Nobel Trail",
                            Birthday = new DateTimeOffset(new DateTime(2003, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)),
                            FirstName = "Sara",
                            Gender = "Female",
                            LastName = "Colvin",
                            MiddleName = "Tamsett",
                            Nationality = "Russia",
                            StudentPhoneNumber = "523-880-5782"
                        });
                });

            modelBuilder.Entity("EnrollmentSystem.Entities.StudentDetail", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FatherOccupation")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("GuardianName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuardianOccupation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("MotherOccupation")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ParentAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ParentNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("StudentId");

                    b.ToTable("StudentDetails");

                    b.HasData(
                        new
                        {
                            StudentId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            FatherName = "Mellie Lackmann",
                            FatherOccupation = "Staff Accountant IV",
                            MotherName = "Doris Keniwell",
                            MotherOccupation = "Health Coach",
                            ParentAddress = "35 Golden Leaf Center",
                            ParentNumber = "585-866-2699"
                        });
                });

            modelBuilder.Entity("EnrollmentSystem.Entities.StudentRequirement", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Baptismal")
                        .HasColumnType("bit");

                    b.Property<bool>("CertificateOfTransfer")
                        .HasColumnType("bit")
                        .HasMaxLength(50);

                    b.Property<string>("EntranceExamResult")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NSO")
                        .HasColumnType("bit");

                    b.HasKey("StudentId");

                    b.ToTable("StudentRequirements");

                    b.HasData(
                        new
                        {
                            StudentId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            Baptismal = true,
                            CertificateOfTransfer = false,
                            EntranceExamResult = "Passed",
                            NSO = true
                        });
                });

            modelBuilder.Entity("EnrollmentSystem.Entities.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("AmountPaid")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("DateTimePaid")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Payable")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("StudentId");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                            AmountPaid = 6000m,
                            Balance = 23000m,
                            DateTimePaid = new DateTime(220, 6, 21, 10, 39, 5, 0, DateTimeKind.Unspecified),
                            EmployeeId = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            Payable = "Miscellaneous Fee",
                            StudentId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35")
                        });
                });

            modelBuilder.Entity("EnrollmentSystem.Entities.SchoolYear", b =>
                {
                    b.HasOne("EnrollmentSystem.Entities.Student", "Student")
                        .WithOne("SchoolYear")
                        .HasForeignKey("EnrollmentSystem.Entities.SchoolYear", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EnrollmentSystem.Entities.StudentDetail", b =>
                {
                    b.HasOne("EnrollmentSystem.Entities.Student", "Student")
                        .WithOne("StudentDetail")
                        .HasForeignKey("EnrollmentSystem.Entities.StudentDetail", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EnrollmentSystem.Entities.StudentRequirement", b =>
                {
                    b.HasOne("EnrollmentSystem.Entities.Student", "Student")
                        .WithOne("StudentRequirement")
                        .HasForeignKey("EnrollmentSystem.Entities.StudentRequirement", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EnrollmentSystem.Entities.Transaction", b =>
                {
                    b.HasOne("EnrollmentSystem.Entities.Employee", "Employees")
                        .WithMany("Transactions")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnrollmentSystem.Entities.Student", "Students")
                        .WithMany("Transactions")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
