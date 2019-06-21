namespace PortafolioEPIS.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Modelo_Portafolio : DbContext
    {
        public Modelo_Portafolio()
            : base("name=Modelo_Portafolio")
        {
        }

        public virtual DbSet<Tbl_CapacidadesCurso> Tbl_CapacidadesCurso { get; set; }
        public virtual DbSet<Tbl_CargaAcademica> Tbl_CargaAcademica { get; set; }
        public virtual DbSet<Tbl_CargoDocente> Tbl_CargoDocente { get; set; }
        public virtual DbSet<Tbl_ConocimientoHabilidad> Tbl_ConocimientoHabilidad { get; set; }
        public virtual DbSet<Tbl_DetalleCargaAcademica> Tbl_DetalleCargaAcademica { get; set; }
        public virtual DbSet<Tbl_DetallePlanEstudio> Tbl_DetallePlanEstudio { get; set; }
        public virtual DbSet<Tbl_Docente> Tbl_Docente { get; set; }
        public virtual DbSet<Tbl_InformeFinal> Tbl_InformeFinal { get; set; }
        public virtual DbSet<Tbl_Material> Tbl_Material { get; set; }
        public virtual DbSet<Tbl_MedidasCorrectivas> Tbl_MedidasCorrectivas { get; set; }
        public virtual DbSet<Tbl_Motivo> Tbl_Motivo { get; set; }
        public virtual DbSet<Tbl_Observaciones> Tbl_Observaciones { get; set; }
        public virtual DbSet<Tbl_PlanEstudio> Tbl_PlanEstudio { get; set; }
        public virtual DbSet<Tbl_Portafolio> Tbl_Portafolio { get; set; }
        public virtual DbSet<Tbl_Profesion> Tbl_Profesion { get; set; }
        public virtual DbSet<Tbl_PruebaEntrada> Tbl_PruebaEntrada { get; set; }
        public virtual DbSet<Tbl_Seccion> Tbl_Seccion { get; set; }
        public virtual DbSet<Tbl_Semestre> Tbl_Semestre { get; set; }
        public virtual DbSet<Tbl_Usuario> Tbl_Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tbl_CapacidadesCurso>()
                .Property(e => e.Descripcion_CapacidadesCurso)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_CargaAcademica>()
                .Property(e => e.Nombre_CargaAcademica)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_CargaAcademica>()
                .HasMany(e => e.Tbl_DetalleCargaAcademica)
                .WithRequired(e => e.Tbl_CargaAcademica)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_CargoDocente>()
                .Property(e => e.Nombre_CargoDocente)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_CargoDocente>()
                .HasMany(e => e.Tbl_Docente)
                .WithRequired(e => e.Tbl_CargoDocente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_ConocimientoHabilidad>()
                .Property(e => e.Nombre_ConocimientoHabilidad)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_DetalleCargaAcademica>()
                .HasMany(e => e.Tbl_InformeFinal)
                .WithRequired(e => e.Tbl_DetalleCargaAcademica)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_DetalleCargaAcademica>()
                .HasMany(e => e.Tbl_Portafolio)
                .WithRequired(e => e.Tbl_DetalleCargaAcademica)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_DetalleCargaAcademica>()
                .HasMany(e => e.Tbl_PruebaEntrada)
                .WithRequired(e => e.Tbl_DetalleCargaAcademica)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_DetallePlanEstudio>()
                .Property(e => e.CodigoCurso_DetallePlanEstudio)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_DetallePlanEstudio>()
                .Property(e => e.Asignatura_DetallePlanEstudio)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_DetallePlanEstudio>()
                .Property(e => e.PreRequisito_DetallePlanEstudio)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_DetallePlanEstudio>()
                .Property(e => e.Ciclo_DetallePlanEstudio)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_DetallePlanEstudio>()
                .Property(e => e.TipoCurso_DetallePlanEstudio)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_DetallePlanEstudio>()
                .HasMany(e => e.Tbl_DetalleCargaAcademica)
                .WithRequired(e => e.Tbl_DetallePlanEstudio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Docente>()
                .Property(e => e.Codigo_Docenteepis)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Docente>()
                .Property(e => e.DNI_Docente)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Docente>()
                .Property(e => e.Nombres_Docente)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Docente>()
                .Property(e => e.Apellidos_Docente)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Docente>()
                .Property(e => e.EstadoCivil_Docente)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Docente>()
                .Property(e => e.DireccionActual_Docente)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Docente>()
                .Property(e => e.DireccionReferencia_Docente)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Docente>()
                .Property(e => e.Correo_Docente)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Docente>()
                .Property(e => e.TelefonoFijo_Docente)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Docente>()
                .Property(e => e.TelefonoCelular_Docente)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Docente>()
                .Property(e => e.Foto_Docente)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Docente>()
                .HasMany(e => e.Tbl_DetalleCargaAcademica)
                .WithRequired(e => e.Tbl_Docente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Docente>()
                .HasMany(e => e.Tbl_Usuario)
                .WithRequired(e => e.Tbl_Docente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_InformeFinal>()
                .Property(e => e.Estado_InformeFinal)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_InformeFinal>()
                .HasMany(e => e.Tbl_CapacidadesCurso)
                .WithRequired(e => e.Tbl_InformeFinal)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_InformeFinal>()
                .HasMany(e => e.Tbl_Motivo)
                .WithRequired(e => e.Tbl_InformeFinal)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_InformeFinal>()
                .HasMany(e => e.Tbl_Observaciones)
                .WithRequired(e => e.Tbl_InformeFinal)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Material>()
                .Property(e => e.Tipo_Material)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Material>()
                .Property(e => e.Nombre_Material)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Material>()
                .Property(e => e.Estado_Material)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Material>()
                .Property(e => e.Archivo_Material)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Material>()
                .Property(e => e.TipoArchivo_Material)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Material>()
                .Property(e => e.PesoArchivo_Material)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Material>()
                .Property(e => e.Descripcion_Material)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Material>()
                .Property(e => e.UrlOnline_Material)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_MedidasCorrectivas>()
                .Property(e => e.Medida7_MedidasCorrectivas)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Motivo>()
                .Property(e => e.Descripcion_Motivo)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Observaciones>()
                .Property(e => e.Estudiantes_Observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Observaciones>()
                .Property(e => e.AsistenciaPuntualidad_Observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Observaciones>()
                .Property(e => e.Silabo_Observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Observaciones>()
                .Property(e => e.Administrativas_Observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Observaciones>()
                .Property(e => e.SilaboCompetencias_Observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Observaciones>()
                .Property(e => e.MejoraContinua_Observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Observaciones>()
                .Property(e => e.ActualizacionDocente_Observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Observaciones>()
                .Property(e => e.ComentariosRecomendaciones_Observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_PlanEstudio>()
                .Property(e => e.Nombre_PlanEstudio)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_PlanEstudio>()
                .HasMany(e => e.Tbl_DetalleCargaAcademica)
                .WithRequired(e => e.Tbl_PlanEstudio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_PlanEstudio>()
                .HasMany(e => e.Tbl_DetallePlanEstudio)
                .WithRequired(e => e.Tbl_PlanEstudio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Portafolio>()
                .Property(e => e.Unidad_Portafolio)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Portafolio>()
                .Property(e => e.Estado_Portafolio)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Portafolio>()
                .HasMany(e => e.Tbl_Material)
                .WithRequired(e => e.Tbl_Portafolio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Profesion>()
                .Property(e => e.Nombre_Profesion)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Profesion>()
                .Property(e => e.Abrebiatura_Profesion)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Profesion>()
                .HasMany(e => e.Tbl_Docente)
                .WithRequired(e => e.Tbl_Profesion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_PruebaEntrada>()
                .Property(e => e.Estado_PruebaEntrada)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_PruebaEntrada>()
                .HasMany(e => e.Tbl_ConocimientoHabilidad)
                .WithRequired(e => e.Tbl_PruebaEntrada)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_PruebaEntrada>()
                .HasMany(e => e.Tbl_MedidasCorrectivas)
                .WithRequired(e => e.Tbl_PruebaEntrada)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Seccion>()
                .Property(e => e.Nombre_Seccion)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Seccion>()
                .HasMany(e => e.Tbl_DetalleCargaAcademica)
                .WithRequired(e => e.Tbl_Seccion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Semestre>()
                .Property(e => e.Nombre_Semestre)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Semestre>()
                .HasMany(e => e.Tbl_CargaAcademica)
                .WithRequired(e => e.Tbl_Semestre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Semestre>()
                .HasMany(e => e.Tbl_DetalleCargaAcademica)
                .WithRequired(e => e.Tbl_Semestre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Semestre>()
                .HasMany(e => e.Tbl_PlanEstudio)
                .WithRequired(e => e.Tbl_Semestre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Usuario>()
                .Property(e => e.Nombre_Usuario)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Usuario>()
                .Property(e => e.Password_Usuario)
                .IsUnicode(false);
        }
    }
}
