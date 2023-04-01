namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbEscalaBristol")]
    public partial class tbEscalaBristol
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbEscalaBristol()
        {
            tbEscalaBristol_Paciente_Consulta = new HashSet<tbEscalaBristol_Paciente_Consulta>();
        }

        [Key]
        public int IdEscalaBristol { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        public bool? Sangue { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbEscalaBristol_Paciente_Consulta> tbEscalaBristol_Paciente_Consulta { get; set; }
    }
}
