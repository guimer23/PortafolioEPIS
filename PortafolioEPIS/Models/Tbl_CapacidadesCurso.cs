namespace PortafolioEPIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;

    public partial class Tbl_CapacidadesCurso
    {
        [Key]
        public int Codigo_CapacidadesCurso { get; set; }

        public int Codigo_InformeFinal { get; set; }

        [StringLength(250)]
        public string Descripcion_CapacidadesCurso { get; set; }

        public bool Nada_CapacidadesCurso { get; set; }

        public bool Poco_CapacidadesCurso { get; set; }

        public bool Aceptable_CapacidadesCurso { get; set; }

        public bool Bien_CapacidadesCurso { get; set; }

        public bool MuyBien_CapacidadesCurso { get; set; }

        [StringLength(250)]
        public string Motivo_CapacidadesCurso { get; set; }

        public virtual Tbl_InformeFinal Tbl_InformeFinal { get; set; }

        //metodo listar
        public List<Tbl_CapacidadesCurso> Listar(int id)//Retorna una coleccion de registros
        {
            var objCargo = new List<Tbl_CapacidadesCurso>();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objCargo = db.Tbl_CapacidadesCurso
                         .Where(x => x.Codigo_InformeFinal == id)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objCargo;
        }
        //metodo obtener
        public Tbl_CapacidadesCurso ObtenerCapacidades(int id)//retorna solo un objeto
        {
            var objCargo = new Tbl_CapacidadesCurso();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objCargo = db.Tbl_CapacidadesCurso
                        .Where(x => x.Codigo_InformeFinal == id)
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
                    if (this.Codigo_CapacidadesCurso > 0)
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
