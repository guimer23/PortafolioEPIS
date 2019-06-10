namespace PortafolioEPIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    public partial class Tbl_PruebaEntrada
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_PruebaEntrada()
        {
            Tbl_ConocimientoHabilidad = new HashSet<Tbl_ConocimientoHabilidad>();
            Tbl_MedidasCorrectivas = new HashSet<Tbl_MedidasCorrectivas>();
        }

        [Key]
        public int Codigo_PruebaEntrada { get; set; }

        public int Codigo_DetalleCargaAcademica { get; set; }

        public int Evaluados_PruebaEntrada { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha_PruebaEntrada { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado_PruebaEntrada { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_ConocimientoHabilidad> Tbl_ConocimientoHabilidad { get; set; }

        public virtual Tbl_DetalleCargaAcademica Tbl_DetalleCargaAcademica { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_MedidasCorrectivas> Tbl_MedidasCorrectivas { get; set; }
    }
}
