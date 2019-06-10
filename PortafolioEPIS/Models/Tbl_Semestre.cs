namespace PortafolioEPIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    public partial class Tbl_Semestre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Semestre()
        {
            Tbl_CargaAcademica = new HashSet<Tbl_CargaAcademica>();
            Tbl_DetalleCargaAcademica = new HashSet<Tbl_DetalleCargaAcademica>();
            Tbl_PlanEstudio = new HashSet<Tbl_PlanEstudio>();
        }

        [Key]
        public int Codigo_Semestre { get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre_Semestre { get; set; }

        public int Anio_Semestre { get; set; }

        public bool Estado_Semestre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_CargaAcademica> Tbl_CargaAcademica { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_DetalleCargaAcademica> Tbl_DetalleCargaAcademica { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_PlanEstudio> Tbl_PlanEstudio { get; set; }

        //Metodo Listar
        public List<Tbl_Semestre> Listar()
        {
            var objSemestre = new List<Tbl_Semestre>();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objSemestre = db.Tbl_Semestre.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objSemestre;
        }

        //Metodo Obtener
        public Tbl_Semestre Obtener(int id)//retorna solo un objeto
        {
            var objSemestre = new Tbl_Semestre();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objSemestre = db.Tbl_Semestre
                                    .Where(x => x.Codigo_Semestre == id)
                                    .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objSemestre;
        }

        //Metodo Guardar

        public void Guardar()
        {
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    if (this.Codigo_Semestre > 0)//sis existe un valor mayor a cero es porque existe registro
                    {
                        db.Entry(this).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        //SINO EXISTE EL REGISTRO LO GRABA(nuevo)
                        db.Entry(this).State = System.Data.Entity.EntityState.Added;
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
