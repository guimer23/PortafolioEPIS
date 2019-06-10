namespace PortafolioEPIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    public partial class Tbl_Material
    {
        [Key]
        public int Codigo_Material { get; set; }

        public int Codigo_Portafolio { get; set; }

        [StringLength(21)]
        public string Tipo_Material { get; set; }

        [StringLength(250)]
        public string Nombre_Material { get; set; }

        [StringLength(21)]
        public string Estado_Material { get; set; }

        public int? Cantidad_Material { get; set; }

        [StringLength(250)]
        public string Archivo_Material { get; set; }

        [StringLength(10)]
        public string TipoArchivo_Material { get; set; }

        [StringLength(50)]
        public string PesoArchivo_Material { get; set; }

        [StringLength(250)]
        public string Descripcion_Material { get; set; }

        public virtual Tbl_Portafolio Tbl_Portafolio { get; set; }
    }
}
