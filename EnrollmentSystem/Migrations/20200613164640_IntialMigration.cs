using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnrollmentSystem.Migrations
{
    public partial class IntialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    Address = table.Column<string>(maxLength: 200, nullable: false),
                    BirthPlace = table.Column<string>(maxLength: 200, nullable: false),
                    Nationality = table.Column<string>(maxLength: 50, nullable: false),
                    StudentPhoneNumber = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolYears",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Year = table.Column<int>(maxLength: 11, nullable: false),
                    StudentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolYears", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolYears_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FatherName = table.Column<string>(maxLength: 50, nullable: false),
                    FatherOccupation = table.Column<string>(maxLength: 50, nullable: false),
                    MotherName = table.Column<string>(maxLength: 50, nullable: false),
                    MotherOccupation = table.Column<string>(maxLength: 50, nullable: false),
                    GuardianName = table.Column<string>(nullable: true),
                    GuardianOccupation = table.Column<string>(nullable: true),
                    ParentAddress = table.Column<string>(maxLength: 50, nullable: false),
                    ParentNumber = table.Column<string>(maxLength: 50, nullable: false),
                    StudentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentDetails_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentRequirements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NSO = table.Column<bool>(nullable: false),
                    Baptismal = table.Column<bool>(nullable: false),
                    EntranceExamResult = table.Column<string>(nullable: false),
                    CertificateOfTransfer = table.Column<bool>(maxLength: 50, nullable: false),
                    StudentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentRequirements_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Payable = table.Column<string>(maxLength: 50, nullable: false),
                    AmountPaid = table.Column<decimal>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    DateTimePaid = table.Column<DateTime>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName", "MiddleName" },
                values: new object[] { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "Claudius", "Lovart", "Cowthard" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "BirthPlace", "Birthday", "FirstName", "Gender", "LastName", "MiddleName", "Nationality", "StudentPhoneNumber" },
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "42 Meadow Ridge Court", "6 Nobel Trail", new DateTime(2003, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sara", "Female", "Colvin", "Tamsett", "Russia", "523-880-5782" });

            migrationBuilder.InsertData(
                table: "SchoolYears",
                columns: new[] { "Id", "StudentId", "Year" },
                values: new object[] { new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), 2020 });

            migrationBuilder.InsertData(
                table: "StudentDetails",
                columns: new[] { "Id", "FatherName", "FatherOccupation", "GuardianName", "GuardianOccupation", "MotherName", "MotherOccupation", "ParentAddress", "ParentNumber", "StudentId" },
                values: new object[] { new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"), "Mellie Lackmann", "Staff Accountant IV", null, null, "Doris Keniwell", "Health Coach", "35 Golden Leaf Center", "585-866-2699", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35") });

            migrationBuilder.InsertData(
                table: "StudentRequirements",
                columns: new[] { "Id", "Baptismal", "CertificateOfTransfer", "EntranceExamResult", "NSO", "StudentId" },
                values: new object[] { new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87"), true, false, "Passed", true, new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35") });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AmountPaid", "Balance", "DateTimePaid", "EmployeeId", "Payable", "StudentId" },
                values: new object[] { new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), 6000m, 23000m, new DateTime(220, 6, 21, 10, 39, 5, 0, DateTimeKind.Unspecified), new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "Miscellaneous Fee", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35") });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolYears_StudentId",
                table: "SchoolYears",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDetails_StudentId",
                table: "StudentDetails",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRequirements_StudentId",
                table: "StudentRequirements",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_EmployeeId",
                table: "Transactions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_StudentId",
                table: "Transactions",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchoolYears");

            migrationBuilder.DropTable(
                name: "StudentDetails");

            migrationBuilder.DropTable(
                name: "StudentRequirements");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
