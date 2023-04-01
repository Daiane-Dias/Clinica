namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbEstado")]
    public partial class tbEstado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbEstado()
        {
            tbCidade = new HashSet<tbCidade>();
        }

        [Key]
        public int IdEstado { get; set; }

        public int IdPais { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(2)]
        public string UF { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbCidade> tbCidade { get; set; }

        public virtual tbPais tbPais { get; set; }
    }
}
