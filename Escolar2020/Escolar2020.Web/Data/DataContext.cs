namespace Escolar2020.Web.Data
{
    using Entity;
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
        public DbSet<App_c_CicloEsc> App_c_CicloEsc { get; set; }
        public DbSet<App_c_Conceptos> App_c_Conceptos { get; set; }
        public DbSet<App_c_Direcciones> App_c_Direcciones { get; set; }
        public DbSet<App_c_Grados> App_c_Grados { get; set; }
        public DbSet<App_c_Grupos> App_c_Grupos { get; set; }
        public DbSet<App_c_Meses> App_c_Meses { get; set; }
        public DbSet<App_c_Planteles> App_c_Planteles { get; set; }
        public DbSet<App_c_Secciones> App_c_Secciones { get; set; }
        public DbSet<App_c_Status> App_c_Status { get; set; }

        public DbSet<App_Persona> App_Persona { get; set; }
        public DbSet<App_Persona_Direccion> App_Persona_Direccion { get; set; }

        public DbSet<App_Alumno> App_Alumnos { get; set; }
        public DbSet<App_Alumno_Calificacion> App_Alumno_Calificacion { get; set; }
        public DbSet<App_Alumno_Grado> App_Alumno_Grado { get; set; }

        public DbSet<App_Tutor> App_Tutors { get; set; }
        
        public DbSet<App_Docente> App_Docente { get; set; }
        public DbSet<App_Docente_Califica> App_Docente_Califica { get; set; }
        public DbSet<App_Docente_Califica_Det> App_Docente_Califica_Det { get; set; }
        public DbSet<App_Docente_Grupo> App_Docente_Grupo { get; set; }

        public DbSet<App_Cursos> App_Cursos { get; set; }
        public DbSet<App_Cursos_Asistencia> App_Cursos_Asistencia { get; set; }
        public DbSet<App_Cursos_Asistencia_Det> App_Cursos_Asistencia_Det { get; set; }
        public DbSet<App_Cursos_Hora> App_Cursos_Hora { get; set; }

        public DbSet<App_Cargos> App_Cargos { get; set; }
        public DbSet<App_DatosFacturacion> App_DatosFacturacion { get; set; }
        public DbSet<App_Pagos> App_Pagos { get; set; }

        public DbSet<App_Notification_Data> App_Notification_Data { get; set; }
        public DbSet<App_Notification_HomeWork> App_Notification_HomeWork { get; set; }
        public DbSet<App_Notification_HomeWork_Evaluation> App_Notification_HomeWork_Evaluation { get; set; }
        public DbSet<App_Notification_Recipient> App_Notification_Recipient { get; set; }
        public DbSet<App_Notification_Respond> App_Notification_Respond { get; set; }
        public DbSet<App_Notification_Send> App_Notification_Send { get; set; }

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

            modelBuilder.Entity<App_Cargos>()
           .HasKey(c => new { c.LaveRef_Id, c.Persona_Id, c.Plantel_Id, c.Concepto_Id, c.Mes_Id });

            modelBuilder.Entity<App_Pagos>()
           .HasKey(c => new { c.LaveRef_Id, c.Folio, c.Factura, c.Renglon });

            modelBuilder.Entity<App_DatosFacturacion>()
           .HasKey(c => new { c.TipoFac_Id, c.Persona_Id });

            modelBuilder.Entity<App_Cursos>()
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
