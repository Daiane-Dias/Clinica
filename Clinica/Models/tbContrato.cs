namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbContrato")]
    public partial class tbContrato
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbContrato()
        {
            tbProfissional = new HashSet<tbProfissional>();
        }

        [Key]
        [Display(Name = "Contrato")]
        public int IdContrato { get; set; }

        public int IdPlano { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? DataInicio { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? DataFim { get; set; }

        public virtual tbPlano tbPlano { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbProfissional> tbProfissional { get; set; }
    }
}
