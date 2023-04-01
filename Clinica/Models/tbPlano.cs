namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbPlano")]
    public partial class tbPlano
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbPlano()
        {
            tbContrato = new HashSet<tbContrato>();
        }

        [Key]
        public int IdPlano { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public int Validade { get; set; }

        public decimal Valor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbContrato> tbContrato { get; set; }
    }
}
