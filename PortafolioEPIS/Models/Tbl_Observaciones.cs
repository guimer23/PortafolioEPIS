namespace PortafolioEPIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    using System.Linq;
    using System.Data.Entity;

    public partial class Tbl_Observaciones
    {
        [Key]
        public int Codigo_Observaciones { get; set; }

        public int Codigo_InformeFinal { get; set; }

        [StringLength(250)]
        public string Estudiantes_Observaciones { get; set; }

        [StringLength(250)]
        public string AsistenciaPuntualidad_Observaciones { get; set; }

        [StringLength(250)]
        public string Silabo_Observaciones { get; set; }

        public bool? MaterialCurso_Observaciones { get; set; }

        public bool? Cuestionarios_Observaciones { get; set; }

        public bool? TareasEncargadas_Observaciones { get; set; }

        public bool? Foros_Observaciones { get; set; }

        public bool? ExamenesVirtuales_Observaciones { get; set; }

        public bool? Slideshow_Observaciones { get; set; }

        [StringLength(250)]
        public string Administrativas_Observaciones { get; set; }

        [StringLength(250)]
        public string SilaboCompetencias_Observaciones { get; set; }

        [StringLength(250)]
        public string MejoraContinua_Observaciones { get; set; }

        [StringLength(250)]
        public string ActualizacionDocente_Observaciones { get; set; }

        [StringLength(250)]
        public string ComentariosRecomendaciones_Observaciones { get; set; }

        public virtual Tbl_InformeFinal Tbl_InformeFinal { get; set; }

        //metodo listar
        public List<Tbl_Observaciones> Listar()//Retorna una coleccion de registros
        {
            var objCargo = new List<Tbl_Observaciones>();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objCargo = db.Tbl_Observaciones.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objCargo;
        }

        public List<Tbl_Observaciones> Listar1(int id)//Retorna una coleccion de registros
        {
            var objCargo = new List<Tbl_Observaciones>();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objCargo = db.Tbl_Observaciones.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objCargo;
        }
        //metodo obtener
        public Tbl_Observaciones Obtener(int id)//retorna solo un objeto
        {
            var objCargo = new Tbl_Observaciones();
            try
            {
                using (var db = new Modelo_Portafolio())
                {
                    objCargo = db.Tbl_Observaciones
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
                    if (this.Codigo_Observaciones > 0)
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
