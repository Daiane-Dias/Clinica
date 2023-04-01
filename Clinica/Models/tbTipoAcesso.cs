namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbTipoAcesso")]
    public partial class tbTipoAcesso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbTipoAcesso()
        {
            tbProfissional = new HashSet<tbProfissional>();
        }

        [Key]
        public int IdTipoAcesso { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public bool FlagAtivo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbProfissional> tbProfissional { get; set; }
    }
}
