using EnrollmentSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentSystem.DbContexts
{
    public class EnrollmentContext : DbContext
    {
        public EnrollmentContext(DbContextOptions<EnrollmentContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<SchoolYear> SchoolYears { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentDetail> StudentDetails { get; set; }
        public DbSet<StudentRequirement> StudentRequirements { get; set; }
        public DbSet<Transaction> Transactions{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    FirstName = "Sara",
                    MiddleName = "Tamsett",
                    LastName = "Colvin",
                    Birthday = new DateTime(2003, 5, 21),
                    Gender = "Female",
                    Address = "42 Meadow Ridge Court",
                    BirthPlace = "6 Nobel Trail",
                    Nationality = "Russia",
                    StudentPhoneNumber = "523-880-5782"
                });

            modelBuilder.Entity<Employee>().HasData(
                new Employee()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    FirstName = "Claudius",
                    MiddleName = "Cowthard",
                    LastName = "Lovart"
                });

            modelBuilder.Entity<SchoolYear>().HasData(
                new SchoolYear()
                {
                    StudentId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    //Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    Year = 2020,
                });

            modelBuilder.Entity<Transaction>().HasData(
                new Transaction()
                {
                    Id = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    Payable = "Miscellaneous Fee",
                    AmountPaid = 6000,
                    Balance = 23000,
                    DateTimePaid = new DateTime(220, 6, 21,10,39,05),
                    EmployeeId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    StudentId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                });

            modelBuilder.Entity<StudentDetail>().HasData(
                new StudentDetail()
                {
                    //Id = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                    StudentId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    FatherName = "Mellie Lackmann",
                    FatherOccupation = "Staff Accountant IV",
                    MotherName = "Doris Keniwell",
                    MotherOccupation = "Health Coach",
                    ParentAddress = "35 Golden Leaf Center",
                    ParentNumber = "585-866-2699",

                });

            modelBuilder.Entity<StudentRequirement>().HasData(
                new StudentRequirement()
                {

                    //Id = Guid.Parse("2aadd2df-7caf-45ab-9355-7f6332985a87"),
                    StudentId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    NSO = true,
                    Baptismal = true,
                    EntranceExamResult = "Passed",
                });



            base.OnModelCreating(modelBuilder);

        }

    }
}
