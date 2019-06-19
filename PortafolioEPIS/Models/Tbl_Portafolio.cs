namespace PortafolioEPIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;

    public partial class Tbl_Portafolio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Portafolio()
        {
            Tbl_InformeFinal = new HashSet<Tbl_InformeFinal>();
            Tbl_Material = new HashSet<Tbl_Material>();
        }

        [Key]
        public int Codigo_Portafolio { get; set; }

        public int Codigo_DetalleCargaAcademica { get; set; }

        [StringLength(5)]
        public string Unidad_Portafolio { get; set; }

        public int? Retirados_Portafolio { get; set; }

        public int? Abandono_Portafolio { get; set; }

        public int? Aprobados_Portafolio { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha_Portafolio { get; set; }

        [StringLength(1)]
        public string Estado_Portafolio { get; set; }

        public virtual Tbl_DetalleCargaAcademica Tbl_DetalleCargaAcademica { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_InformeFinal> Tbl_InformeFinal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Material> Tbl_Material { get; set; }

        //metodo listar
        public List<Tbl_Portafolio> Listar()//Retorna una coleccion de registros
        {
            var objTbl_Portafolio = new List<Tbl_Portafolio>();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objTbl_Portafolio = db.Tbl_Portafolio.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objTbl_Portafolio;
        }

        //metodo obtener
        public Tbl_Portafolio Obtener(int id)//retorna solo un objeto
        {
            var objTbl_Portafolio = new Tbl_Portafolio();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objTbl_Portafolio = db.Tbl_Portafolio
                        .Where(x => x.Codigo_Portafolio == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objTbl_Portafolio;
        }


        //metodo guardar
        public void Guardar()//retorna solo un objeto
        {

            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    if (this.Codigo_Portafolio > 0)
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
