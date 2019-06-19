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
    }
}
