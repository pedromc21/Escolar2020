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
                name: "App_Alumno_Calificaciones",
                columns: table => new
                {
                    Curso_Id = table.Column<int>(nullable: false),
                    Persona_Id = table.Column<int>(nullable: false),
                    Ciclo_Id = table.Column<int>(nullable: false),
                    Ciclo_Escolar = table.Column<string>(maxLength: 10, nullable: true),
                    Num_Periodo = table.Column<int>(nullable: false),
                    Clave_Materia = table.Column<string>(maxLength: 50, nullable: false),
                    Materia_Id = table.Column<int>(nullable: false),
                    Materia = table.Column<string>(maxLength: 100, nullable: true),
                    Calificacion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Faltas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Alumno_Calificaciones", x => new { x.Curso_Id, x.Persona_Id, x.Ciclo_Id, x.Num_Periodo });
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
                name: "App_Cursos_Asistencias",
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
                    table.PrimaryKey("PK_App_Cursos_Asistencias", x => x.Curso_Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Cursos_Asistencias_Det",
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
                    table.PrimaryKey("PK_App_Cursos_Asistencias_Det", x => new { x.Asistencia_Id, x.Persona_Id });
                });

            migrationBuilder.CreateTable(
                name: "App_Cursos_Horas",
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
                    table.PrimaryKey("PK_App_Cursos_Horas", x => new { x.Curso_Id, x.Dia, x.Turno, x.Orden });
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
                name: "App_Docente_Calificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Persona_Id = table.Column<int>(nullable: false),
                    Curso_Id = table.Column<int>(nullable: false),
                    Plantel_Id = table.Column<int>(nullable: false),
                    Plantel = table.Column<string>(maxLength: 10, nullable: true),
                    Ciclo_Id = table.Column<int>(nullable: false),
                    Ciclo_Escolar = table.Column<string>(maxLength: 10, nullable: true),
                    Grupo_Id = table.Column<int>(nullable: false),
                    Grupo = table.Column<string>(maxLength: 10, nullable: true),
                    Num_Periodo = table.Column<int>(nullable: false),
                    Clave_Materia = table.Column<string>(maxLength: 50, nullable: false),
                    Materia = table.Column<string>(maxLength: 500, nullable: false),
                    Fecha_Inicio = table.Column<DateTime>(nullable: true),
                    Fecha_Fin = table.Column<DateTime>(nullable: true),
                    Estatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Docente_Calificaciones", x => new { x.Id, x.Persona_Id, x.Plantel_Id, x.Grupo_Id, x.Curso_Id });
                });

            migrationBuilder.CreateTable(
                name: "App_Docente_Calificaciones_Det",
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
                    table.PrimaryKey("PK_App_Docente_Calificaciones_Det", x => new { x.Id, x.Persona_Id });
                });

            migrationBuilder.CreateTable(
                name: "App_Docente_Grupos",
                columns: table => new
                {
                    Persona_Id = table.Column<int>(nullable: false),
                    Ciclo_Id = table.Column<int>(nullable: false),
                    Ciclo_Escolar = table.Column<string>(maxLength: 10, nullable: true),
                    Grupo_Id = table.Column<int>(nullable: false),
                    Grupo = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Docente_Grupos", x => new { x.Grupo_Id, x.Persona_Id, x.Ciclo_Id });
                });

            migrationBuilder.CreateTable(
                name: "App_Docentes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Persona_Id = table.Column<int>(nullable: false),
                    Clave = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Docentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Notifications_Data",
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
                    table.PrimaryKey("PK_App_Notifications_Data", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Notifications_HomeWork",
                columns: table => new
                {
                    Id_HomeWork = table.Column<int>(nullable: false),
                    Id_Data = table.Column<int>(nullable: false),
                    Id_Respond = table.Column<int>(nullable: false),
                    FileUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Notifications_HomeWork", x => new { x.Id_HomeWork, x.Id_Data, x.Id_Respond });
                });

            migrationBuilder.CreateTable(
                name: "App_Notifications_HomeWork_Evaluation",
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
                    table.PrimaryKey("PK_App_Notifications_HomeWork_Evaluation", x => x.Id_HomeWork);
                });

            migrationBuilder.CreateTable(
                name: "App_Notifications_Recipient",
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
                    table.PrimaryKey("PK_App_Notifications_Recipient", x => x.Notification_Data_Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Notifications_Respond",
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
                    table.PrimaryKey("PK_App_Notifications_Respond", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Notifications_Send",
                columns: table => new
                {
                    Notification_Data_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Send_on = table.Column<DateTime>(nullable: false),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Notifications_Send", x => x.Notification_Data_Id);
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
                name: "App_Personas",
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
                    table.PrimaryKey("PK_App_Personas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_Personas_AspNetUsers_UserId",
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

            migrationBuilder.CreateTable(
                name: "App_Alumnos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Persona_Id = table.Column<int>(nullable: false),
                    Clave_Familia = table.Column<string>(maxLength: 50, nullable: false),
                    Matricula = table.Column<string>(maxLength: 10, nullable: false),
                    NIA = table.Column<string>(maxLength: 100, nullable: true),
                    Plantel_Id = table.Column<int>(nullable: false),
                    Plantel = table.Column<string>(maxLength: 10, nullable: true),
                    Ciclo_Id = table.Column<int>(nullable: false),
                    Ciclo_Escolar = table.Column<string>(maxLength: 10, nullable: true),
                    Seccion_Id = table.Column<int>(nullable: false),
                    Seccion = table.Column<string>(maxLength: 10, nullable: true),
                    Grado_Id = table.Column<int>(nullable: false),
                    Grado = table.Column<string>(maxLength: 10, nullable: true),
                    Status_Id = table.Column<int>(nullable: false),
                    Status = table.Column<string>(maxLength: 10, nullable: true),
                    PersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Alumnos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_Alumnos_App_Personas_PersonId",
                        column: x => x.PersonId,
                        principalTable: "App_Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "App_Persona_Direcciones",
                columns: table => new
                {
                    Direccion_Id = table.Column<int>(nullable: false),
                    Persona_Id = table.Column<int>(nullable: false),
                    Codigo_Postal = table.Column<string>(maxLength: 10, nullable: true),
                    Asentamiento_Id = table.Column<int>(nullable: false),
                    Colonia = table.Column<string>(maxLength: 250, nullable: true),
                    Calle = table.Column<string>(maxLength: 500, nullable: true),
                    Numero_Exterior = table.Column<string>(maxLength: 50, nullable: true),
                    Numero_Interior = table.Column<string>(maxLength: 50, nullable: true),
                    EntreCalles = table.Column<string>(maxLength: 500, nullable: true),
                    IdMunicipio = table.Column<int>(nullable: false),
                    Municipio = table.Column<string>(maxLength: 500, nullable: true),
                    IdEstado = table.Column<int>(nullable: false),
                    Estado = table.Column<string>(maxLength: 500, nullable: true),
                    IdPais = table.Column<int>(nullable: false),
                    Pais = table.Column<string>(maxLength: 500, nullable: true),
                    v_Lat = table.Column<string>(maxLength: 500, nullable: true),
                    v_Lng = table.Column<string>(maxLength: 500, nullable: true),
                    PersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Persona_Direcciones", x => new { x.Direccion_Id, x.Persona_Id });
                    table.ForeignKey(
                        name: "FK_App_Persona_Direcciones_App_Personas_PersonId",
                        column: x => x.PersonId,
                        principalTable: "App_Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Telefono_Trabajo = table.Column<string>(maxLength: 150, nullable: true),
                    c_PersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Tutors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_Tutors_App_Personas_c_PersonId",
                        column: x => x.c_PersonId,
                        principalTable: "App_Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_App_Alumnos_PersonId",
                table: "App_Alumnos",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_App_Persona_Direcciones_PersonId",
                table: "App_Persona_Direcciones",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_App_Personas_UserId",
                table: "App_Personas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_App_Tutors_c_PersonId",
                table: "App_Tutors",
                column: "c_PersonId");

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
                name: "App_Alumno_Calificaciones");

            migrationBuilder.DropTable(
                name: "App_Alumnos");

            migrationBuilder.DropTable(
                name: "App_Cargos");

            migrationBuilder.DropTable(
                name: "App_Cursos");

            migrationBuilder.DropTable(
                name: "App_Cursos_Asistencias");

            migrationBuilder.DropTable(
                name: "App_Cursos_Asistencias_Det");

            migrationBuilder.DropTable(
                name: "App_Cursos_Horas");

            migrationBuilder.DropTable(
                name: "App_DatosFacturacion");

            migrationBuilder.DropTable(
                name: "App_Docente_Calificaciones");

            migrationBuilder.DropTable(
                name: "App_Docente_Calificaciones_Det");

            migrationBuilder.DropTable(
                name: "App_Docente_Grupos");

            migrationBuilder.DropTable(
                name: "App_Docentes");

            migrationBuilder.DropTable(
                name: "App_Notifications_Data");

            migrationBuilder.DropTable(
                name: "App_Notifications_HomeWork");

            migrationBuilder.DropTable(
                name: "App_Notifications_HomeWork_Evaluation");

            migrationBuilder.DropTable(
                name: "App_Notifications_Recipient");

            migrationBuilder.DropTable(
                name: "App_Notifications_Respond");

            migrationBuilder.DropTable(
                name: "App_Notifications_Send");

            migrationBuilder.DropTable(
                name: "App_Pagos");

            migrationBuilder.DropTable(
                name: "App_Persona_Direcciones");

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
                name: "App_Personas");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
