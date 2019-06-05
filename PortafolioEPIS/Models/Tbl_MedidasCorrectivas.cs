namespace PortafolioEPIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_MedidasCorrectivas
    {
        [Key]
        public int Codigo_MedidasCorrectivas { get; set; }

        public int Codigo_PruebaEntrada { get; set; }

        [Required]
        [StringLength(250)]
        public string Nombre_MedidasCorrectivas { get; set; }

        public virtual Tbl_PruebaEntrada Tbl_PruebaEntrada { get; set; }
    }
}
