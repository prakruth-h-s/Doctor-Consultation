using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocApp3.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    AppointmentID = table.Column<string>(nullable: false),
                    PatientID = table.Column<string>(nullable: true),
                    DoctorID = table.Column<string>(nullable: true),
                    AppointmentDate = table.Column<DateTime>(nullable: false),
                    HealthIssue = table.Column<string>(nullable: true),
                    PrescriptionGiven = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    ReviewComment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.AppointmentID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");
        }
    }
}
