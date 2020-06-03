using Microsoft.EntityFrameworkCore.Migrations;

namespace Escolar2020.Web.Migrations
{
    public partial class Person : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "App_TutorId",
                table: "App_Persona",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_App_Persona_App_TutorId",
                table: "App_Persona",
                column: "App_TutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_App_Persona_App_Tutors_App_TutorId",
                table: "App_Persona",
                column: "App_TutorId",
                principalTable: "App_Tutors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_App_Persona_App_Tutors_App_TutorId",
                table: "App_Persona");

            migrationBuilder.DropIndex(
                name: "IX_App_Persona_App_TutorId",
                table: "App_Persona");

            migrationBuilder.DropColumn(
                name: "App_TutorId",
                table: "App_Persona");
        }
    }
}
