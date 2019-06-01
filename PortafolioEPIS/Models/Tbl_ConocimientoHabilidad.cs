namespace PortafolioEPIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Tbl_ConocimientoHabilidad
    {
        [Key]
        public int Codigo_ConocimientoHabilidad { get; set; }

        public int Codigo_PruebaEntrada { get; set; }

        [Required]
        [StringLength(250)]
        public string Nombre_ConocimientoHabilidad { get; set; }

        public int Deficiente_ConocimientoHabilidad { get; set; }

        public int Suficiente_ConocimientoHabilidad { get; set; }

        public int Bueno_ConocimientoHabilidad { get; set; }

        public virtual Tbl_PruebaEntrada Tbl_PruebaEntrada { get; set; }

        //Metodo Listar
        public List<Tbl_ConocimientoHabilidad> Listar()
        {
            var objConocimientoHabilidad = new List<Tbl_ConocimientoHabilidad>();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objConocimientoHabilidad = db.Tbl_ConocimientoHabilidad.Include("Tbl_PruebaEntrada").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objConocimientoHabilidad;
        }

        //Metodo Obtener
        public Tbl_ConocimientoHabilidad Obtener(int id)//retorna solo un objeto
        {
            var objConocimientoHabilidad = new Tbl_ConocimientoHabilidad();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objConocimientoHabilidad = db.Tbl_ConocimientoHabilidad.Include("Tbl_PruebaEntrada")
                                    .Where(x => x.Codigo_ConocimientoHabilidad == id)
                                    .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objConocimientoHabilidad;
        }

        //Metodo Guardar

        public void Guardar()
        {
            try
            {
                using (var db = new Modelo_Portafolio())
                {

                    if (this.Codigo_ConocimientoHabilidad > 0)
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
            catch (Exception)
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
            catch (Exception)
            {
                throw;
            }
        }
    }
}
