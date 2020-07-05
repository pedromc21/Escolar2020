namespace Escolar2020.Web.Data
{
    using Entity.Personas;
    using Entity.Catalogos;
    using Entity.Pagos;
    using Entity.Notification;
    using Entity.Cursos;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    
    public class DataContext : IdentityDbContext<App_User>
    {
        //Incluir todos los modelos que se van a convertir en tablas en la DB
        public DbSet<App_c_CicloEsc> App_c_CicloEscolares { get; set; }
        public DbSet<App_c_Conceptos> App_c_Conceptos { get; set; }
        public DbSet<App_c_Direccion> App_c_Direcciones { get; set; }
        public DbSet<App_c_Grado> App_c_Grados { get; set; }
        public DbSet<App_c_Grupo> App_c_Grupos { get; set; }
        public DbSet<App_c_Mes> App_c_Meses { get; set; }
        public DbSet<App_c_Plantel> App_c_Planteles { get; set; }
        public DbSet<App_c_Seccion> App_c_Secciones { get; set; }
        public DbSet<App_c_Status> App_c_Statuss { get; set; }

        public DbSet<App_Persona> App_Personas { get; set; }
        public DbSet<App_Persona_Direccion> App_Persona_Direcciones { get; set; }

        public DbSet<App_Alumno> App_Alumnos { get; set; }
        public DbSet<App_Alumno_Calificacion> App_Alumno_Calificaciones { get; set; }
        public DbSet<App_Alumno_Grado> App_Alumno_Grados { get; set; }

        public DbSet<App_Tutor> App_Tutors { get; set; }
        
        public DbSet<App_Docente> App_Docentes { get; set; }
        public DbSet<App_Docente_Califica> App_Docente_Calificaciones { get; set; }
        public DbSet<App_Docente_Califica_Det> App_Docente_Calificaciones_Det { get; set; }
        public DbSet<App_Docente_Grupo> App_Docente_Grupos { get; set; }

        public DbSet<App_Curso> App_Cursos { get; set; }
        public DbSet<App_Cursos_Asistencia> App_Cursos_Asistencias { get; set; }
        public DbSet<App_Cursos_Asistencia_Det> App_Cursos_Asistencias_Det { get; set; }
        public DbSet<App_Cursos_Hora> App_Cursos_Horas { get; set; }

        public DbSet<App_Cargo> App_Cargos { get; set; }
        public DbSet<App_DatoFacturacion> App_DatosFacturacion { get; set; }
        public DbSet<App_Pago> App_Pagos { get; set; }

        public DbSet<App_Notification_Data> App_Notifications_Data { get; set; }
        public DbSet<App_Notification_HomeWork> App_Notifications_HomeWork { get; set; }
        public DbSet<App_Notification_HomeWork_Evaluation> App_Notifications_HomeWork_Evaluation { get; set; }
        public DbSet<App_Notification_Recipient> App_Notifications_Recipient { get; set; }
        public DbSet<App_Notification_Respond> App_Notifications_Respond { get; set; }
        public DbSet<App_Notification_Send> App_Notifications_Send { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<App_Alumno_Calificacion>()
            .HasKey(c => new { c.Curso_Id, c.Persona_Id, c.Ciclo_Id, c.Num_Periodo });

            modelBuilder.Entity<App_Alumno_Grado>()
            .HasKey(c => new { c.Ciclo_Id, c.Persona_Id, c.Grupo_Id });

            modelBuilder.Entity<App_Docente_Grupo>()
           .HasKey(c => new { c.Grupo_Id, c.Persona_Id, c.Ciclo_Id }); 

            modelBuilder.Entity<App_Docente_Califica>()
           .HasKey(c => new { c.Id, c.Persona_Id, c.Plantel_Id, c.Grupo_Id, c.Curso_Id });

            modelBuilder.Entity<App_Docente_Califica_Det>()
           .HasKey(c => new { c.Id, c.Persona_Id });

            modelBuilder.Entity<App_Persona_Direccion>()
           .HasKey(c => new { c.Direccion_Id, c.Persona_Id });

            modelBuilder.Entity<App_Cargo>()
           .HasKey(c => new { c.LaveRef_Id, c.Persona_Id, c.Plantel_Id, c.Concepto_Id, c.Mes_Id });

            modelBuilder.Entity<App_Pago>()
           .HasKey(c => new { c.LaveRef_Id, c.Folio, c.Factura, c.Renglon });

            modelBuilder.Entity<App_DatoFacturacion>()
           .HasKey(c => new { c.TipoFac_Id, c.Persona_Id });

            modelBuilder.Entity<App_Curso>()
            .HasKey(c => new { c.Curso_Id, c.Persona_Id, c.Plantel_Id, c.Grupo_Id, c.Ciclo_Id });

            modelBuilder.Entity<App_Cursos_Hora>()
           .HasKey(c => new { c.Curso_Id, c.Dia, c.Turno, c.Orden });

            modelBuilder.Entity<App_Cursos_Asistencia>()
           .HasKey(c => new { c.Curso_Id });

            modelBuilder.Entity<App_Cursos_Asistencia_Det>()
           .HasKey(c => new { c.Asistencia_Id, c.Persona_Id });

            modelBuilder.Entity<App_Notification_Recipient>()
            .HasKey(c => new { c.Notification_Data_Id });

            modelBuilder.Entity<App_Notification_HomeWork>()
           .HasKey(c => new { c.Id_HomeWork, c.Id_Data, c.Id_Respond });

            /*modelBuilder.Entity<App_Tutor>()
            .Property(p => p.Persona_Id)
            .HasColumnType("int");*/
            /*Al borrar registro no afecte en cascada*/
            var cascadeFKs = modelBuilder.Model
                .G­etEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Casca­de);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restr­ict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
