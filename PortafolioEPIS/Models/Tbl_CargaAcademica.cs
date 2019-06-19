namespace PortafolioEPIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;
    public partial class Tbl_CargaAcademica
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_CargaAcademica()
        {
            Tbl_DetalleCargaAcademica = new HashSet<Tbl_DetalleCargaAcademica>();
        }

        [Key]
        public int Codigo_CargaAcademica { get; set; }

        public int Codigo_Semestre { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre_CargaAcademica { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaInicio_CargaAcademica { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaFin_CargaAcademica { get; set; }

        public bool Estado_CargaAcademica { get; set; }

        public virtual Tbl_Semestre Tbl_Semestre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_DetalleCargaAcademica> Tbl_DetalleCargaAcademica { get; set; }
    }
}
