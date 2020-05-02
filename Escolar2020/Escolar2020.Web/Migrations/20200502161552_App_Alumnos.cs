using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Escolar2020.Web.Migrations
{
    public partial class App_Alumnos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "App_Alumnos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Persona_Id = table.Column<int>(nullable: false),
                    Clave_Familia = table.Column<string>(maxLength: 50, nullable: false),
                    Apellido_Paterno = table.Column<string>(maxLength: 250, nullable: true),
                    Apellido_Materno = table.Column<string>(maxLength: 250, nullable: true),
                    Nombres = table.Column<string>(maxLength: 250, nullable: false),
                    Fecha_Nacimiento = table.Column<DateTime>(nullable: false),
                    Sexo = table.Column<string>(maxLength: 10, nullable: true),
                    EMail = table.Column<string>(maxLength: 150, nullable: true),
                    Periodo_Id = table.Column<int>(nullable: false),
                    Ciclo_Escolar = table.Column<string>(maxLength: 150, nullable: true),
                    Matricula = table.Column<string>(maxLength: 50, nullable: false),
                    Seccion = table.Column<string>(maxLength: 100, nullable: true),
                    Grado = table.Column<string>(maxLength: 100, nullable: true),
                    Grupo = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<string>(maxLength: 100, nullable: true),
                    CURP = table.Column<string>(maxLength: 100, nullable: true),
                    NIA = table.Column<string>(maxLength: 100, nullable: true),
                    Usuario_App = table.Column<string>(maxLength: 150, nullable: true),
                    PWd_App = table.Column<string>(maxLength: 50, nullable: true),
                    ImageUrl = table.Column<string>(maxLength: 250, nullable: true),
                    OrdenSeccion = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Alumnos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_Alumnos_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_App_Alumnos_UserId",
                table: "App_Alumnos",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "App_Alumnos");
        }
    }
}
