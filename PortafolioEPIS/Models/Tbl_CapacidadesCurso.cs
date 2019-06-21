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

        public int? Nada_CapacidadesCurso { get; set; }

        public int? Poco_CapacidadesCurso { get; set; }

        public int? Aceptable_CapacidadesCurso { get; set; }

        public int? Bien_CapacidadesCurso { get; set; }

        public int? MuyBien_CapacidadesCurso { get; set; }

        public virtual Tbl_InformeFinal Tbl_InformeFinal { get; set; }
    }
}
