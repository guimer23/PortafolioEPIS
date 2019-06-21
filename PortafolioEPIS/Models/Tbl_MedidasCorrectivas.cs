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

        public bool? Medida1_MedidasCorrectivas { get; set; }

        public bool? Medida2_MedidasCorrectivas { get; set; }

        public bool? Medida3_MedidasCorrectivas { get; set; }

        public bool? Medida4_MedidasCorrectivas { get; set; }

        public bool? Medida5_MedidasCorrectivas { get; set; }

        public bool? Medida6_MedidasCorrectivas { get; set; }

        [StringLength(250)]
        public string Medida7_MedidasCorrectivas { get; set; }

        public virtual Tbl_PruebaEntrada Tbl_PruebaEntrada { get; set; }
    }
}
