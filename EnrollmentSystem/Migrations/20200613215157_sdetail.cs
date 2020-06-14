using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnrollmentSystem.Migrations
{
    public partial class sdetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentDetails_Students_StudentId",
                table: "StudentDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentDetails",
                table: "StudentDetails");

            migrationBuilder.DeleteData(
                table: "StudentDetails",
                keyColumn: "StudentId",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"));

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "StudentDetails",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentDetails",
                table: "StudentDetails",
                column: "Id");

            migrationBuilder.InsertData(
                table: "StudentDetails",
                columns: new[] { "Id", "FatherName", "FatherOccupation", "GuardianName", "GuardianOccupation", "MotherName", "MotherOccupation", "ParentAddress", "ParentNumber" },
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Mellie Lackmann", "Staff Accountant IV", null, null, "Doris Keniwell", "Health Coach", "35 Golden Leaf Center", "585-866-2699" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentDetails_Students_Id",
                table: "StudentDetails",
                column: "Id",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentDetails_Students_Id",
                table: "StudentDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentDetails",
                table: "StudentDetails");

            migrationBuilder.DeleteData(
                table: "StudentDetails",
                keyColumn: "Id",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "StudentDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentDetails",
                table: "StudentDetails",
                column: "StudentId");

            migrationBuilder.InsertData(
                table: "StudentDetails",
                columns: new[] { "StudentId", "FatherName", "FatherOccupation", "GuardianName", "GuardianOccupation", "MotherName", "MotherOccupation", "ParentAddress", "ParentNumber" },
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Mellie Lackmann", "Staff Accountant IV", null, null, "Doris Keniwell", "Health Coach", "35 Golden Leaf Center", "585-866-2699" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentDetails_Students_StudentId",
                table: "StudentDetails",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
