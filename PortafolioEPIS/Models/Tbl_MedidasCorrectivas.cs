namespace PortafolioEPIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;

    public partial class Tbl_MedidasCorrectivas
    {
        [Key]
        public int Codigo_MedidasCorrectivas { get; set; }

        public int Codigo_PruebaEntrada { get; set; }

        [Required]
        [StringLength(250)]
        public string Nombre_MedidasCorrectivas { get; set; }

        public virtual Tbl_PruebaEntrada Tbl_PruebaEntrada { get; set; }

        //metodo listar
        public List<Tbl_MedidasCorrectivas> Listar()//Retorna una coleccion de registros
        {
            var objTbl_MedidasCorrectivas = new List<Tbl_MedidasCorrectivas>();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objTbl_MedidasCorrectivas = db.Tbl_MedidasCorrectivas.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objTbl_MedidasCorrectivas;
        }

        //metodo obtener
        public Tbl_MedidasCorrectivas Obtener(int id)//retorna solo un objeto
        {
            var objTbl_MedidasCorrectivas = new Tbl_MedidasCorrectivas();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objTbl_MedidasCorrectivas = db.Tbl_MedidasCorrectivas
                        .Where(x => x.Codigo_MedidasCorrectivas == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objTbl_MedidasCorrectivas;
        }

        //metodo guardar
        public void Guardar()//retorna solo un objeto
        {

            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    if (this.Codigo_MedidasCorrectivas > 0)
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
