using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnrollmentSystem.Migrations
{
    public partial class skyr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolYears_Students_StudentsId",
                table: "SchoolYears");

            migrationBuilder.DropIndex(
                name: "IX_SchoolYears_StudentsId",
                table: "SchoolYears");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "SchoolYears");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolYears_Students_StudentId",
                table: "SchoolYears",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolYears_Students_StudentId",
                table: "SchoolYears");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentsId",
                table: "SchoolYears",
                type: "uniqueidentifier",
                nullable: true);

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
    }
}
