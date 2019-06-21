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
    }
}
