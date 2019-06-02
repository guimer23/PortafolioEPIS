namespace PortafolioEPIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;

    public partial class Tbl_CargaAcademica
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_CargaAcademica()
        {
            Tbl_DetalleCargaAcademica = new HashSet<Tbl_DetalleCargaAcademica>();
            Tbl_PruebaEntrada = new HashSet<Tbl_PruebaEntrada>();
        }

        [Key]
        public int Codigo_CargaAcademica { get; set; }

        public int Codigo_Semestre { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre_CargaAcademica { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaInicio_CargaAcademica { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaFin_CargaAcademica { get; set; }

        public bool Estado_CargaAcademica { get; set; }

        public virtual Tbl_Semestre Tbl_Semestre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_DetalleCargaAcademica> Tbl_DetalleCargaAcademica { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_PruebaEntrada> Tbl_PruebaEntrada { get; set; }

        //Metodo Listar
        public List<Tbl_CargaAcademica> Listar()
        {
            var objCargaAcademica = new List<Tbl_CargaAcademica>();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objCargaAcademica = db.Tbl_CargaAcademica.Include("Tbl_Semestre").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objCargaAcademica;
        }

        //Metodo Obtener
        public Tbl_CargaAcademica Obtener(int id)//retorna solo un objeto
        {
            var objCargaAcademica = new Tbl_CargaAcademica();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objCargaAcademica = db.Tbl_CargaAcademica.Include("Tbl_Semestre")
                                    .Where(x => x.Codigo_CargaAcademica == id)
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

                    if (this.Codigo_CargaAcademica > 0)
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
