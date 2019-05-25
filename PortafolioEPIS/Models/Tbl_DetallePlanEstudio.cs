namespace PortafolioEPIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    public partial class Tbl_DetallePlanEstudio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_DetallePlanEstudio()
        {
            Tbl_DetalleCargaAcademica = new HashSet<Tbl_DetalleCargaAcademica>();
        }

        [Key]
        public int Codigo_DetallePlanEstudio { get; set; }

        public int Codigo_PlanEstudio { get; set; }

        [Required]
        [StringLength(20)]
        public string CodigoCurso_DetallePlanEstudio { get; set; }

        [Required]
        [StringLength(150)]
        public string Asignatura_DetallePlanEstudio { get; set; }

        public int HorasTeoricas_DetallePlanEstudio { get; set; }

        public int HorasPracticas_DetallePlanEstudio { get; set; }

        public int TotalHoras_DetallePlanEstudio { get; set; }

        public int TotalCreditos_DetallePlanEstudio { get; set; }

        [Required]
        [StringLength(150)]
        public string PreRequisito_DetallePlanEstudio { get; set; }

        [Required]
        [StringLength(10)]
        public string Ciclo_DetallePlanEstudio { get; set; }

        [Required]
        [StringLength(20)]
        public string TipoCurso_DetallePlanEstudio { get; set; }

        public bool Estado_DetallePlanEstudio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_DetalleCargaAcademica> Tbl_DetalleCargaAcademica { get; set; }

        public virtual Tbl_PlanEstudio Tbl_PlanEstudio { get; set; }

        //Metodo Listar
        public List<Tbl_DetallePlanEstudio> Listar()
        {
            var objDetallePlanEstudio = new List<Tbl_DetallePlanEstudio>();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objDetallePlanEstudio = db.Tbl_DetallePlanEstudio.Include("Tbl_PlanEstudio").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objDetallePlanEstudio;
        }

        //Metodo Obtener
        public Tbl_DetallePlanEstudio Obtener(int id)//retorna solo un objeto
        {
            var objDetallePlanEstudio = new Tbl_DetallePlanEstudio();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objDetallePlanEstudio = db.Tbl_DetallePlanEstudio.Include("Tbl_PlanEstudio")
                                    .Where(x => x.Codigo_DetallePlanEstudio == id)
                                    .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objDetallePlanEstudio;
        }

        //Metodo Guardar

        public void Guardar()
        {
            try
            {
                using (var db = new Modelo_Portafolio())
                {

                    if (this.Codigo_DetallePlanEstudio > 0)
                    {
                        //si existe un valor mayor que cero es por que existe el registro
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        ///no existe el registro lo graba (Nuevo)
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

        //Metodo Eliminar 
        public void Eliminar()
        {
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    db.Entry(this).State = System.Data.Entity.EntityState.Deleted;
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
