namespace PortafolioEPIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_InformeFinal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_InformeFinal()
        {
            Tbl_CapacidadesCurso = new HashSet<Tbl_CapacidadesCurso>();
            Tbl_Observaciones = new HashSet<Tbl_Observaciones>();
        }

        [Key]
        public int Codigo_InformeFinal { get; set; }

        public int Codigo_DetalleCargaAcademica { get; set; }

        public int? PorcentajeSilabo_InformeFinal { get; set; }

        public int? PracticasCalificadas_InformeFinal { get; set; }

        public int? LaboratoriosRealizados_InformeFinal { get; set; }

        public int? TrabajosRealizados_InformeFinal { get; set; }

        public int? EstudiantesMatriculados_InformeFinal { get; set; }

        public int? EstudiantesRetiro_InformeFinal { get; set; }

        public int? EstudiantesAbandono_InformeFinal { get; set; }

        public int? EstudiantesAsisten_InformeFinal { get; set; }

        public int? EstudiantesAprobados_InformeFinal { get; set; }

        public int? EstudiantesDesaprobados_InformeFinal { get; set; }

        public int? NotaAlta_InformeFinal { get; set; }

        public int? NotaPromedio_InformeFinal { get; set; }

        public int? NotaBaja_InformeFinal { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha_InformeFinal { get; set; }

        [StringLength(1)]
        public string Estado_InformeFinal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_CapacidadesCurso> Tbl_CapacidadesCurso { get; set; }

        public virtual Tbl_DetalleCargaAcademica Tbl_DetalleCargaAcademica { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Observaciones> Tbl_Observaciones { get; set; }
    }
}
