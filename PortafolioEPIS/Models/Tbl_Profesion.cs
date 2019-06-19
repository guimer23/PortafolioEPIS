namespace PortafolioEPIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;

    public partial class Tbl_Profesion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Profesion()
        {
            Tbl_Docente = new HashSet<Tbl_Docente>();
        }

        [Key]
        public int Codigo_Profesion { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre_Profesion { get; set; }

        [Required]
        [StringLength(10)]
        public string Abrebiatura_Profesion { get; set; }

        public bool Estado_Profesion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Docente> Tbl_Docente { get; set; }


        //metodo listar
        public List<Tbl_Profesion> Listar()//Retorna una coleccion de registros
        {
            var objTbl_Profesion = new List<Tbl_Profesion>();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objTbl_Profesion = db.Tbl_Profesion.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objTbl_Profesion;
        }

        //metodo obtener
        public Tbl_Profesion Obtener(int id)//retorna solo un objeto
        {
            var objTbl_Profesion = new Tbl_Profesion();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objTbl_Profesion = db.Tbl_Profesion
                        .Where(x => x.Codigo_Profesion == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objTbl_Profesion;
        }

        //metodo guardar
        public void Guardar()//retorna solo un objeto
        {

            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    if (this.Codigo_Profesion > 0)
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
