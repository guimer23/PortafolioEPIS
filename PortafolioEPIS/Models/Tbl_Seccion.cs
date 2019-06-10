namespace PortafolioEPIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    public partial class Tbl_Seccion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Seccion()
        {
            Tbl_DetalleCargaAcademica = new HashSet<Tbl_DetalleCargaAcademica>();
        }

        [Key]
        public int Codigo_Seccion { get; set; }

        [Required]
        [StringLength(10)]
        public string Nombre_Seccion { get; set; }

        public bool Estado_Seccion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_DetalleCargaAcademica> Tbl_DetalleCargaAcademica { get; set; }

        public List<Tbl_Seccion> Listar()//retorna una coleccion
        {
            var objseccion = new List<Tbl_Seccion>();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objseccion = db.Tbl_Seccion.ToList();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objseccion;
        }

        public Tbl_Seccion Obtener(int id) //retorna solo un objeto
        {
            var objSeccion = new Tbl_Seccion();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objSeccion = db.Tbl_Seccion.
                        Where(x => x.Codigo_Seccion == id).
                        SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objSeccion;
        }

        public void Guardar()
        {
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    if (this.Codigo_Seccion > 0)
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
