﻿// <auto-generated />
using System;
using Escolar2020.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Escolar2020.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Catalogos.App_c_CicloEsc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ciclo_Escolar");

                    b.Property<int>("Ciclo_Id");

                    b.HasKey("Id");

                    b.ToTable("App_c_CicloEscolares");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Catalogos.App_c_Conceptos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clave");

                    b.Property<string>("Concepto");

                    b.Property<int>("Concepto_Id");

                    b.HasKey("Id");

                    b.ToTable("App_c_Conceptos");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Catalogos.App_c_Direccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Asentamiento_Id");

                    b.Property<string>("Calle");

                    b.Property<string>("Codigo_Postal");

                    b.Property<string>("Colonia");

                    b.Property<int>("Direccion_Id");

                    b.Property<string>("EntreCalles");

                    b.Property<string>("Estado");

                    b.Property<int>("IdEstado");

                    b.Property<int>("IdMunicipio");

                    b.Property<int>("IdPais");

                    b.Property<string>("Municipio");

                    b.Property<string>("Numero_Exterior");

                    b.Property<string>("Numero_Interior");

                    b.Property<string>("Pais");

                    b.Property<string>("v_Lat");

                    b.Property<string>("v_Lng");

                    b.HasKey("Id");

                    b.ToTable("App_c_Direcciones");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Catalogos.App_c_Grado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clave");

                    b.Property<string>("Grado");

                    b.Property<int>("Grado_Id");

                    b.Property<int>("Orden");

                    b.Property<int>("Seccion_Id");

                    b.HasKey("Id");

                    b.ToTable("App_c_Grados");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Catalogos.App_c_Grupo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clave");

                    b.Property<string>("Grupo");

                    b.Property<int>("Grupo_Id");

                    b.Property<int>("Orden");

                    b.HasKey("Id");

                    b.ToTable("App_c_Grupos");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Catalogos.App_c_Mes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Mes");

                    b.Property<int>("Mes_Id");

                    b.Property<int>("Orden");

                    b.Property<int>("Orden_Esc");

                    b.HasKey("Id");

                    b.ToTable("App_c_Meses");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Catalogos.App_c_Plantel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clave");

                    b.Property<string>("Plantel");

                    b.Property<int>("Plantel_Id");

                    b.HasKey("Id");

                    b.ToTable("App_c_Planteles");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Catalogos.App_c_Seccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Orden");

                    b.Property<string>("Seccion");

                    b.Property<int>("Seccion_Id");

                    b.HasKey("Id");

                    b.ToTable("App_c_Secciones");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Catalogos.App_c_Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clave");

                    b.Property<string>("Status");

                    b.Property<int>("Status_Id");

                    b.HasKey("Id");

                    b.ToTable("App_c_Statuss");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Cursos.App_Curso", b =>
                {
                    b.Property<int>("Curso_Id");

                    b.Property<int>("Persona_Id");

                    b.Property<int>("Plantel_Id");

                    b.Property<int>("Grupo_Id");

                    b.Property<int>("Ciclo_Id");

                    b.Property<string>("Clave_Materia")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Materia")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.HasKey("Curso_Id", "Persona_Id", "Plantel_Id", "Grupo_Id", "Ciclo_Id");

                    b.ToTable("App_Cursos");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Cursos.App_Cursos_Asistencia", b =>
                {
                    b.Property<int>("Curso_Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Fecha_Inicio");

                    b.Property<TimeSpan?>("Hora_Fin");

                    b.Property<TimeSpan?>("Hora_Ini");

                    b.Property<int>("Id");

                    b.HasKey("Curso_Id");

                    b.ToTable("App_Cursos_Asistencias");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Cursos.App_Cursos_Asistencia_Det", b =>
                {
                    b.Property<int>("Asistencia_Id");

                    b.Property<int>("Persona_Id");

                    b.Property<bool>("Asistio");

                    b.Property<bool>("Falta_Justificada");

                    b.Property<string>("Observacion");

                    b.HasKey("Asistencia_Id", "Persona_Id");

                    b.ToTable("App_Cursos_Asistencias_Det");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Cursos.App_Cursos_Hora", b =>
                {
                    b.Property<int>("Curso_Id");

                    b.Property<int>("Dia");

                    b.Property<string>("Turno");

                    b.Property<int>("Orden");

                    b.Property<TimeSpan?>("Hora_Fin");

                    b.Property<TimeSpan?>("Hora_Ini");

                    b.Property<string>("Salon")
                        .HasMaxLength(50);

                    b.HasKey("Curso_Id", "Dia", "Turno", "Orden");

                    b.ToTable("App_Cursos_Horas");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Notification.App_Notification_Data", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Action_Id");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<bool>("IsEvaluated");

                    b.Property<bool>("IsHomeWork");

                    b.Property<bool>("IsPrivate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Persona_Id_Create");

                    b.Property<int>("Recipient_Id");

                    b.Property<bool>("Send_Email");

                    b.Property<bool>("Send_Message");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("created_on");

                    b.Property<string>("url");

                    b.HasKey("Id");

                    b.ToTable("App_Notifications_Data");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Notification.App_Notification_HomeWork", b =>
                {
                    b.Property<int>("Id_HomeWork");

                    b.Property<int>("Id_Data");

                    b.Property<int>("Id_Respond");

                    b.Property<string>("FileUrl");

                    b.HasKey("Id_HomeWork", "Id_Data", "Id_Respond");

                    b.ToTable("App_Notifications_HomeWork");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Notification.App_Notification_HomeWork_Evaluation", b =>
                {
                    b.Property<int>("Id_HomeWork")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Calificacion")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Calificacion_Letra");

                    b.Property<DateTime>("Fecha");

                    b.Property<string>("Observacion");

                    b.HasKey("Id_HomeWork");

                    b.ToTable("App_Notifications_HomeWork_Evaluation");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Notification.App_Notification_Recipient", b =>
                {
                    b.Property<int>("Notification_Data_Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Grado_Id");

                    b.Property<int>("Grupo_Id");

                    b.Property<int>("Persona_Id");

                    b.Property<int>("Seccion_Id");

                    b.HasKey("Notification_Data_Id");

                    b.ToTable("App_Notifications_Recipient");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Notification.App_Notification_Respond", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comentario");

                    b.Property<int>("Estatus");

                    b.Property<DateTime>("Fecha");

                    b.Property<int>("Id_Data");

                    b.Property<int>("Persona_Id_Respond");

                    b.Property<int>("Row_Respond");

                    b.HasKey("Id");

                    b.ToTable("App_Notifications_Respond");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Notification.App_Notification_Send", b =>
                {
                    b.Property<int>("Notification_Data_Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Send_on");

                    b.Property<int>("status");

                    b.HasKey("Notification_Data_Id");

                    b.ToTable("App_Notifications_Send");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Pagos.App_Cargo", b =>
                {
                    b.Property<int>("LaveRef_Id");

                    b.Property<int>("Persona_Id");

                    b.Property<int>("Plantel_Id");

                    b.Property<int>("Concepto_Id");

                    b.Property<int>("Mes_Id");

                    b.Property<decimal>("Abono")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Ciclo_Id");

                    b.Property<string>("Concepto")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<DateTime?>("Fecha_Vencimiento");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("LaveRef_Id", "Persona_Id", "Plantel_Id", "Concepto_Id", "Mes_Id");

                    b.ToTable("App_Cargos");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Pagos.App_DatoFacturacion", b =>
                {
                    b.Property<int>("TipoFac_Id");

                    b.Property<int>("Persona_Id");

                    b.Property<string>("Direccion")
                        .HasMaxLength(200);

                    b.Property<string>("Email_fac")
                        .HasMaxLength(100);

                    b.Property<string>("FacturarA")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("RFC")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("TipoFac_Id", "Persona_Id");

                    b.ToTable("App_DatosFacturacion");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Pagos.App_Pago", b =>
                {
                    b.Property<int>("LaveRef_Id");

                    b.Property<string>("Folio");

                    b.Property<string>("Factura");

                    b.Property<int>("Renglon");

                    b.Property<decimal>("Abono")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Comision")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ConceptoPagado")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<decimal>("Descuento")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Fecha_Pago");

                    b.Property<string>("MetodoPago")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<decimal>("Pago")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Recargo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ReferenciaPago")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("LaveRef_Id", "Folio", "Factura", "Renglon");

                    b.ToTable("App_Pagos");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Personas.App_Alumno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clave_Familia")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("NIA")
                        .HasMaxLength(100);

                    b.Property<int>("Persona_Id");

                    b.HasKey("Id");

                    b.ToTable("App_Alumnos");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Personas.App_Alumno_Calificacion", b =>
                {
                    b.Property<int>("Curso_Id");

                    b.Property<int>("Persona_Id");

                    b.Property<int>("Ciclo_Id");

                    b.Property<int>("Num_Periodo");

                    b.Property<decimal>("Calificacion")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Clave_Materia")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Faltas");

                    b.Property<string>("Materia")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.HasKey("Curso_Id", "Persona_Id", "Ciclo_Id", "Num_Periodo");

                    b.ToTable("App_Alumno_Calificaciones");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Personas.App_Alumno_Grado", b =>
                {
                    b.Property<int>("Ciclo_Id");

                    b.Property<int>("Persona_Id");

                    b.Property<int>("Grupo_Id");

                    b.Property<int>("Grado_Id");

                    b.Property<int>("Plantel_Id");

                    b.Property<int>("Seccion_Id");

                    b.Property<int>("Status_Id");

                    b.HasKey("Ciclo_Id", "Persona_Id", "Grupo_Id");

                    b.ToTable("App_Alumno_Grados");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Personas.App_Docente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clave")
                        .HasMaxLength(50);

                    b.Property<int>("Persona_Id");

                    b.HasKey("Id");

                    b.ToTable("App_Docentes");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Personas.App_Docente_Califica", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("Persona_Id");

                    b.Property<int>("Plantel_Id");

                    b.Property<int>("Grupo_Id");

                    b.Property<int>("Curso_Id");

                    b.Property<int>("Ciclo_Id");

                    b.Property<string>("Clave_Materia")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Estatus");

                    b.Property<DateTime?>("Fecha_Fin");

                    b.Property<DateTime?>("Fecha_Inicio");

                    b.Property<string>("Materia")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<int>("Num_Periodo");

                    b.HasKey("Id", "Persona_Id", "Plantel_Id", "Grupo_Id", "Curso_Id");

                    b.ToTable("App_Docente_Calificaciones");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Personas.App_Docente_Califica_Det", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("Persona_Id");

                    b.Property<decimal>("Calificacion")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("Fecha");

                    b.Property<string>("Observacion");

                    b.HasKey("Id", "Persona_Id");

                    b.ToTable("App_Docente_Calificaciones_Det");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Personas.App_Docente_Grupo", b =>
                {
                    b.Property<int>("Grupo_Id");

                    b.Property<int>("Persona_Id");

                    b.Property<int>("Ciclo_Id");

                    b.HasKey("Grupo_Id", "Persona_Id", "Ciclo_Id");

                    b.ToTable("App_Docente_Grupos");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Personas.App_Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido_Materno")
                        .HasMaxLength(250);

                    b.Property<string>("Apellido_Paterno")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int?>("App_TutorId");

                    b.Property<string>("CURP")
                        .HasMaxLength(100);

                    b.Property<string>("Celular")
                        .HasMaxLength(150);

                    b.Property<string>("EMail")
                        .HasMaxLength(150);

                    b.Property<DateTime?>("Fecha_Nacimiento");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(250);

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("PWd_App")
                        .HasMaxLength(50);

                    b.Property<int>("Persona_Id");

                    b.Property<string>("Sexo")
                        .HasMaxLength(10);

                    b.Property<string>("Telefono")
                        .HasMaxLength(150);

                    b.Property<string>("TipoPersona")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("TipoPersona_Id");

                    b.Property<string>("UserId");

                    b.Property<string>("Usuario_App")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("App_TutorId");

                    b.HasIndex("UserId");

                    b.ToTable("App_Personas");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Personas.App_Persona_Direccion", b =>
                {
                    b.Property<int>("Direccion_Id");

                    b.Property<int>("Persona_Id");

                    b.HasKey("Direccion_Id", "Persona_Id");

                    b.ToTable("App_Persona_Direcciones");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Personas.App_Tutor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clave_Familia")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Nombre_Empresa")
                        .HasMaxLength(250);

                    b.Property<string>("Parentesco")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Persona_Id");

                    b.Property<string>("Profesion")
                        .HasMaxLength(250);

                    b.Property<string>("Puesto_Empresa")
                        .HasMaxLength(250);

                    b.Property<string>("Telefono_Trabajo")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("App_Tutors");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Personas.App_User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Clave_Familia");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<int>("Persona_Id");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Rol");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Escolar2020.Web.Data.Entity.Personas.App_Persona", b =>
                {
                    b.HasOne("Escolar2020.Web.Data.Entity.Personas.App_Tutor")
                        .WithMany("Personas")
                        .HasForeignKey("App_TutorId");

                    b.HasOne("Escolar2020.Web.Data.Entity.Personas.App_User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Escolar2020.Web.Data.Entity.Personas.App_User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Escolar2020.Web.Data.Entity.Personas.App_User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Escolar2020.Web.Data.Entity.Personas.App_User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Escolar2020.Web.Data.Entity.Personas.App_User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
