namespace PortafolioEPIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    using System.Linq;
    using System.Data.Entity;

    public partial class Tbl_Portafolio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Portafolio()
        {
            Tbl_Material = new HashSet<Tbl_Material>();
        }

        [Key]
        public int Codigo_Portafolio { get; set; }

        public int Codigo_DetalleCargaAcademica { get; set; }

        [StringLength(5)]
        public string Unidad_Portafolio { get; set; }

        public int? Retirados_Portafolio { get; set; }

        public int? Abandono_Portafolio { get; set; }

        public int? Aprobados_Portafolio { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha_Portafolio { get; set; }

        [StringLength(1)]
        public string Estado_Portafolio { get; set; }

        public virtual Tbl_DetalleCargaAcademica Tbl_DetalleCargaAcademica { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Material> Tbl_Material { get; set; }
    }
}
