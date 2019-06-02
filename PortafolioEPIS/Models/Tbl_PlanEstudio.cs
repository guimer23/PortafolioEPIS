namespace PortafolioEPIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    public partial class Tbl_PlanEstudio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_PlanEstudio()
        {
            Tbl_DetalleCargaAcademica = new HashSet<Tbl_DetalleCargaAcademica>();
            Tbl_DetallePlanEstudio = new HashSet<Tbl_DetallePlanEstudio>();
            Tbl_PruebaEntrada = new HashSet<Tbl_PruebaEntrada>();
        }

        [Key]
        public int Codigo_PlanEstudio { get; set; }

        public int Codigo_Semestre { get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre_PlanEstudio { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaInicio_PlanEstudio { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaFin_PlanEstudio { get; set; }

        public int TotalCursosObligatorios_PlanEstudio { get; set; }

        public int TotalCursosElectivos_PlanEstudio { get; set; }

        public int TotalCreditosObligatorios_PlanEstudio { get; set; }

        public int TotalCreditosElectivos_PlanEstudio { get; set; }

        public int TotalCreditosExtracurriculares_PlanEstudio { get; set; }

        public int TotalCreditosPracticas_PlanEstudio { get; set; }

        public bool Estado_PlanEstudio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_DetalleCargaAcademica> Tbl_DetalleCargaAcademica { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_DetallePlanEstudio> Tbl_DetallePlanEstudio { get; set; }

        public virtual Tbl_Semestre Tbl_Semestre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_PruebaEntrada> Tbl_PruebaEntrada { get; set; }

        //Metodo Listar
        public List<Tbl_PlanEstudio> Listar()
        {
            var objPlanEstudio = new List<Tbl_PlanEstudio>();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objPlanEstudio = db.Tbl_PlanEstudio.Include("Tbl_Semestre").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objPlanEstudio;
        }

        //Metodo Obtener
        public Tbl_PlanEstudio Obtener(int id)//retorna solo un objeto
        {
            var objPlanEstudio = new Tbl_PlanEstudio();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objPlanEstudio = db.Tbl_PlanEstudio.Include("Tbl_Semestre")
                                    .Where(x => x.Codigo_PlanEstudio == id)
                                    .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objPlanEstudio;
        }

        //Metodo Guardar

        public void Guardar()
        {
            try
            {
                using (var db = new Modelo_Portafolio())
                {

                    if (this.Codigo_PlanEstudio > 0)
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

        //metodo Eliminar 
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
