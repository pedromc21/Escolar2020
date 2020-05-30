using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Escolar2020.Web.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "App_Alumno_Calificacion",
                columns: table => new
                {
                    Curso_Id = table.Column<int>(nullable: false),
                    Persona_Id = table.Column<int>(nullable: false),
                    Ciclo_Id = table.Column<int>(nullable: false),
                    Num_Periodo = table.Column<int>(nullable: false),
                    Clave_Materia = table.Column<string>(maxLength: 50, nullable: false),
                    Materia = table.Column<string>(maxLength: 500, nullable: false),
                    Calificacion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Faltas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Alumno_Calificacion", x => new { x.Curso_Id, x.Persona_Id, x.Ciclo_Id, x.Num_Periodo });
                });

            migrationBuilder.CreateTable(
                name: "App_Alumno_Grado",
                columns: table => new
                {
                    Ciclo_Id = table.Column<int>(nullable: false),
                    Persona_Id = table.Column<int>(nullable: false),
                    Grupo_Id = table.Column<int>(nullable: false),
                    Plantel_Id = table.Column<int>(nullable: false),
                    Seccion_Id = table.Column<int>(nullable: false),
                    Grado_Id = table.Column<int>(nullable: false),
                    Status_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Alumno_Grado", x => new { x.Ciclo_Id, x.Persona_Id, x.Grupo_Id });
                });

            migrationBuilder.CreateTable(
                name: "App_Alumnos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Persona_Id = table.Column<int>(nullable: false),
                    Clave_Familia = table.Column<string>(maxLength: 50, nullable: false),
                    Matricula = table.Column<string>(maxLength: 10, nullable: false),
                    NIA = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Alumnos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_c_CicloEsc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ciclo_Id = table.Column<int>(nullable: false),
                    Ciclo_Escolar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_c_CicloEsc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_c_Conceptos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Concepto_Id = table.Column<int>(nullable: false),
                    Clave = table.Column<string>(nullable: true),
                    Concepto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_c_Conceptos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_c_Direcciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Direccion_Id = table.Column<int>(nullable: false),
                    Codigo_Postal = table.Column<string>(nullable: true),
                    Asentamiento_Id = table.Column<int>(nullable: false),
                    Colonia = table.Column<string>(nullable: true),
                    Calle = table.Column<string>(nullable: true),
                    Numero_Exterior = table.Column<string>(nullable: true),
                    Numero_Interior = table.Column<string>(nullable: true),
                    EntreCalles = table.Column<string>(nullable: true),
                    IdMunicipio = table.Column<int>(nullable: false),
                    Municipio = table.Column<string>(nullable: true),
                    IdEstado = table.Column<int>(nullable: false),
                    Estado = table.Column<string>(nullable: true),
                    IdPais = table.Column<int>(nullable: false),
                    Pais = table.Column<string>(nullable: true),
                    v_Lat = table.Column<string>(nullable: true),
                    v_Lng = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_c_Direcciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_c_Grados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Grado_Id = table.Column<int>(nullable: false),
                    Seccion_Id = table.Column<int>(nullable: false),
                    Clave = table.Column<string>(nullable: true),
                    Grado = table.Column<string>(nullable: true),
                    Orden = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_c_Grados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_c_Grupos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Grupo_Id = table.Column<int>(nullable: false),
                    Clave = table.Column<string>(nullable: true),
                    Grupo = table.Column<string>(nullable: true),
                    Orden = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_c_Grupos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_c_Meses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Mes_Id = table.Column<int>(nullable: false),
                    Mes = table.Column<string>(nullable: true),
                    Orden_Esc = table.Column<int>(nullable: false),
                    Orden = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_c_Meses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_c_Planteles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Plantel_Id = table.Column<int>(nullable: false),
                    Clave = table.Column<string>(nullable: true),
                    Plantel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_c_Planteles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_c_Secciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Seccion_Id = table.Column<int>(nullable: false),
                    Seccion = table.Column<string>(nullable: true),
                    Orden = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_c_Secciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_c_Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status_Id = table.Column<int>(nullable: false),
                    Clave = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_c_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Cargos",
                columns: table => new
                {
                    LaveRef_Id = table.Column<int>(nullable: false),
                    Ciclo_Id = table.Column<int>(nullable: false),
                    Persona_Id = table.Column<int>(nullable: false),
                    Plantel_Id = table.Column<int>(nullable: false),
                    Concepto_Id = table.Column<int>(nullable: false),
                    Mes_Id = table.Column<int>(nullable: false),
                    Concepto = table.Column<string>(maxLength: 150, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Abono = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fecha_Vencimiento = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Cargos", x => new { x.LaveRef_Id, x.Persona_Id, x.Plantel_Id, x.Concepto_Id, x.Mes_Id });
                });

            migrationBuilder.CreateTable(
                name: "App_Cursos",
                columns: table => new
                {
                    Curso_Id = table.Column<int>(nullable: false),
                    Persona_Id = table.Column<int>(nullable: false),
                    Plantel_Id = table.Column<int>(nullable: false),
                    Grupo_Id = table.Column<int>(nullable: false),
                    Ciclo_Id = table.Column<int>(nullable: false),
                    Clave_Materia = table.Column<string>(maxLength: 50, nullable: false),
                    Materia = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Cursos", x => new { x.Curso_Id, x.Persona_Id, x.Plantel_Id, x.Grupo_Id, x.Ciclo_Id });
                });

            migrationBuilder.CreateTable(
                name: "App_Cursos_Asistencia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Curso_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha_Inicio = table.Column<DateTime>(nullable: true),
                    Hora_Ini = table.Column<TimeSpan>(nullable: true),
                    Hora_Fin = table.Column<TimeSpan>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Cursos_Asistencia", x => x.Curso_Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Cursos_Asistencia_Det",
                columns: table => new
                {
                    Asistencia_Id = table.Column<int>(nullable: false),
                    Persona_Id = table.Column<int>(nullable: false),
                    Asistio = table.Column<bool>(nullable: false),
                    Falta_Justificada = table.Column<bool>(nullable: false),
                    Observacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Cursos_Asistencia_Det", x => new { x.Asistencia_Id, x.Persona_Id });
                });

            migrationBuilder.CreateTable(
                name: "App_Cursos_Hora",
                columns: table => new
                {
                    Curso_Id = table.Column<int>(nullable: false),
                    Dia = table.Column<int>(nullable: false),
                    Turno = table.Column<string>(nullable: false),
                    Orden = table.Column<int>(nullable: false),
                    Hora_Ini = table.Column<TimeSpan>(nullable: true),
                    Hora_Fin = table.Column<TimeSpan>(nullable: true),
                    Salon = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Cursos_Hora", x => new { x.Curso_Id, x.Dia, x.Turno, x.Orden });
                });

            migrationBuilder.CreateTable(
                name: "App_DatosFacturacion",
                columns: table => new
                {
                    TipoFac_Id = table.Column<int>(nullable: false),
                    Persona_Id = table.Column<int>(nullable: false),
                    FacturarA = table.Column<string>(maxLength: 250, nullable: false),
                    RFC = table.Column<string>(maxLength: 20, nullable: false),
                    Direccion = table.Column<string>(maxLength: 200, nullable: true),
                    Email_fac = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_DatosFacturacion", x => new { x.TipoFac_Id, x.Persona_Id });
                });

            migrationBuilder.CreateTable(
                name: "App_Docente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Persona_Id = table.Column<int>(nullable: false),
                    Clave = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Docente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Docente_Califica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Ciclo_Id = table.Column<int>(nullable: false),
                    Persona_Id = table.Column<int>(nullable: false),
                    Plantel_Id = table.Column<int>(nullable: false),
                    Grupo_Id = table.Column<int>(nullable: false),
                    Curso_Id = table.Column<int>(nullable: false),
                    Num_Periodo = table.Column<int>(nullable: false),
                    Clave_Materia = table.Column<string>(maxLength: 50, nullable: false),
                    Materia = table.Column<string>(maxLength: 500, nullable: false),
                    Fecha_Inicio = table.Column<DateTime>(nullable: true),
                    Fecha_Fin = table.Column<DateTime>(nullable: true),
                    Estatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Docente_Califica", x => new { x.Id, x.Persona_Id, x.Plantel_Id, x.Grupo_Id, x.Curso_Id });
                });

            migrationBuilder.CreateTable(
                name: "App_Docente_Califica_Det",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Persona_Id = table.Column<int>(nullable: false),
                    Calificacion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fecha = table.Column<DateTime>(nullable: true),
                    Observacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Docente_Califica_Det", x => new { x.Id, x.Persona_Id });
                });

            migrationBuilder.CreateTable(
                name: "App_Docente_Grupo",
                columns: table => new
                {
                    Grupo_Id = table.Column<int>(nullable: false),
                    Persona_Id = table.Column<int>(nullable: false),
                    Ciclo_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Docente_Grupo", x => new { x.Grupo_Id, x.Persona_Id, x.Ciclo_Id });
                });

            migrationBuilder.CreateTable(
                name: "App_Notification_Data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Persona_Id_Create = table.Column<int>(nullable: false),
                    Action_Id = table.Column<int>(nullable: false),
                    Recipient_Id = table.Column<int>(nullable: false),
                    Send_Message = table.Column<bool>(nullable: false),
                    Send_Email = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Body = table.Column<string>(maxLength: 500, nullable: false),
                    url = table.Column<string>(nullable: true),
                    IsHomeWork = table.Column<bool>(nullable: false),
                    IsEvaluated = table.Column<bool>(nullable: false),
                    IsPrivate = table.Column<bool>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Notification_Data", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Notification_HomeWork",
                columns: table => new
                {
                    Id_HomeWork = table.Column<int>(nullable: false),
                    Id_Data = table.Column<int>(nullable: false),
                    Id_Respond = table.Column<int>(nullable: false),
                    FileUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Notification_HomeWork", x => new { x.Id_HomeWork, x.Id_Data, x.Id_Respond });
                });

            migrationBuilder.CreateTable(
                name: "App_Notification_HomeWork_Evaluation",
                columns: table => new
                {
                    Id_HomeWork = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Calificacion = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Calificacion_Letra = table.Column<string>(nullable: true),
                    Observacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Notification_HomeWork_Evaluation", x => x.Id_HomeWork);
                });

            migrationBuilder.CreateTable(
                name: "App_Notification_Recipient",
                columns: table => new
                {
                    Notification_Data_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Seccion_Id = table.Column<int>(nullable: false),
                    Grado_Id = table.Column<int>(nullable: false),
                    Grupo_Id = table.Column<int>(nullable: false),
                    Persona_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Notification_Recipient", x => x.Notification_Data_Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Notification_Respond",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_Data = table.Column<int>(nullable: false),
                    Persona_Id_Respond = table.Column<int>(nullable: false),
                    Row_Respond = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Comentario = table.Column<string>(nullable: true),
                    Estatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Notification_Respond", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Notification_Send",
                columns: table => new
                {
                    Notification_Data_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Send_on = table.Column<DateTime>(nullable: false),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Notification_Send", x => x.Notification_Data_Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Pagos",
                columns: table => new
                {
                    LaveRef_Id = table.Column<int>(nullable: false),
                    Folio = table.Column<string>(nullable: false),
                    Factura = table.Column<string>(nullable: false),
                    Renglon = table.Column<int>(nullable: false),
                    ConceptoPagado = table.Column<string>(maxLength: 150, nullable: false),
                    Abono = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Recargo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comision = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pago = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fecha_Pago = table.Column<DateTime>(nullable: false),
                    MetodoPago = table.Column<string>(maxLength: 150, nullable: false),
                    ReferenciaPago = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Pagos", x => new { x.LaveRef_Id, x.Folio, x.Factura, x.Renglon });
                });

            migrationBuilder.CreateTable(
                name: "App_Persona_Direccion",
                columns: table => new
                {
                    Direccion_Id = table.Column<int>(nullable: false),
                    Persona_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Persona_Direccion", x => new { x.Direccion_Id, x.Persona_Id });
                });

            migrationBuilder.CreateTable(
                name: "App_Tutors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Persona_Id = table.Column<int>(nullable: false),
                    Clave_Familia = table.Column<string>(maxLength: 50, nullable: false),
                    Parentesco = table.Column<string>(maxLength: 100, nullable: false),
                    Profesion = table.Column<string>(maxLength: 250, nullable: true),
                    Nombre_Empresa = table.Column<string>(maxLength: 250, nullable: true),
                    Puesto_Empresa = table.Column<string>(maxLength: 250, nullable: true),
                    Telefono_Trabajo = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Tutors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Persona_Id = table.Column<int>(nullable: false),
                    Clave_Familia = table.Column<string>(nullable: true),
                    Rol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "App_Persona",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Persona_Id = table.Column<int>(nullable: false),
                    TipoPersona_Id = table.Column<int>(nullable: false),
                    TipoPersona = table.Column<string>(maxLength: 50, nullable: false),
                    Apellido_Paterno = table.Column<string>(maxLength: 250, nullable: false),
                    Apellido_Materno = table.Column<string>(maxLength: 250, nullable: true),
                    Nombres = table.Column<string>(maxLength: 250, nullable: false),
                    Fecha_Nacimiento = table.Column<DateTime>(nullable: true),
                    Sexo = table.Column<string>(maxLength: 10, nullable: true),
                    EMail = table.Column<string>(maxLength: 150, nullable: true),
                    Telefono = table.Column<string>(maxLength: 150, nullable: true),
                    Celular = table.Column<string>(maxLength: 150, nullable: true),
                    CURP = table.Column<string>(maxLength: 100, nullable: true),
                    Usuario_App = table.Column<string>(maxLength: 150, nullable: true),
                    PWd_App = table.Column<string>(maxLength: 50, nullable: true),
                    ImageUrl = table.Column<string>(maxLength: 250, nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Persona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_Persona_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_App_Persona_UserId",
                table: "App_Persona",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "App_Alumno_Calificacion");

            migrationBuilder.DropTable(
                name: "App_Alumno_Grado");

            migrationBuilder.DropTable(
                name: "App_Alumnos");

            migrationBuilder.DropTable(
                name: "App_c_CicloEsc");

            migrationBuilder.DropTable(
                name: "App_c_Conceptos");

            migrationBuilder.DropTable(
                name: "App_c_Direcciones");

            migrationBuilder.DropTable(
                name: "App_c_Grados");

            migrationBuilder.DropTable(
                name: "App_c_Grupos");

            migrationBuilder.DropTable(
                name: "App_c_Meses");

            migrationBuilder.DropTable(
                name: "App_c_Planteles");

            migrationBuilder.DropTable(
                name: "App_c_Secciones");

            migrationBuilder.DropTable(
                name: "App_c_Status");

            migrationBuilder.DropTable(
                name: "App_Cargos");

            migrationBuilder.DropTable(
                name: "App_Cursos");

            migrationBuilder.DropTable(
                name: "App_Cursos_Asistencia");

            migrationBuilder.DropTable(
                name: "App_Cursos_Asistencia_Det");

            migrationBuilder.DropTable(
                name: "App_Cursos_Hora");

            migrationBuilder.DropTable(
                name: "App_DatosFacturacion");

            migrationBuilder.DropTable(
                name: "App_Docente");

            migrationBuilder.DropTable(
                name: "App_Docente_Califica");

            migrationBuilder.DropTable(
                name: "App_Docente_Califica_Det");

            migrationBuilder.DropTable(
                name: "App_Docente_Grupo");

            migrationBuilder.DropTable(
                name: "App_Notification_Data");

            migrationBuilder.DropTable(
                name: "App_Notification_HomeWork");

            migrationBuilder.DropTable(
                name: "App_Notification_HomeWork_Evaluation");

            migrationBuilder.DropTable(
                name: "App_Notification_Recipient");

            migrationBuilder.DropTable(
                name: "App_Notification_Respond");

            migrationBuilder.DropTable(
                name: "App_Notification_Send");

            migrationBuilder.DropTable(
                name: "App_Pagos");

            migrationBuilder.DropTable(
                name: "App_Persona");

            migrationBuilder.DropTable(
                name: "App_Persona_Direccion");

            migrationBuilder.DropTable(
                name: "App_Tutors");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
