namespace PortafolioEPIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;

    public partial class Tbl_PruebaEntrada
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_PruebaEntrada()
        {
            Tbl_ConocimientoHabilidad = new HashSet<Tbl_ConocimientoHabilidad>();
            Tbl_MedidasCorrectivas = new HashSet<Tbl_MedidasCorrectivas>();
        }

        [Key]
        public int Codigo_PruebaEntrada { get; set; }

        public int Codigo_DetalleCargaAcademica { get; set; }

        public int Evaluados_PruebaEntrada { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha_PruebaEntrada { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado_PruebaEntrada { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_ConocimientoHabilidad> Tbl_ConocimientoHabilidad { get; set; }

        public virtual Tbl_DetalleCargaAcademica Tbl_DetalleCargaAcademica { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_MedidasCorrectivas> Tbl_MedidasCorrectivas { get; set; }


        //Metodo Listar
        public List<Tbl_PruebaEntrada> Listar()
        {
            var objPruebaEntrada = new List<Tbl_PruebaEntrada>();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objPruebaEntrada = db.Tbl_PruebaEntrada.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objPruebaEntrada;
        }

        //Metodo Obtener
        public Tbl_PruebaEntrada Obtener(int id)//retorna solo un objeto
        {
            var objPruebaEntrada = new Tbl_PruebaEntrada();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objPruebaEntrada = db.Tbl_PruebaEntrada.Include("Tbl_DetalleCargaAcademica")
                                    .Where(x => x.Codigo_PruebaEntrada == id)
                                    .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objPruebaEntrada;
        }

        //Metodo Guardar

        public void Guardar()
        {
            try
            {
                using (var db = new Modelo_Portafolio())
                {

                    if (this.Codigo_PruebaEntrada > 0)
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
