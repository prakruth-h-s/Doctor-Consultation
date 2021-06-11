using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocApp1.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    AppointmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(nullable: false),
                    DoctorID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    HealthIssue = table.Column<string>(nullable: true),
                    Prescription = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Review = table.Column<string>(nullable: true)
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
