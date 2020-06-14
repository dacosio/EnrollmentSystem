using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnrollmentSystem.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolYears_Students_StudentId",
                table: "SchoolYears");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentRequirements",
                table: "StudentRequirements");

            migrationBuilder.DropIndex(
                name: "IX_StudentRequirements_StudentId",
                table: "StudentRequirements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentDetails",
                table: "StudentDetails");

            migrationBuilder.DropIndex(
                name: "IX_StudentDetails_StudentId",
                table: "StudentDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SchoolYears",
                table: "SchoolYears");

            migrationBuilder.DropIndex(
                name: "IX_SchoolYears_StudentId",
                table: "SchoolYears");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentRequirements");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentDetails");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SchoolYears");

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "Transactions",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountPaid",
                table: "Transactions",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentsId",
                table: "SchoolYears",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentRequirements",
                table: "StudentRequirements",
                column: "StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentDetails",
                table: "StudentDetails",
                column: "StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchoolYears",
                table: "SchoolYears",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolYears_StudentsId",
                table: "SchoolYears",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolYears_Students_StudentsId",
                table: "SchoolYears",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolYears_Students_StudentsId",
                table: "SchoolYears");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentRequirements",
                table: "StudentRequirements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentDetails",
                table: "StudentDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SchoolYears",
                table: "SchoolYears");

            migrationBuilder.DropIndex(
                name: "IX_SchoolYears_StudentsId",
                table: "SchoolYears");

            migrationBuilder.DeleteData(
                table: "SchoolYears",
                keyColumn: "StudentId",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"));

            migrationBuilder.DeleteData(
                table: "StudentDetails",
                keyColumn: "StudentId",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"));

            migrationBuilder.DeleteData(
                table: "StudentRequirements",
                keyColumn: "StudentId",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"));

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "SchoolYears");

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountPaid",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "StudentRequirements",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "StudentDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "SchoolYears",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentRequirements",
                table: "StudentRequirements",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentDetails",
                table: "StudentDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchoolYears",
                table: "SchoolYears",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_StudentRequirements_StudentId",
                table: "StudentRequirements",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDetails_StudentId",
                table: "StudentDetails",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolYears_StudentId",
                table: "SchoolYears",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolYears_Students_StudentId",
                table: "SchoolYears",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
