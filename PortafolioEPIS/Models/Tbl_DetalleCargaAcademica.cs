namespace PortafolioEPIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;
    public partial class Tbl_DetalleCargaAcademica
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_DetalleCargaAcademica()
        {
            Tbl_InformeFinal = new HashSet<Tbl_InformeFinal>();
            Tbl_Portafolio = new HashSet<Tbl_Portafolio>();
            Tbl_PruebaEntrada = new HashSet<Tbl_PruebaEntrada>();
        }

        [Key]
        public int Codigo_DetalleCargaAcademica { get; set; }

        public int Codigo_PlanEstudio { get; set; }

        public int Codigo_CargaAcademica { get; set; }

        public int Codigo_Docente { get; set; }

        public int Codigo_Seccion { get; set; }

        public int Codigo_DetallePlanEstudio { get; set; }

        public int Codigo_Semestre { get; set; }

        public int Matriculados_DetalleCargaAcademica { get; set; }

        public bool Estado_DetalleCargaAcademica { get; set; }

        public virtual Tbl_CargaAcademica Tbl_CargaAcademica { get; set; }

        public virtual Tbl_PlanEstudio Tbl_PlanEstudio { get; set; }

        public virtual Tbl_Docente Tbl_Docente { get; set; }

        public virtual Tbl_Seccion Tbl_Seccion { get; set; }

        public virtual Tbl_DetallePlanEstudio Tbl_DetallePlanEstudio { get; set; }

        public virtual Tbl_Semestre Tbl_Semestre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_InformeFinal> Tbl_InformeFinal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Portafolio> Tbl_Portafolio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_PruebaEntrada> Tbl_PruebaEntrada { get; set; }

        //Metodo Listar
        public List<Tbl_DetalleCargaAcademica> Listar()
        {
            var objDetalleCargaAcademica = new List<Tbl_DetalleCargaAcademica>();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objDetalleCargaAcademica = db.Tbl_DetalleCargaAcademica.Include("Tbl_CargaAcademica")
                                                                            .Include("Tbl_PlanEstudio")
                                                                            .Include("Tbl_Docente")
                                                                            .Include("Tbl_Seccion")
                                                                            .Include("Tbl_DetallePlanEstudio")
                                                                            .Include("Tbl_Semestre")
                                                                            .ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objDetalleCargaAcademica;
        }

        //Metodo Listar 2 usado en el controlador detalle carga academica en la vista index 

        public List<Tbl_DetalleCargaAcademica> Listar2(int id)
        {
            var objDetalleCargaAcademica = new List<Tbl_DetalleCargaAcademica>();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objDetalleCargaAcademica = db.Tbl_DetalleCargaAcademica.Include("Tbl_CargaAcademica")
                                                                            .Include("Tbl_PlanEstudio")
                                                                            .Include("Tbl_Docente")
                                                                            .Include("Tbl_Seccion")
                                                                            .Include("Tbl_DetallePlanEstudio")
                                                                            .Include("Tbl_Semestre")
                                                                            .Where(x => x.Codigo_CargaAcademica == id)
                                                                            .ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objDetalleCargaAcademica;
        }

        //Metodo Obtener
        public Tbl_DetalleCargaAcademica Obtener(int id)//retorna solo un objeto
        {
            var objCargaAcademica = new Tbl_DetalleCargaAcademica();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objCargaAcademica = db.Tbl_DetalleCargaAcademica.Include("Tbl_CargaAcademica")
                                                                            .Include("Tbl_PlanEstudio")
                                                                            .Include("Tbl_Docente")
                                                                            .Include("Tbl_Seccion")
                                                                            .Include("Tbl_DetallePlanEstudio")
                                                                            .Include("Tbl_Semestre")
                                    .Where(x => x.Codigo_DetalleCargaAcademica == id)
                                    .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objCargaAcademica;
        }

        //Metodo Guardar

        public void Guardar()
        {
            try
            {
                using (var db = new Modelo_Portafolio())
                {

                    if (this.Codigo_DetalleCargaAcademica > 0)
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
