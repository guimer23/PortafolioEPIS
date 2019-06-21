namespace PortafolioEPIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    using System.Linq;
    using System.Data.Entity;

    public partial class Tbl_CargoDocente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_CargoDocente()
        {
            Tbl_Docente = new HashSet<Tbl_Docente>();
        }

        [Key]
        public int Codigo_CargoDocente { get; set; }

        [Required]
        [StringLength(30)]
        public string Nombre_CargoDocente { get; set; }

        public bool Estado_CargoDocente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Docente> Tbl_Docente { get; set; }

        //metodo listar
        public List<Tbl_CargoDocente> Listar()//Retorna una coleccion de registros
        {
            var objCargo = new List<Tbl_CargoDocente>();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objCargo = db.Tbl_CargoDocente.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objCargo;
        }

        //metodo obtener
        public Tbl_CargoDocente Obtener(int id)//retorna solo un objeto
        {
            var objCargo = new Tbl_CargoDocente();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objCargo = db.Tbl_CargoDocente
                        .Where(x => x.Codigo_CargoDocente == id)
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
                    if (this.Codigo_CargoDocente > 0)
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
