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

        public virtual DbSet<Tbl_CargaAcademica> Tbl_CargaAcademica { get; set; }
        public virtual DbSet<Tbl_CargoDocente> Tbl_CargoDocente { get; set; }
        public virtual DbSet<Tbl_DetalleCargaAcademica> Tbl_DetalleCargaAcademica { get; set; }
        public virtual DbSet<Tbl_DetallePlanEstudio> Tbl_DetallePlanEstudio { get; set; }
        public virtual DbSet<Tbl_Docente> Tbl_Docente { get; set; }
        public virtual DbSet<Tbl_PlanEstudio> Tbl_PlanEstudio { get; set; }
        public virtual DbSet<Tbl_Profesion> Tbl_Profesion { get; set; }
        public virtual DbSet<Tbl_Seccion> Tbl_Seccion { get; set; }
        public virtual DbSet<Tbl_Semestre> Tbl_Semestre { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
        }
    }
}
