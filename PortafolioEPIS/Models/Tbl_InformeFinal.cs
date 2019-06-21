namespace PortafolioEPIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    using System.Linq;
    using System.Data.Entity;

    public partial class Tbl_InformeFinal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_InformeFinal()
        {
            Tbl_CapacidadesCurso = new HashSet<Tbl_CapacidadesCurso>();
            Tbl_Motivo = new HashSet<Tbl_Motivo>();
            Tbl_Observaciones = new HashSet<Tbl_Observaciones>();
        }

        [Key]
        public int Codigo_InformeFinal { get; set; }

        public int Codigo_DetalleCargaAcademica { get; set; }

        public int? PorcentajeSilabo_InformeFinal { get; set; }

        public int? PracticasCalificadas_InformeFinal { get; set; }

        public int? LaboratoriosRealizados_InformeFinal { get; set; }

        public int? TrabajosRealizados_InformeFinal { get; set; }

        public int? EstudiantesMatriculados_InformeFinal { get; set; }

        public int? EstudiantesRetiro_InformeFinal { get; set; }

        public int? EstudiantesAbandono_InformeFinal { get; set; }

        public int? EstudiantesAsisten_InformeFinal { get; set; }

        public int? EstudiantesAprobados_InformeFinal { get; set; }

        public int? EstudiantesDesaprobados_InformeFinal { get; set; }

        public int? NotaAlta_InformeFinal { get; set; }

        public int? NotaPromedio_InformeFinal { get; set; }

        public int? NotaBaja_InformeFinal { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha_InformeFinal { get; set; }

        [StringLength(1)]
        public string Estado_InformeFinal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_CapacidadesCurso> Tbl_CapacidadesCurso { get; set; }

        public virtual Tbl_DetalleCargaAcademica Tbl_DetalleCargaAcademica { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Motivo> Tbl_Motivo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Observaciones> Tbl_Observaciones { get; set; }
        //metodo listar
        public List<Tbl_InformeFinal> Listar()//Retorna una coleccion de registros
        {
            var objCargo = new List<Tbl_InformeFinal>();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objCargo = db.Tbl_InformeFinal.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objCargo;
        }

        //metodo obtener
        public Tbl_InformeFinal Obtener(int id)//retorna solo un objeto
        {
            var objCargo = new Tbl_InformeFinal();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objCargo = db.Tbl_InformeFinal
                        .Where(x => x.Codigo_InformeFinal == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objCargo;
        }

        //metodo guardar
        public void Guardar()//retorna solo un objeto
        {

            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    if (this.Codigo_InformeFinal > 0)
                    {
                        //si existe un valor mayor a 0 es porque existe un registro
                        db.Entry(this).State = EntityState.Modified;

                    }
                    else
                    {
                        //si no existe registro graba(nuevo registro)
                        db.Entry(this).State = EntityState.Added;

                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        //metodo Eliminar
        public void Eliminar()
        {

            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
