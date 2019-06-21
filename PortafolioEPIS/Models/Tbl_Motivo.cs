namespace PortafolioEPIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    using System.Linq;
    using System.Data.Entity;

    public partial class Tbl_Motivo
    {
        [Key]
        public int Codigo_Motivo { get; set; }

        public int Codigo_InformeFinal { get; set; }

        [StringLength(250)]
        public string Descripcion_Motivo { get; set; }

        public virtual Tbl_InformeFinal Tbl_InformeFinal { get; set; }


        //Metodo Obtener
        public Tbl_Motivo Obtener(int id)//retorna solo un objeto
        {
            var objMotivo = new Tbl_Motivo();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objMotivo = db.Tbl_Motivo
                                    .Where(x => x.Codigo_InformeFinal == id)
                                    .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objMotivo;
        }

        //Metodo Guardar

        public void Guardar()
        {
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    if (this.Codigo_Motivo > 0)//sis existe un valor mayor a cero es porque existe registro
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

    }
}
