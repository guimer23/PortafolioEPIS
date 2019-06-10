namespace PortafolioEPIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

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
    }
}
