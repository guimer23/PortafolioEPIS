namespace PortafolioEPIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    using System.Linq;
    using System.Data.Entity;

    public partial class Tbl_Usuario
    {
        [Key]
        public int Codigo_Usuario { get; set; }

        public int Codigo_Docente { get; set; }

        [StringLength(100)]
        public string Nombre_Usuario { get; set; }

        [StringLength(100)]
        public string Password_Usuario { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaCreacion_Usuario { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaActualizacion_Usuario { get; set; }

        public bool? Estado_Usuario { get; set; }

        public virtual Tbl_Docente Tbl_Docente { get; set; }
    }
}
